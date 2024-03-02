using System;
using System.Collections.Generic;
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
        public static extern ImportedStructs.Board CreateBoard();

    }
}
