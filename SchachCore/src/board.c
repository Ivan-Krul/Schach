#include "pch.h"

Board set_board(char count_players) {
    Board b;
    b.move = 0;
    b.count_players = count_players;
    return b;
}

Board set_default_board(char count_players) {
    Board b = set_board(count_players);

    if (count_players < 2)
        return b;

    get_board_default_state(b.state);

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

void get_board_default_state(Piece* pieces) {
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
        else if (precalc_y1 || precalc_yn_2)
            set_piece_type(&pieces[i], pawn);
        else
            set_piece_type(&pieces[i], none);

        if (precalc_y1 || precalc_y0)
            set_piece_color(&pieces[i], 1);
        else if (precalc_yn_1 || precalc_yn_2)
            set_piece_color(&pieces[i], 2);
        else
            set_piece_color(&pieces[i], 0);
    }
}

void set_board_state(Board* inst, const Piece* state) {
    memcpy(inst->state, state, BOARD_AREA * sizeof(Piece));
}
