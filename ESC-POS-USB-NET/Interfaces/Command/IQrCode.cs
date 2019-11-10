using ESC_POS_USB_NET.Enums;

namespace ESC_POS_USB_NET.Interfaces.Command
{
    internal interface IQrCode
    {
        byte[] Print(string qrData);
        byte[] Print(string qrData, QrCodeSize qrCodeSize);
    }
}

