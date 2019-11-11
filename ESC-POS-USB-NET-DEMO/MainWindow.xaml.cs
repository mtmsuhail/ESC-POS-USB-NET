using ESC_POS_USB_NET.Printer;
using System;
using System.Drawing;
using System.Windows;

namespace ESC_POS_USB_NET_DEMO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Printer printer = new Printer(txtPrinterName.Text);
            printer.TestPrinter();
            printer.FullPaperCut();
            printer.PrintDocument();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Printer printer = new Printer(txtPrinterName.Text);
            Bitmap image =new Bitmap ( Bitmap.FromFile("Icon.bmp"));
            printer.Image(image);
            printer.FullPaperCut();
            printer.PrintDocument();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Printer printer = new Printer(txtPrinterName.Text);
            printer.Append("Code 128");
            printer.Code128("123456789");
            printer.Separator();
            printer.Append("Code39");
            printer.Code39("123456789");
            printer.Separator();
            printer.Append("Ean13");
            printer.Ean13("1234567891231");
            printer.FullPaperCut();
            printer.PrintDocument();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Printer printer = new Printer(txtPrinterName.Text);
            printer.OpenDrawer();
            printer.PrintDocument();
        }
    }
}
