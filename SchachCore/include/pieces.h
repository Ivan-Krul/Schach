#pragma once
//#pragma pack(push)
//#pragma pack(1)

#define PIECE_COLOR_BITS 5
#define PIECE_TYPE_BITS 3

#define PIECE_COLOR_MASK ((1<<PIECE_COLOR_BITS)-1)
#define PIECE_TYPE_MASK ((1<<PIECE_TYPE_BITS)-1)


enum PieceType {
    none,
    king,
    queen,
    bishop,
    knight,
    rook,
    pawn,
    _count
};
typedef enum PieceType PieceType;


struct Piece {
    char color : PIECE_COLOR_BITS;
    char type : PIECE_TYPE_BITS;
};
typedef struct Piece Piece;


inline void set_piece_color(Piece* inst, const char color);
inline void set_piece_type(Piece* inst, PieceType type);

inline Piece set_piece(PieceType type, const char color) {
    Piece p;
    set_piece_color(&p, color);
    set_piece_type(&p, type);
    return p;
}

void set_piece_color(Piece* inst, const char color) {
    inst->color = color & PIECE_COLOR_MASK;
}

inline char get_piece_color(const Piece inst) {
    return inst.color << 6;
}

void set_piece_type(Piece* inst, PieceType type) {
    inst->type = type & PIECE_TYPE_MASK;
}

inline PieceType get_piece_type(Piece inst) {
    return (PieceType)inst.type;
}

//#pragma pack(pop)