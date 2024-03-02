// dllmain.c : Defines the entry point for the DLL application.
#include "pch.h"
#include <stdio.h>

__declspec(dllexport) void Print(const char* str);
__declspec(dllexport) Board* CreateBoard();
__declspec(dllexport) void DeleteBoard(Board* ptr);

void Print(const char* str) {
    printf("%s\n", str);
}

Board* CreateBoard() {
    Board* pB = malloc(sizeof(Board));
    Board b = set_default_board(2);
    memcpy(pB, &b, sizeof(Board));
    return pB;
}

void DeleteBoard(Board* ptr) {
    free(ptr);
}

