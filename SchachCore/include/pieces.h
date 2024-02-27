#pragma once

typedef struct piece {
    enum piecetype : char {
        none,
        king,
        queen,
        bishop,
        knight,
        rook,
        pawn,
        _count
    } type : 3;
    char color : 5;
};


