#pragma once
#include "board.h"

struct Coord {
    char x : BOARD_SIDE_CAPACITY;
    char y : BOARD_SIDE_CAPACITY;
};
typedef struct Coord Coord;

struct Move {
    Coord coord_from;
    Coord coord_to;
    char en_passant_oppirtunity : 1;
    char castling : 1;
    char promotion : 3;
    char check : 1;
    char mate : 1;
    char stalemate : 1;
};
typedef struct Move Move;

Coord set_coord(char x, char y) {
    Coord c;
    c.x = x;
    c.y = y;
    return c;
}



