namespace ESC_POS_USB_NET.Interfaces.Command
{
    internal interface IAlignment
    {
        byte[] Left();
        byte[] Right();
        byte[] Center();
    }
}

