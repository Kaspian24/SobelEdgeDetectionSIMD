.data

align 16
MatrixXandY DB 1, 0, -1, 2, -2, 1, 0, -1, -1, -2, -1, 0, 0, 1, 2, 1
ShuffleMatrixA DB 0, 1, 2, 4, 6, 9, 10, 11, 0, 1, 2, 4, 6, 9, 10, 11
ShuffleRGB DB 0, 1, 2, 0, 3, 4, 5, 0, 6, 7, 8, 0, 9, 10, 11, 0
MaskRGB DB 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0
DivideByThree DD 3.0, 3.0, 3.0, 3.0

.code
SobelAsm proc	;	byte[] rgbValues,	byte[] grayValues,	int width,		int height,		int scanWidth,				int detectionLevel
				;	rcx,				rdx,				r8,				r9,				qword ptr [rsp+8*5],		qword ptr [rsp+8*6]

; save non-volatile registers
push rbx
push r12
push r13
push r14
push r15

push rcx ; save rgbValues on stack for later use
push rdx ; save grayValues on stack for later use
; stack moved by 8*7

; initialize SSE registers
vmovdqa xmm5, xmmword ptr [ShuffleRGB]
vmovdqa xmm4, xmmword ptr [MaskRGB]
vmovdqa xmm3, xmmword ptr [DivideByThree]

mov r12, rcx ; r12 = rgbValues
mov r13, rdx ; r13 = grayValues

mov rbx, 3 ; rbx = 3 (for div and mul)

mov r11, qword ptr [rsp+8*7+8*5] ; r11 = scanWidth

mov rax, r8 ; rax = width
mul bx ; rax = width*3
sub r11, rax ; r11 = scanWidth - width*3 = widthDifference

; rgb to gray
mov r14, r9 ; set outer loop counter to height
l1:
	mov r15, r8 ; set inner loop counter to width
	l1_0:
		cmp r15, 6 ; prevent overriding next line and reading memory outside of the array at last line
		jl l1_0_end
		vmovdqu xmm0, xmmword ptr [r12]
		vpshufb xmm0, xmm0, xmm5 ; shuffle bytes to 4 groups of R, G, B, Placeholder
		vpmaddubsw xmm0, xmm0, xmm4 ; R*1, G*1, B*1, Placeholder * 0
									; => R+G, B+0
									; => byte to word
		vphaddw xmm0, xmm0, xmm5 ; R+G+B+0
		vpmovzxwd xmm0, xmm0 ; word to double word
		vcvtdq2ps xmm0, xmm0 ; double word to single precision (no instruction for dividing integers)

		vdivps xmm0, xmm0, xmm3 ; (R+G+B)/3

		vcvttps2dq xmm0, xmm0 ; single precision to double word, rounded down

		vpackusdw xmm0, xmm0, xmm0 ; double word to word
		vpackuswb xmm0, xmm0, xmm0 ; word to byte

		vmovd dword ptr [r13], xmm0

		mov qword ptr [r12], 0000000000000000h
		mov dword ptr [r12+8], 00000000h

		add r12, 12
		add r13, 4
		sub r15, 4
		jmp l1_0
	l1_0_end:
		cmp r15, 0
		je l1_1_end
	l1_1:
		movzx eax, byte ptr [r12]
		movzx ecx, byte ptr [r12+1]
		add eax, ecx ; rax = R+G
		movzx ecx, byte ptr [r12+2]
		add eax, ecx ; rax = R+G+B

		xor edx, edx ; clear edx for div
		div bx ; rax = (R+G+B)/3

		mov [r13], al

		mov word ptr [r12], 0
		mov byte ptr [r12+2], 0

		add r12, 3
		inc r13
		dec r15
		jnz l1_1
	l1_1_end:
	add r12, r11
	dec r14
	jnz l1

; initialize SSE registers
vpxor xmm5, xmm5, xmm15
vmovdqa xmm4, xmmword ptr [ShuffleMatrixA]
vmovdqa xmm3, xmmword ptr [MatrixXandY]

mov r10, r8 ; r10 = width

pop r13 ; r13 = grayValues
pop r12 ; r12 = rgbValues
; stack moved by 8*5

add r12, qword ptr [rsp+8*5+8*5] ; r12 = rgbValues + scanWidth
add r12, 3 ; r12 = rgbValues + scanWidth + 3

sub r8, 2 ; r8 = width - 2
sub r9, 2 ; r9 = height - 2

add r11, 6 ; r11 = widthDifference + 6

; sobel edge detection
mov r14, r9 ; set outer loop counter to height - 2
mov rcx, qword ptr [rsp+8*5+8*6] ; rcx = detectionLevel
l2:
	mov r15, r8 ; set inner loop counter to width - 2
	l2_1:
		; load matrix A
		vmovd xmm0, dword ptr [r13]
		vpinsrd xmm0, xmm0, dword ptr [r13+r10], 1
		vpinsrd xmm0, xmm0, dword ptr [r13+2*r10-1], 2
		vpshufb xmm0, xmm0, xmm4 ; place 8 bytes in correct order and copy them to upper part of register

		vpmaddubsw xmm0, xmm0, xmm3 ; xmm0(low) = MatrixA * MatrixX, xmm0(high) = MatrixA * MatrixY
									; => xmm0(low) = x0+x1, x2+x3, x4+x5, x6+x7, xmm0(high) = y0+y1, y2+y3, y4+y5, y6+y7
									; => byte to word
		vphaddw xmm0, xmm0, xmm5 ; add horizontal pairs
		vphaddw xmm0, xmm0, xmm5 ; add horizontal pairs to get Gx and Gy
		vpmaddwd xmm0, xmm0, xmm0 ; Gx * Gx, Gy * Gy
								  ; => word to double word
								  ; => G^2 = Gx^2 + Gy^2

		vmovd eax, xmm0
		cmp eax, ecx ; compare G^2 with detectionLevel
		jl end_edge

		mov word ptr [r12], 0FFFFh
		mov byte ptr [r12+2], 0FFh
	end_edge:
		add r12, 3
		inc r13
		dec r15
		jnz l2_1
	add r12, r11 ; add withDifference + 6
	add r13, 2
	dec r14
	jnz l2

; restore non-volatile registers
pop r15
pop r14
pop r13
pop r12
pop rbx

ret
SobelAsm endp
end