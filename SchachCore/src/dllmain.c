// dllmain.c : Defines the entry point for the DLL application.
#include "pch.h"
#include <stdio.h>

__declspec(dllexport) void Print(const char* str);
__declspec(dllexport) Board CreateBoard();
__declspec(dllexport) short ConvertToStringChessPos(int x, int y);

void Print(const char* str) {
    printf("%s\n", str);
}

Board CreateBoard() {
    Board b = set_default_board(2);
    return b;
}

short ConvertToStringChessPos(int x, int y) {
    short chrX = 'A' + x;
    short chrY = '8' - y;

    return (chrX << 8) | chrY;
}

