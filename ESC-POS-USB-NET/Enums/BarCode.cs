using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESC_POS_USB_NET.Enums
{
    // Insipired by https://github.com/mtmsuhail/ESC-POS-USB-NET/pull/38/commits/fc5cb17a798093bbf8e1a376e35051f1fc1a9ff7
    public enum BarCodeCode128Charset
    {
        A = 'A',
        B = 'B',
        C = 'C'
    }

    /// <summary>
    /// Bar code thin-bar width
    /// </summary>
    public enum BarCodeBarWidth
    {
        Width0125 = 1,
        /// <summary>
        /// Default width
        /// </summary>
        Width0250 = 2,
        Width0375 = 3,
        Width0500 = 4
    }
}
