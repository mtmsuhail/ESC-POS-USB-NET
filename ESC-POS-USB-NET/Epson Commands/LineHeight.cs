using ESC_POS_USB_NET.Extensions;
using ESC_POS_USB_NET.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESC_POS_USB_NET.Epson_Commands
{
    class LineHeight:ILineHeight
    {
        public byte[] Normal()
        {
            return new byte[] { 27, '3'.ToByte(), 30 };
        }

        // Line Height may vary from 24 dots (3mm) to 8128 dots (1016mm)
        public byte[] SetLineHeight( byte height)
        {
            return new byte[] { 27, '3'.ToByte(), height };
        }
    }
}
