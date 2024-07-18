using ESC_POS_USB_NET.Extensions;
using ESC_POS_USB_NET.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESC_POS_USB_NET.Commands
{
    class FontSize : IFontSize
    {
        public byte[] Normal()
        {
            return new byte[] { 0x1B, 0x21, 0x00 };
        }

        public byte[] CustomSize(int width, int height)
        {
            int widthDec = (width - 1) * 16;
            int heightDec = height - 1;
            int sizeDec = widthDec + heightDec;
            
            return new byte[] { 0x1D, 0x21, byte.Parse(sizeDec.ToString()) };
        }
    }
}
