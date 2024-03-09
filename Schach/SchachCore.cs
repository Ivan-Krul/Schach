using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
    internal class SchachCore
    {
        // Imported structs
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
        public struct Board
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public Piece[] state;
            public byte count_players;
            public byte move;
        }


        // Imported functions
        [DllImport("SchachCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Print([MarshalAs(UnmanagedType.LPStr)] string message);

        [DllImport("SchachCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Board CreateBoard();

        [DllImport("SchachCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern short ConvertToRawStringChessPos(int x, int y);

        public static string ConvertToStringChessPos(int x, int y)
        {
            short knot = ConvertToRawStringChessPos(x, y);
            return $"{(char)(knot >> 8)}{(char)(knot & 255)}";
        }
    }
}
