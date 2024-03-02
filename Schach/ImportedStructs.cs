using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
    internal class ImportedStructs
    {
        public enum PieceType
        {
            none,
            king,
            queen,
            bishop,
            knight,
            rook,
            pawn,
            _count
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Piece
        {
            public byte value;

            public Piece(byte value)
            {
                this.value = value;
            }

            public byte GetColor()
            {
                return (byte)(value & 0x1f);
            }
            public PieceType GetPieceType()
            {
                return (PieceType)(value >> 5);
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class Board
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public Piece[] state;
            public byte count_players;
            public byte move;

            public Board(byte count_players, byte move)
            {
                this.count_players = count_players;
                this.state = new Piece[64];
                this.move = move;
            }
        }
    }
}
