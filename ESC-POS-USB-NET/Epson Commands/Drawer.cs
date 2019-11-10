using ESC_POS_USB_NET.Interfaces.Command;

namespace ESC_POS_USB_NET.EpsonCommands
{
    public class Drawer : IDrawer
    {
        public byte[] Open()
        {
            return new byte[] { 27, 112, 0, 60, 120 };
        }
    }
}

