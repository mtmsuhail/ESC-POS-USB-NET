## # commit: #6842df1 (2024-03-30 14:53GMT+1)
More PRs combined into this one...

Added [file for some details about different printers](SPECIFIC-PRINTER-INFO.md) .

#### Changes:
- Added more sizes to enum `enums/QrCodeSize.cs`: 
  - Added `Size6`..`Size13` = `9dots`..`16dots`.
- `Epson Commands/FontMode.cs` added:
  - `Reverse(PrinterModeState)` - set Reverse mode (allow to print text inverted/negative: black background/white text)
  - `Reverse(string)` - print text in Reverse mode (inverted/negative), and return back to normal mode,
  - `ReverseNoLF(string)` - print text in Reverse mode (inverted/negative), and return back to normal mode, but don't add `LF` (new line) at end of text.
- `Interfaces/Command/IFontMode.cs` - Updated interfaces definitions.
- `Printer.cs`:
  - Added functions for Reverse mode (inverted/negative print) 
    - `ReverseMode` ,
    - `ReverseModeNoLF` ,
  - Updated `TestPrint` for Reverse test prints,
  - Added function `Image` with `scaleToWidth` parameter,
  - Added another function `Code128(string)` that have only one parameter *(VS complains that it can't decide which function to pick if it have one parameter)*
- `Interfaces/IPrint.cs`
  - Updated for Reverse routines definitions,
  - updated for `Image` new function,
  - updated for `Code128` new function,
- `Epson Commands/Image.cs` updated:
  - function `GetBitmapData`:
    - added parameter `scaleToWidth` (default **true**), if `false` image won't be up-scaled to printhead dot count (printing width), **BUT:** image will be still down-scaled if is wider that printhead print width (printhead dot count).
  - function `IImage.Print`:
    - added parameter `scaleToWidth` with default **true** value.

-----
## # commit: #6aabcac (2024-03-29 23:55GMT+1)
Modified (extended) multiple barcode function for more settings. Also changed image rendering function to be more universal.

#### Changes:
- Added enums for BarCodes `enums/BarCode.cs`:
  - `BarCodeCode128Charset` - Charsets for Code-128 (Inspired by: https://github.com/mtmsuhail/ESC-POS-USB-NET/pull/38 ):
    - `A` - charset A,
    - `B` - charset B,
    - `C` - charset C.
  - `BarCodeBarWidth` - To set thin-bar width (barcode modulo):
    - `Width0125` - thin bar of width 1dot (0.125mm),
    - `Width0250` - thin bar of width 2dots (0.250mm) - **default width**,
    - `Width0375` - thin bar of width 3dots (0.375mm),
    - `Width0500` - thin bar of width 4dots (0.500mm),
- Added enums for QRCode
  - `enums/QrCodeError.cs` - for error level correction:
    - `L` = 48 - default,
    - `M` = 49,
    - `Q` = 50,
    - `H` = 51.
  - `enums/QrCodeModel.cs` - for different QrCode models, :warning: some (Chinese especially) printers don't support this. *(will be explained in functions description)*:
    - `Model1` = 49,
    - `Model2` = 50,
    - `Model3Micro` = 51, *Micro QR* ( [Epson: GS(k<Function 165>](https://download4.epson.biz/sec_pubs/pos/reference_en/escpos/gs_lparen_lk_fn165.html) )
  - `enums/QrCodeSize.cs` - for different code sizes (why not if it's possible :grin: ):
    - `Size000` - modulo 1 (1dot) *for ppl having hawk-eyes :laughing:*,
    - `Size00` - modulo 2 (2dots),
    - `Size0` - modulo 3 (3dots) *(original size value)*,
    - `Size1` - modulo 4 (4dots) *(original size value)*,
    - `Size2` - modulo 5 (5dots) *(original size value)*,
    - `Size3` - modulo 6 (6dots),
    - `Size4` - modulo 7 (7dots),
    - `Size5` - modulo 8 (8dots).  
- added functions:
  - `Epson Commands/BarCode.cs`:
    - `Code128` that can take `byte[] code` instead of string (**Charset=C**),
    - `Code128` with options: 
      - `startCharset` enum: `BarCodeCode128Charset`, 
      - `barWidth` enum: `BarCodeBarWidth`, 
      - `codeHeight` byte - height in dots, default `50`=6.25mm.
    - `Code39` with options: 
      - `barWidth` enum: `BarCodeBarWidth`, 
      - `codeHeight` byte - height in dots, default `50`=6.25mm.
    - `Ean13` with options: 
      - `barWidth` enum: `BarCodeBarWidth`, 
      - `codeHeight` byte - height in dots, default `50`=6.25mm.
  - `Epson Commands/Image.cs`:
    - Added to `Print` parameter that allow changing `DotsInLine` more easily (not hardcoded in lib). This parameter define how image is resized and must be same as your printer printhead dot count.
  - `Epson Commands/QrCode.cs`:
    - `Print` with options: 
      - `QrCodeErrorCorrection` enum, 
      - `QrCodeModel` enum, 
      - `NoFun165` bool. 
      :warning: :warning: :warning: There are some (Chinese) printers that don't digest command `GS(k<func:165>` **Set QrCode Model** and instead ignoring it , they print some text (e.g.: `MPT-II` print text `2` :unamused: ) - this is the reason for `NoFun165` parameter - it'll suppress adding this command.
    - added some comments,
  - `Interfaces/Command/*.cs` - updated with new function definitions.
  - `Interfaces/Printer/IPrinter.cs` - updated with new function definitions.
  - `Printer.cs` 
    - added **read-only** property `Buffer` to take a peek into commands buffer that's going to be printed,
    - added property `DotsInLine` to set printer printhead dots count - this is needed by `Image` function to properly render image. Default `576`.
    - added function for extended Barcodes routines (`Ean13`,`Code128`,`Code39`,`QrCode.Print`).

----
## # commit: #e039c3d (2024-03-29 23:43GMT+1)
Modified csproj file so VS will build not only `netstandard2.0` but also `net45` binary too. 
This should make things easier for some people that don't want just to add bunch of other libraries (related to `netstandard2.0`) to only add this one while using netFramework 4.5 or newer.

---
## # source commit: #ff50466