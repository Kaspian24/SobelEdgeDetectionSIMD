#pragma once

#ifdef SOBEL_EXPORTS
#define SOBEL_LIB _declspec(dllexport)
#else
#define SOBEL_LIB _declspec(dllimport)
#endif // SOBEL_EXPORTS

extern "C" SOBEL_LIB int SobelCpp(uint8_t * rgbValues, uint8_t * grayValues, int width, int height, int scanWidth, int detectionLevel);