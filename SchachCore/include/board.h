#pragma once
#include <stdbool.h>
#include <stdlib.h>
#include <errno.h>
#include "Pieces.h"

#pragma pack(push)
#pragma pack(2)

#define BOARD_SIDE 8
#define BOARD_AREA (BOARD_SIDE * BOARD_SIDE)

struct Board {
    Piece state[BOARD_AREA];
    char count_players;
    char move;
};
typedef struct Board Board;

Board set_board(char count_players);
Board set_default_board(char count_players);
Piece* get_board_default_state();
void set_board_state(Board* inst, const Piece* state);
PieceType set_default_piece_type(char i);

#pragma pack(pop)