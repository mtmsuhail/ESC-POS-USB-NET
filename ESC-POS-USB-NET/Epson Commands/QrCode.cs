using System.Collections.Generic;
using System.Text;
using ESC_POS_USB_NET.Enums;
using ESC_POS_USB_NET.Extensions;
using ESC_POS_USB_NET.Interfaces.Command;

namespace ESC_POS_USB_NET.EpsonCommands
{
    public class QrCode : IQrCode
    {
        private static byte[] Size(QrCodeSize size)
        {
            return new byte[] { 29, 40, 107, 3, 0, 49, 67 }
                .AddBytes(new[] { (size + 3).ToByte() });
        }

        private IEnumerable<byte> ModelQr()
        {
            return new byte[] { 29, 40, 107, 4, 0, 49, 65, 50, 0 };
        }

        private IEnumerable<byte> ErrorQr()
        {
            return new byte[] { 29, 40, 107, 3, 0, 49, 69, 48 };
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
            list.AddRange(ModelQr());
            list.AddRange(Size(qrCodeSize));
            list.AddRange(ErrorQr());
            list.AddRange(StoreQr(qrData));
            list.AddRange(Encoding.UTF8.GetBytes(qrData));
            list.AddRange(PrintQr());
            return list.ToArray();
        }
    }
}

