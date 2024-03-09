// dllmain.c : Defines the entry point for the DLL application.
#include "pch.h"
#include <stdio.h>

__declspec(dllexport) void Print(const char* str);
__declspec(dllexport) Board CreateBoard();
__declspec(dllexport) bool IsInBoard(const int targetX, const int targetY);

void Print(const char* str) {
    printf("%s\n", str);
}

Board CreateBoard() {
    Board b = set_default_board(2);
    return b;
}

bool IsInBoard(const int targetX, const int targetY) {
    return (targetX >= 0) && (targetX < BOARD_SIDE) && (targetY >= 0) && (targetY < BOARD_SIDE);
}

