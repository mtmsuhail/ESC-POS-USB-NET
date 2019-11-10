using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ESC_POS_USB_NET.Helper
{
    internal class RawPrinterHelper
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
        }

        #region Declaration Dll

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
            ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter,
            IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
            ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level,
            [In] [MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        #endregion

        #region Methods

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the printer queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount)
        {
            int dwError = 0, dwWritten = 0;
            var hPrinter = new IntPtr(0);
            var di = new DOCINFOA();
            var bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "VIP RAW PrinterDocument";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
                dwError = Marshal.GetLastWin32Error();

            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            var fs = new FileStream(szFileName, FileMode.Open);

            // Create a BinaryReader on the file.
            var br = new BinaryReader(fs);

            // Dim an array of bytes big enough to hold the file's contents.
            var bytes = new byte[fs.Length];
            var bSuccess = false;

            // Your unmanaged pointer.
            var pUnmanagedBytes = new IntPtr(0);
            var nLength = Convert.ToInt32(fs.Length);

            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }

        public static bool SendBytesToPrinter(string szPrinterName, byte[] data)
        {
            var pUnmanagedBytes = Marshal.AllocCoTaskMem(data.Length); // Allocate unmanaged memory
            Marshal.Copy(data, 0, pUnmanagedBytes, data.Length); // copy bytes into unmanaged memory
            var retval = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, data.Length);
            Marshal.FreeCoTaskMem(pUnmanagedBytes); // Free the allocated unmanaged memory

            return retval;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            // How many characters are in the string?
            var dwCount = szString.Length;

            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            var pBytes = Marshal.StringToCoTaskMemAnsi(szString);

            // Send the converted ANSI string to the printer.
            var result = SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);

            return result;
        }

        //if you want a wrapper function for you strings :
        public static bool SendAsciiToPrinter(string szPrinterName, string data)
        {
            var retval = false;

            //if  you are using UTF-8 and get wrong values in qrcode printing, you must use ASCII instead.
            //retval = SendBytesToPrinter(szPrinterName, Encoding.UTF8.GetBytes(data));
            retval = SendBytesToPrinter(szPrinterName, Encoding.ASCII.GetBytes(data));

            return retval;
        }

        #endregion
    }
}

