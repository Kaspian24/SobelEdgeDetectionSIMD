#include "pch.h"
#include <utility>
#include <limits.h>
#include "SobelCpp.h"
#include <cmath>

int SobelCpp(uint8_t* rgbValues, uint8_t* grayValues, int width, int height, int scanWidth, int detectionLevel)
{
	int matrixX[] = { 1, 0, -1, 2, 0, -2, 1, 0, -1 };
	int matrixY[] = { 1, 2, 1, 0, 0, 0, -1, -2, -1 };

	// rgb to gray
	for (int i = 0; i < height; i++) {
		for (int j = 0; j < width; j++) {
			int currentPixel = (i * scanWidth + j * 3);
			grayValues[i * width + j] = (rgbValues[currentPixel] + rgbValues[currentPixel + 1] + rgbValues[currentPixel + 2]) / 3;
			rgbValues[currentPixel] = 0x00;
			rgbValues[currentPixel + 1] = 0x00;
			rgbValues[currentPixel + 2] = 0x00;
		}
	}

	// sobel edge detection
	for (int i = 1; i < height - 1; i++) {
		for (int j = 1; j < width - 1; j++) {
			int edgeX = matrixX[0] * grayValues[(i - 1) * width + (j - 1)] + matrixX[1] * grayValues[(i - 1) * width + j] + matrixX[2] * grayValues[(i - 1) * width + (j + 1)]
				+ matrixX[3] * grayValues[i * width + (j - 1)] + matrixX[4] * grayValues[i * width + j] + matrixX[5] * grayValues[i * width + (j + 1)]
				+ matrixX[6] * grayValues[(i + 1) * width + (j - 1)] + matrixX[7] * grayValues[(i + 1) * width + j] + matrixX[8] * grayValues[(i + 1) * width + (j + 1)];
			int edgeY = matrixY[0] * grayValues[(i - 1) * width + (j - 1)] + matrixY[1] * grayValues[(i - 1) * width + j] + matrixY[2] * grayValues[(i - 1) * width + (j + 1)]
				+ matrixY[3] * grayValues[i * width + (j - 1)] + matrixY[4] * grayValues[i * width + j] + matrixY[5] * grayValues[i * width + (j + 1)]
				+ matrixY[6] * grayValues[(i + 1) * width + (j - 1)] + matrixY[7] * grayValues[(i + 1) * width + j] + matrixY[8] * grayValues[(i + 1) * width + (j + 1)];
			int gradient = edgeX * edgeX + edgeY * edgeY;
			int currentPixel = (i * scanWidth + j * 3);
			if (gradient >= detectionLevel) {
				rgbValues[currentPixel] = 0xFF;
				rgbValues[currentPixel + 1] = 0xFF;
				rgbValues[currentPixel + 2] = 0xFF;
			}
		}
	}
	return 0;
}