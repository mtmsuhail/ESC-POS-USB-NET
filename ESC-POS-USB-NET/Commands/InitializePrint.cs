using ESC_POS_USB_NET.Extensions;
using ESC_POS_USB_NET.Interfaces.Command;

namespace ESC_POS_USB_NET.Commands
{
    public class InitializePrint : IInitializePrint
    {
        public byte[] Initialize()
        {
            return new byte[] { 27, '@'.ToByte() };
        }
    }
}

