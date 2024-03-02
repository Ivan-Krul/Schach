// dllmain.c : Defines the entry point for the DLL application.
#include "pch.h"
#include <stdio.h>

__declspec(dllexport) void Print(const char* str);
__declspec(dllexport) Board BoardCreateBoard();

void Print(const char* str) {
    printf("%s\n", str);
}

Board BoardCreateBoard() {
    return set_default_board(2);
}
