# Some detail about printers

This is a place to add some details about different printers and what they support or don't - especially those cheap ones from aliexpress/banggood/dhgate/gearbest/taobao/and so on....

Printer list:
- MPT-II (USB/BT), mobile, 57mm media, *(Version: `B58G_v2.5.2e`)*


----
## :printer: MPT-II [Version: `B58G_v2.5.2e`]

This is portable 57mm media thermal printer, it have USB (older models micro-USB, newer USB-C) & BT for communication. 

Pressing Feed & switching printer on will print test print & printer S/W info.

In Windows it's recognized as some Generic usb printer and windows won't install automatically drivers. I get it working with XP-58 recipe printer drivers from Xprinter.

#### **Specification:**
- Power: 1x 18650 3,7V/2600mAh Li-Ion
- media: recipe paper rolls width: 57mm , max. diameter about 40mm
- Print width: 48mm (5mm margins from both sides)
- Printhead resolution: 203dpi / 8dots per 1mm
- Printhead dots: 384
- Vertical step: 0,125mm (&#8539;mm ; same as print head resolution)
- print speed max: 60mm/s (that's probably paper feed speed :sweat_smile:)
- [System] Version: `B58G_v2.5.2e`
- [System] Modify: `Jun 23 2023gd`
- [Blue Tooth] Dev type: `040680`
- [Blue Tooth] Baut: `460800` (Baud)
- Default code page: CP437 (U.S. Standard Europe)
- Font:
  - 12x24 (Font A), 
  - 8x16 (Font B) - narrow variant - this font is not specified officially,
  - 8x16 (Font C), 
  - small (Font D) *(don't know what size, seems like it have 8x16dots)*
- Charset tables:
  - Default: 437 US/EU
  - It might support up to 44 codepages (ISO8859-1/2/3..9/PC850/WPC1250/1251/...)
- Barcodes:
  - EAN-13 - you can supply it 12 or 13 digits (Lib require 13)
  - CODE-39,
  - CODE-128,
  - EAN-8,
  - INTERLEAVED 25 (ITF),
  - CODEBAR,
  - CODE93,
  - UPC-A & E,
  - QRCode - :warning: MPT-II don't support command "QrCode Model".
- CPU: Barrot BR8551 (DayStar-Elec) - 32bit RISC @96MHz with BT5.2, 512KiB flash, 96KiB RAM, support OTA BT/UART, 29 GPIO, QFN-48 6x6mm

*I did not misspelled some words - those are printed that way from printer*

#### :small_orange_diamond: **Printer 'quirks':**

If printer receive unknown command it will either: ignore it, print some random text or hang-up .

Printer have issue with one command from QrCode command set - it don't support command "QrCode Model" (`GS(k<func:165>`) and print some text (e.g.: `2`) instead of this command.

:warning: If you don't set in library `DotsInLine` for your printer and it's bigger than your printhead resolution(width in dots) then you'll get garbage in prints mixed with strips of your image.

You can send data directly to printer skipping windows print-subsystem, use USB Endpoint 4 and USB URB transfer to send data to the printer. This might be easily done in Linux but in Windows it's PITA to do :expressionless:

----


#EOF