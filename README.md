<p align="center">
    <img src="https://raw.githubusercontent.com/mtmsuhail/ESC-POS-USB-NET/master/Icon/Icon.png" width="218px" alt="ESC-POS-USB-NET Logo" />
</p>
<h1 align="center">Printing ESC/POS Made Simple & Fast.</h1>
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

Use this **Quickstart** command to install in your project :

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




### ❤️ Example Using C#

Import ESC_POS_USB_NET Printer Class:

```csharp
using ESC_POS_USB_NET.Printer;
```

You can find printer name from (Windows):  Control Panel->Hardware and Sound->Devices and Printers-> Your Printer's Name

**Test Print**:

```csharp
Printer printer = new Printer("Printer Name");
printer.TestPrinter();
printer.FullPaperCut();
printer.PrintDocument();
```

**Print Image**:

```csharp
Printer printer = new Printer("Printer Name");
Bitmap image =new Bitmap ( Bitmap.FromFile("Icon.bmp"));
printer.Image(image);
printer.FullPaperCut();
printer.PrintDocument();
```

**Print Barcodes**:

```csharp
Printer printer = new Printer("Printer Name");
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
```

**Open Drawer**:

```csharp
Printer printer = new Printer("Printer Name");
printer.OpenDrawer();
printer.PrintDocument();
```

**Different Types of Separators**:

```csharp
Printer printer = new Printer("Printer Name");
printer.Separator(); // Deafult
printer.Separator('.'); // .
printer.Separator('|'); // |
printer.Separator('='); // =
printer.Separator('+'); // +
printer.Separator('*'); // *
printer.Separator('^'); // ^
printer.Separator('~'); // ~
printer.Separator(':'); // :
printer.Separator('#'); // #
printer.FullPaperCut();
printer.PrintDocument();
```

**Typography Test**:

```csharp
Printer printer = new Printer("Printer Name");
printer.Append("NORMAL - 48 COLUMNS");
printer.Append("1...5...10...15...20...25...30...35...40...45.48");
printer.Separator();
printer.Append("Text Normal");
printer.BoldMode("Bold Text");
printer.UnderlineMode("Underlined text");
printer.Separator();
printer.ExpandedMode(PrinterModeState.On);
printer.Append("Expanded - 23 COLUMNS");
printer.Append("1...5...10...15...20..23");
printer.ExpandedMode(PrinterModeState.Off);
printer.Separator();
printer.CondensedMode(PrinterModeState.On);
printer.Append("Condensed - 64 COLUMNS");
printer.Append("1...5...10...15...20...25...30...35...40...45...50...55...60..64");
printer.CondensedMode(PrinterModeState.Off);
printer.Separator();
printer.DoubleWidth2();
printer.Append("Font Width 2");
printer.DoubleWidth3();
printer.Append("Font Width 3");
printer.NormalWidth();
printer.Append("Normal width");
printer.Separator();
printer.AlignRight();
printer.Append("Right aligned text");
printer.AlignCenter();
printer.Append("Center-aligned text");
printer.AlignLeft();
printer.Append("Left aligned text");
printer.Separator();
printer.Font("Font A", Fonts.FontA);
printer.Font("Font B", Fonts.FontB);
printer.Font("Font C", Fonts.FontC);
printer.Font("Font D", Fonts.FontD);
printer.Font("Font E", Fonts.FontE);
printer.Font("Font Special A", Fonts.SpecialFontA);
printer.Font("Font Special B", Fonts.SpecialFontB);
printer.Separator();
printer.InitializePrint();
printer.SetLineHeight(24);
printer.Append("This is first line with line height of 30 dots");
printer.SetLineHeight(40);
printer.Append("This is second line with line height of 24 dots");
printer.Append("This is third line with line height of 40 dots");
printer.NewLines(3);
printer.Append("End of Test :)");
printer.Separator();
printer.FullPaperCut();
printer.PrintDocument();
```

## 🎈 Features

- **Alignment:** Left, Right and Center alignment.
- **BarCode:** Code128, Code39, Ean13 barcodes are supported.
- **Drawer:** Drawer Open facility.
- **Font Mode:** Supported Bold, Underline, Expanded, Condensed modes.
- **Change Font:** Change font to device specified FontA, FontB, FontC, FontD, FontE, SpecialFontA and SpecialFontB.
- **Font Width:** Supported Normal, DoubleWidth2 and DoubleWidth3.
- **Image:** Print BMP Image.
- **Paper Cut:** Cut paper with Full & Partial Cut.
- **QrCode:** Support 2D barcode (QrCode).

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



## 🧑‍🤝‍🧑 Contributing

We welcome open an issue if you have any trouble.

## 📝 License

[MIT License](https://raw.githubusercontent.com/mtmsuhail/ESC-POS-USB-NET/master/LICENSE) Copyright (c) 2019 MTM Suhail.
