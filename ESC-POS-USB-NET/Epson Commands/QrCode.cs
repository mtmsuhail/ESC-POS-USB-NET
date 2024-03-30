using System.Collections.Generic;
using System.Text;
using ESC_POS_USB_NET.Enums;
using ESC_POS_USB_NET.Extensions;
using ESC_POS_USB_NET.Interfaces.Command;

namespace ESC_POS_USB_NET.EpsonCommands
{
    public class QrCode : IQrCode
    {
        // GS(k<func:167>
        private static byte[] Size(QrCodeSize size)
        {
            return new byte[] { 29, 40, 107, 3, 0, 49, 67 }
                .AddBytes(new[] { (size + 3).ToByte() });
        }

        // GS(k<func:165>
        // some, specially chinese printers don't support this command and print some random text instead.
        private IEnumerable<byte> ModelQr(QrCodeModel model)
        {
            return new byte[] { 29, 40, 107, 4, 0, 49, 65, (byte)model, 0 };
        }

        // GS(k<func:169>
        private IEnumerable<byte> ErrorQr(QrCodeErrorCorrection errCorr=QrCodeErrorCorrection.L)
        {
            return new byte[] { 29, 40, 107, 3, 0, 49, 69, (byte)errCorr };
        }

        private static IEnumerable<byte> StoreQr(string qrData)
        {
            var length = qrData.Length + 3;
            var b = (byte)(length % 256);
            var b2 = (byte)(length / 256);

            return new byte[] { 29, 40, 107 }
                .AddBytes(new[] { b })
                .AddBytes(new[] { b2 })
                .AddBytes(new byte[] { 49, 80, 48 });
        }

        private IEnumerable<byte> PrintQr()
        {
            return new byte[] { 29, 40, 107, 3, 0, 49, 81, 48 };
        }

        public byte[] Print(string qrData)
        {
            return Print(qrData, QrCodeSize.Size0);
        }

        public byte[] Print(string qrData, QrCodeSize qrCodeSize)
        {
            var list = new List<byte>();
            list.AddRange(ModelQr(QrCodeModel.Model2));
            list.AddRange(Size(qrCodeSize));
            list.AddRange(ErrorQr());
            list.AddRange(StoreQr(qrData));
            list.AddRange(Encoding.UTF8.GetBytes(qrData));
            list.AddRange(PrintQr());
            return list.ToArray();
        }

        /// <summary>
        /// Print QR code with additional options.
        /// noFun165 - Some, especially CN printers don't support `GS(k<func:165>` and print some text instead
        /// </summary>
        /// <param name="qrData"></param>
        /// <param name="qrCodeSize"></param>
        /// <param name="errorCorrection"></param>
        /// <param name="qrModel">QR Code model</param>
        /// <param name="NoFun165">Some, especially CN printers don't support `GS(k<func:165>` and print some text instead.</param>
        /// <returns></returns>
        public byte[] Print(string qrData, QrCodeSize qrCodeSize, QrCodeErrorCorrection errorCorrection, QrCodeModel qrModel=QrCodeModel.Model2, bool NoFun165=false)
        {
            var list = new List<byte>();
            if (!NoFun165) list.AddRange(ModelQr(qrModel));
            list.AddRange(Size(qrCodeSize));
            list.AddRange(ErrorQr(errorCorrection));
            list.AddRange(StoreQr(qrData));
            list.AddRange(Encoding.UTF8.GetBytes(qrData));
            list.AddRange(PrintQr());
            return list.ToArray();
        }
    }
}

