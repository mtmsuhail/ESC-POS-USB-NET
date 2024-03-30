using ESC_POS_USB_NET.Enums;

namespace ESC_POS_USB_NET.Interfaces.Command
{
    interface IBarCode
    {
        byte[] Code128(string code,Positions printString);
        byte[] Code128(byte[] code,Positions printString);
        byte[] Code128(string code,Positions printString, BarCodeCode128Charset startCharset= BarCodeCode128Charset.C, BarCodeBarWidth barWidth = BarCodeBarWidth.Width0250, byte codeHeight = 50);
        byte[] Code39(string code, Positions printString);
        byte[] Code39(string code, Positions printString = Positions.NotPrint, BarCodeBarWidth barWidth = BarCodeBarWidth.Width0250, byte codeHeight = 50);
        byte[] Ean13(string code, Positions printString);
        byte[] Ean13(string code, Positions printString = Positions.NotPrint, BarCodeBarWidth barWidth = BarCodeBarWidth.Width0250, byte codeHeight = 50);
    }
}

