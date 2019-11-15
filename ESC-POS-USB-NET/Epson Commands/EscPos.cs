using ESC_POS_USB_NET.Enums;
using ESC_POS_USB_NET.Epson_Commands;
using ESC_POS_USB_NET.Extensions;
using ESC_POS_USB_NET.Interfaces.Command;

namespace ESC_POS_USB_NET.EpsonCommands
{
    internal class EscPos : IPrintCommand
    {
        public IFontMode FontMode { get; set; }
        public IFontWidth FontWidth { get; set; }
        public IAlignment Alignment { get; set; }
        public IPaperCut PaperCut { get; set; }
        public IDrawer Drawer { get; set; }
        public IQrCode QrCode { get; set; }
        public IBarCode BarCode { get; set; }
        public IInitializePrint InitializePrint { get; set; }
        public IImage Image { get; set; }
        public ILineHeight  LineHeight { get; set; }
        public int ColsNomal => 48;
        public int ColsCondensed => 64;
        public int ColsExpanded => 24;        

        public EscPos()
        {
            FontMode = new FontMode();
            FontWidth = new FontWidth();
            Alignment = new Alignment();
            PaperCut = new PaperCut();
            Drawer = new Drawer();
            QrCode = new QrCode();
            BarCode = new BarCode();
            Image = new Image();
            LineHeight = new LineHeight();
            InitializePrint = new InitializePrint();
        }

        public byte[] Separator(char speratorChar= '-')
        {
            return FontMode.Condensed(PrinterModeState.On)
                .AddBytes(new string(speratorChar, ColsCondensed))
                .AddBytes(FontMode.Condensed(PrinterModeState.Off))
                .AddCrLF();
        }

        public byte[] AutoTest()
        {
            return new byte[] { 29, 40, 65, 2, 0, 0, 2 };
        }

    }
}

