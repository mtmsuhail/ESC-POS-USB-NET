using System;
using System.Collections.Generic;
using System.Text;

namespace ESC_POS_USB_NET.Interfaces.Command
{
    interface IFontSize
    {
        byte[] Normal();
        byte[] CustomSize(int width, int height);
    }
}
