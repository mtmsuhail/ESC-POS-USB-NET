using ESC_POS_USB_NET.Extensions;
using ESC_POS_USB_NET.Interfaces.Command;

namespace ESC_POS_USB_NET.EpsonCommands
{
    public class FontWidth : IFontWidth
    {
        public byte[] Normal()
        {
            return new byte[] { 27, '!'.ToByte(), 0 };
        }

        public byte[] DoubleWidth2()
        {
            return new byte[] { 29, '!'.ToByte(), 16 };
        }

        public byte[] DoubleWidth3()
        {
            return new byte[] { 29, '!'.ToByte(), 32 };
        }
    }
}

