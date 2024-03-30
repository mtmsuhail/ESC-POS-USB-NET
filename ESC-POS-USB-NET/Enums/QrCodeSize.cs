namespace ESC_POS_USB_NET.Enums
{
    public enum QrCodeSize
    {
        // extended by more sizes
        Size000 = -2, //-2+3=1
        Size00=-1, // -1+3=2
        // original sizes
        Size0, //0+3=3
        Size1, //=4
        Size2, //=5
        // extended by more sizes
        Size3, //=6
        Size4, //=7
        Size5,  //=8
        Size6,  //=9
        Size7,  //=10
        Size8,  //=11
        Size9,  //=12
        Size10, //=13
        Size11, //=14
        Size12, //=15
        Size13, //=16

    }
    // no need for all those sizes (up to 16dots/module) :-) , I don't see use for biggers than Size5 (8dots) , but let it's have it...
    // https://github.com/mtmsuhail/ESC-POS-USB-NET/pull/22 :-D
}

