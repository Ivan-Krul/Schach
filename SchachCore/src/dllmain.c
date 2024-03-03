// dllmain.c : Defines the entry point for the DLL application.
#include "pch.h"
#include <stdio.h>

__declspec(dllexport) void Print(const char* str);
__declspec(dllexport) Board* CreateBoard();
__declspec(dllexport) Piece GetPiece();
__declspec(dllexport) void DeleteBoard (Board* ptr);

void Print(const char* str) {
    printf("%s\n", str);
}

Board* CreateBoard() {
    Board* pB = malloc(sizeof(Board));
    Board b = set_default_board(2);
    memcpy(pB, &b, sizeof(Board));
    return pB;
}

Piece GetPiece() {
    return set_piece(pawn, 'W');
}

struct Arr {
    int a[5];
};

__declspec(dllexport) struct Arr GetArray5() {
    struct Arr b;
    b.a[0];
    int arr[5] = { 0, 1, 3, 5, 8 };
    memcpy(b.a, arr, 20);
    return b;
}

void DeleteBoard(Board* ptr) {
    free(ptr);
}

