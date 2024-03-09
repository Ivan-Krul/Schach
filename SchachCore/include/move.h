#pragma once
#include "board.h"

struct coord {
    char x : BOARD_SIDE_CAPACITY;
    char y : BOARD_SIDE_CAPACITY;
};
typedef struct coord coord;

struct move {
    coord coord_from;
    coord coord_to;
    char en_passant_oppirtunity : 1;
    char castling : 1;
    char promotion : 3;
    char check : 1;
    char mate : 1;
    char stalemate : 1;
};
typedef struct move move;


