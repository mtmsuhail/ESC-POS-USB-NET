using ESC_POS_USB_NET.Enums;
using System.Drawing;

namespace ESC_POS_USB_NET.Interfaces.Printer
{
    internal interface IPrinter
    {
        int ColsNomal { get; }
        int ColsCondensed { get; }
        int ColsExpanded { get; }
        void PrintDocument();
        void Append(string value);
        void Append(byte[] value);
        void AppendWithoutLf(string value);
        void NewLine();
        void NewLines(int lines);
        void Clear();
        void Separator(char speratorChar = '-');
        void AutoTest();
        void TestPrinter();
        void Font(string value, Fonts state);
        void BoldMode(string value);
        void BoldMode(PrinterModeState state);
        void UnderlineMode(string value);
        void UnderlineMode(PrinterModeState state);
        void ExpandedMode(string value);
        void ExpandedMode(PrinterModeState state);
        void CondensedMode(string value);
        void CondensedMode(PrinterModeState state);
        void NormalWidth();
        void DoubleWidth2();
        void DoubleWidth3();
        void NormalLineHeight();
        void SetLineHeight(byte height);
        void AlignLeft();
        void AlignRight();
        void AlignCenter();
        void FullPaperCut();
        void PartialPaperCut();
        void OpenDrawer();
        void Image(Bitmap image);
        void QrCode(string qrData);
        void QrCode(string qrData, QrCodeSize qrCodeSize);
        void Code128(string code, Positions positions);
        void Code39(string code, Positions positions);
        void Ean13(string code, Positions positions);
        void InitializePrint();
    }
}

