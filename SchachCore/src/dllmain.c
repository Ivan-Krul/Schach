// dllmain.c : Defines the entry point for the DLL application.
#include "pch.h"
#include <stdio.h>

__declspec(dllexport) void Print(const char* str);
__declspec(dllexport) Board CreateBoard();

void Print(const char* str) {
    printf("%s\n", str);
}

Board CreateBoard() {
    Board b = set_default_board(2);
    return b;
}

