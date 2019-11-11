<p align="center">
    <img src="https://raw.githubusercontent.com/mtmsuhail/ESC-POS-USB-NET/master/Icon/Icon.png" width="318px" alt="ESC-POS-USB-NET Logo" />
</p>
<h3 align="center">Printing Epson ESC/POS made simple and fast.</h3>
<p align="center">The most advanced open-source to build powerful thermal printing solution with no effort.</p>
<br />
<p align="center">
  <a href="https://raw.githubusercontent.com/mtmsuhail/ESC-POS-USB-NET/master/LICENSE">
    <img src="https://img.shields.io/github/license/mtmsuhail/ESC-POS-USB-NET" />
  </a>
  <a href="https://github.com/mtmsuhail/ESC-POS-USB-NET/issues">
    <img src="https://img.shields.io/github/issues/mtmsuhail/ESC-POS-USB-NET" />
  </a>
</p>

<br>

ESC-POS-USB-NET is a free and open source .NET (C#) Implementation of the Epson ESC/POS Printing using USB Device Driver.

- **Focus on your business logic**. With ESC-POS-USB-NET, you should focus on your business logic. we do the printing logic.
- **Customizable**. You can quickly build your logic by fully customizing the code to fit your needs perfectly.



## Getting Started

follow the steps below:

### ⏳ Installation

Install Strapi with this **Quickstart** command to create a Strapi project instantly:

- (Use **nuget** package manager to install (recommended))

```bash
Install-Package ESC-POS-USB-NET
```

**or**

- (Use .Net Cli to install)

```bash
dotnet add package ESC-POS-USB-NET
```

This command install ESC-POS-USB-NET with your project.

Enjoy 🎉




### 🖐 Example Using C#

**Test Print**:

```csharp
Printer printer = new Printer("Printer Name");
printer.TestPrinter();
printer.FullPaperCut();
printer.PrintDocument();
```
You can find printer name from (Windows):  Control Panel->Hardware and Sound->Devices and Printers-> Your Printer's Name

**Print Image**:

```csharp
Printer printer = new Printer("Printer Name");
Bitmap image =new Bitmap ( Bitmap.FromFile("Icon.bmp"));
printer.Image(image);
printer.FullPaperCut();
printer.PrintDocument();
```



### 🖐 Requirements

**Supported operating systems**:

- Ubuntu 18.04
- Mac O/S
- Windows 10

(Please note that ESC-POS-USB-NET may work on other operating systems, but these are not tested nor officially supported at this time.)

**Dependencies:**

- .NETStandard 2.0
- System.Drawing.Common (>= 4.6.0)

**We recommend always using the latest version of ESC-POS-USB-NET to start your new projects**.

This project is currently in **Under Development**. Significant breaking changes are unlikely at this stage of the project, but using the latest version ensures you have all the latest features and updates. New releases are usually shipped every two weeks to fix/enhance the project.

## Features

- **Alignment:** Left, Right and Center alignment.
- **BarCode:** Code128, Code39, Ean13 barcodes are supported.
- **Drawer:** Drawer Open facility.
- **Font Mode:** Supported Bold, Underline, Expanded, Condensed modes.
- **Change Font:** Change font to device specified FontA, FontB, FontC, FontD, FontE, SpecialFontA and SpecialFontB.
- **Font Width:** Supported Normal, DoubleWidth2 and DoubleWidth3.
- **Image:** Print BMP Image.
- **Paper Cut:** Cut paper with Full & Partial Cut.
- **QrCode:** Support 2D barcode (QrCode).

## Contributing

We welcome open an issue if you have any trouble.

## License

[MIT License](https://raw.githubusercontent.com/mtmsuhail/ESC-POS-USB-NET/master/LICENSE) Copyright (c) 2019 MTM Suhail.
