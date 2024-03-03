using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Schach.ImportedStructs;

namespace Schach
{
    internal class Import
    {
        [DllImport("SchachCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Print([MarshalAs(UnmanagedType.LPStr)] string message);

        [DllImport("SchachCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImportedStructs.Piece GetPiece();

        //public static extern nint CreateBoard();

        [DllImport("SchachCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImportedStructs.Arr GetArray5();

    }
}
