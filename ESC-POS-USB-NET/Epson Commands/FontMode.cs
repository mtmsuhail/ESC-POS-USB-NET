using ESC_POS_USB_NET.Enums;
using ESC_POS_USB_NET.Extensions;
using ESC_POS_USB_NET.Interfaces.Command;

namespace ESC_POS_USB_NET.EpsonCommands
{
    public class FontMode : IFontMode
    {

        public byte[] Bold(string value)
        {
            return Bold(PrinterModeState.On)
                .AddBytes(value)
                .AddBytes(Bold(PrinterModeState.Off))
                .AddLF();
        }

        public byte[] Bold(PrinterModeState state)
        {
            return state == PrinterModeState.On
                ? new byte[] { 27, 'E'.ToByte(), 1 }
                : new byte[] { 27, 'E'.ToByte(), 0 };
        }

        public byte[] Underline(string value)
        {
            return Underline(PrinterModeState.On)
                .AddBytes(value)
                .AddBytes(Underline(PrinterModeState.Off))
                .AddLF();
        }

        public byte[] Underline(PrinterModeState state)
        {
            return state == PrinterModeState.On
                ? new byte[] { 27, '-'.ToByte(), 1 }
                : new byte[] { 27, '-'.ToByte(), 0 };
        }

        public byte[] Expanded(string value)
        {
            return Expanded(PrinterModeState.On)
                .AddBytes(value)
                .AddBytes(Expanded(PrinterModeState.Off))
                .AddLF();
        }

        public byte[] Expanded(PrinterModeState state)
        {
            return state == PrinterModeState.On
                ? new byte[] { 29, '!'.ToByte(), 16 }
                : new byte[] { 29, '!'.ToByte(), 0 };
        }

        public byte[] Condensed(string value)
        {
            return Condensed(PrinterModeState.On)
                .AddBytes(value)
                .AddBytes(Condensed(PrinterModeState.Off))
                .AddLF();
        }

        public byte[] Condensed(PrinterModeState state)
        {
            return state == PrinterModeState.On
                ? new byte[] { 27, '!'.ToByte(), 1 }
                : new byte[] { 27, '!'.ToByte(), 0 };
        }
        public byte[] Font(string value, Fonts state)
        {
            return Font(state)
           .AddBytes(value)
           .AddBytes(Font(Fonts.FontA))
           .AddLF();
        }

        public byte[] Font(Fonts state)
        {
            byte fnt = 0;
            switch (state)
            {
                case Fonts.FontA:
                    {
                        fnt = 0;
                        break;
                    }

                case Fonts.FontB:
                    {
                        fnt = 1;
                        break;
                    }

                case Fonts.FontC:
                    {
                        fnt =2;
                        break;
                    }

                case Fonts.FontD:
                    {
                        fnt = 3;
                        break;
                    }

                case Fonts.FontE:
                    {
                        fnt = 4;
                        break;
                    }

                case Fonts.SpecialFontA:
                    {
                        fnt = 5;
                        break;
                    }

                case Fonts.SpecialFontB:
                    {
                        fnt = 6;
                        break;
                    }
            }
            return new byte[] { 27, 'M'.ToByte(), fnt };
        }
    }
}

