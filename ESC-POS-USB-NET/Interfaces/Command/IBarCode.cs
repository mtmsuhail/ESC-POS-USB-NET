namespace ESC_POS_USB_NET.Interfaces.Command
{
    interface IBarCode
    {
        byte[] Code128(string code);
        byte[] Code39(string code);
        byte[] Ean13(string code);
    }
}

