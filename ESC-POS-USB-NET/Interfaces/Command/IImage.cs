using System.Drawing;

namespace ESC_POS_USB_NET.Interfaces.Command
{
    internal interface IImage
    {
        

        byte[] Print(Bitmap image, int DotsInLine, bool scaleToWidth=true);
    }
}
