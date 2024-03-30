using ESC_POS_USB_NET.Enums;
using ESC_POS_USB_NET.Extensions;
using ESC_POS_USB_NET.Interfaces.Command;

namespace ESC_POS_USB_NET.EpsonCommands
{
    public class BarCode : IBarCode
    {
        /// <summary>
        /// Create Code-128 barcode. Use C charset.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="printString"></param>
        /// <returns></returns>
        public byte[] Code128(string code,Positions printString=Positions.NotPrint)
        {
            return new byte[] { 29, 119, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 1 }) // font hri character
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 73 }) // printCode
                .AddBytes(new[] { (byte)(code.Length + 2) })
                .AddBytes(new[] { '{'.ToByte(), 'C'.ToByte() })
                .AddBytes(code)
                .AddLF();
        }

        /// <summary>
        /// Create Code-128 barcode. Use C charset.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="printString"></param>
        /// <returns></returns>
        public byte[] Code128(byte[] code, Positions printString = Positions.NotPrint)
        {
            return new byte[] { 29, 119, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 1 }) // font hri character
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 73 }) // printCode
                .AddBytes(new[] { (byte)(code.Length + 2) })
                .AddBytes(new[] { '{'.ToByte(), 'C'.ToByte() })
                .AddBytes(code)
                .AddLF();
        }

        /// <summary>
        /// Create Code-128 barcode. With option to set Code128 charset.
        /// Insipred by @https://github.com/mtmsuhail/ESC-POS-USB-NET/pull/38/commits/fc5cb17a798093bbf8e1a376e35051f1fc1a9ff7
        /// </summary>
        /// <param name="code"></param>
        /// <param name="printString"></param>
        /// <param name="startCharset"></param>
        /// <returns></returns>
        public byte[] Code128(string code, Positions printString = Positions.NotPrint, BarCodeCode128Charset startCharset= BarCodeCode128Charset.C, BarCodeBarWidth barWidth=BarCodeBarWidth.Width0250, byte codeHeight=50)
        {
            return new byte[] { 29, 119, (byte)barWidth } // Width
                .AddBytes(new byte[] { 29, 104, codeHeight }) // Height
                .AddBytes(new byte[] { 29, 102, 1 }) // font hri character
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 73 }) // printCode
                .AddBytes(new[] { (byte)(code.Length + 2) })
                .AddBytes(new[] { '{'.ToByte(), startCharset.ToByte() })
                .AddBytes(code)
                .AddLF();
        }



        public byte[] Code39(string code, Positions printString = Positions.NotPrint)
        {
            return new byte[] { 29, 119, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 0 }) // font hri character
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 4 })
                .AddBytes(code)
                .AddBytes(new byte[] { 0 })
                .AddLF();
        }

        /// <summary>
        /// Generate Code-39 barcode.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="printString"></param>
        /// <param name="barWidth"></param>
        /// <param name="codeHeight"></param>
        /// <returns></returns>
        public byte[] Code39(string code, Positions printString = Positions.NotPrint, BarCodeBarWidth barWidth = BarCodeBarWidth.Width0250, byte codeHeight = 50)
        {
            return new byte[] { 29, 119, (byte)barWidth } // Width
                .AddBytes(new byte[] { 29, 104, codeHeight }) // Height
                .AddBytes(new byte[] { 29, 102, 0 }) // font hri characterset (A)
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 4 })
                .AddBytes(code)
                .AddBytes(new byte[] { 0 })
                .AddLF();
        }


        public byte[] Ean13(string code, Positions printString = Positions.NotPrint)
        {
            if (code.Trim().Length != 13)
                return new byte[0];

            return new byte[] { 29, 119, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 67, 12 })
                .AddBytes(code.Substring(0, 12))
                .AddLF();
        }

        /// <summary>
        /// Generate EAN-13 code.
        /// </summary>
        /// <param name="code">EAN-13 13digit string</param>
        /// <param name="printString"></param>
        /// <param name="barWidth">Width of thin-bar in barcode</param>
        /// <param name="codeHeight">Height on barcode (in dots)</param>
        /// <returns></returns>
        public byte[] Ean13(string code, Positions printString = Positions.NotPrint, BarCodeBarWidth barWidth = BarCodeBarWidth.Width0250, byte codeHeight=50)
        {
            if (code.Trim().Length != 13)
                return new byte[0];

            return new byte[] { 29, 119, (byte)barWidth } // Width
                .AddBytes(new byte[] { 29, 104, codeHeight }) // Height
                .AddBytes(new byte[] { 29, 72, printString.ToByte() }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 67, 12 })
                .AddBytes(code.Substring(0, 12))
                .AddLF();
        }
    }
}

