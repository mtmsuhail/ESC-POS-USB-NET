using ESC_POS_USB_NET.Enums;

namespace ESC_POS_USB_NET.Interfaces.Command
{
    interface IBarCode
    {
        byte[] Code128(string code,Positions printString);
        byte[] Code39(string code, Positions printString);
        byte[] Ean13(string code, Positions printString);
    }
}

