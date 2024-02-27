#pragma once
#include <stdbool.h>
#include <stdlib.h>
#include <errno.h>
#include "pieces.h"

#pragma pack(push)
#pragma pack(2)

#define BOARD_SIDE 8
#define BOARD_AREA (BOARD_SIDE * BOARD_SIDE)

struct Board {
    Piece state[BOARD_AREA];
    char count_players;
    char move;
    char* players;
};
typedef struct Board Board;


Piece* get_board_default_state(const char wht, const char blk);
void set_board_players(Board* inst, const char* players, char count_players);
void set_board_state(Board* inst, const Piece* state);


Board set_board(char* players, char count_players) {
    Board b;
    set_board_players(&b, players, count_players);
    b.move = 0;
    return b;
}

Board set_default_board(char* players, char count_players) {
    if (count_players < 2)
        return set_board(players, count_players);

    Board b;
    set_board_players(&b, players, count_players);

    Piece* state = get_board_default_state(players[0], players[1]);

    set_board_state(&b, state);

    free(state);
    return b;
}

PieceType set_default_piece_type(char i) {
    switch (i % BOARD_SIDE) {
    case 0:
    case BOARD_SIDE - 1:
        return rook;
    case 1:
    case BOARD_SIDE - 2:
        return knight;
    case 2:
    case BOARD_SIDE - 3:
        return bishop;
    case BOARD_SIDE - 4:
        return king;
    default:
        return queen;
    }
}

Piece* get_board_default_state(const char wht, const char blk) {
    Piece* pieces = malloc(BOARD_AREA * sizeof(Piece));
    Piece buf;

    bool precalc_y0;
    bool precalc_y1;
    bool precalc_yn_1;
    bool precalc_yn_2;

    for (char i = 0; i < BOARD_AREA; i++) {
        precalc_y0 = (i / BOARD_SIDE) == 0;
        precalc_y1 = (i / BOARD_SIDE) == 1;
        precalc_yn_1 = (i / BOARD_SIDE) == (BOARD_SIDE - 1);
        precalc_yn_2 = (i / BOARD_SIDE) == (BOARD_SIDE - 2);

        if (precalc_y0 || precalc_yn_1)
            set_piece_type(&pieces[i], set_default_piece_type(i));
        else if(precalc_y1 || precalc_yn_2)
            set_piece_type(&pieces[i], pawn);

        if (precalc_y1 || precalc_y0)
            set_piece_color(&pieces[i], blk);
        else if(precalc_yn_1 || precalc_yn_2)
            set_piece_color(&pieces[i], wht);
    }
    return pieces;
}

void set_board_players(Board* inst, const char* players, char count_players) {
    inst->players = malloc(count_players);
    if (inst->players == NULL) {

    }

    for (char i = 0; i < count_players; i++) {
        inst->players[i] = players[i] & PIECE_COLOR_MASK;
    }
}

void set_board_state(Board* inst, const Piece* state) {
    memcpy(inst->state, state, BOARD_AREA * sizeof(Piece));
}

void free_board(Board* inst) {
    free(inst->players);
}

#pragma pack(pop)