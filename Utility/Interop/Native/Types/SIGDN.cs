namespace Utility.Interop.Native.Types
{
    public enum SIGDN : int
    {
        NORMALDISPLAY               = 0x00000000,                 // SHGDN_NORMAL
        PARENTRELATIVEPARSING       = unchecked((int)0x80018001), // SHGDN_INFOLDER | SHGDN_FORPARSING
        DESKTOPABSOLUTEPARSING      = unchecked((int)0x80028000), // SHGDN_FORPARSING
        PARENTRELATIVEEDITING       = unchecked((int)0x80031001), // SHGDN_INFOLDER | SHGDN_FOREDITING
        DESKTOPABSOLUTEEDITING      = unchecked((int)0x8004C000), // SHGDN_FORPARSING | SHGDN_FORADDRESSBA
        FILESYSPATH                 = unchecked((int)0x80058000), // SHGDN_FORPARSING
        URL                         = unchecked((int)0x80068000), // SHGDN_FORPARSING
        PARENTRELATIVEFORADDRESSBAR = unchecked((int)0x8007C001), // SHGDN_INFOLDER | SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
        PARENTRELATIVE              = unchecked((int)0x80080001), // SHGDN_INFOLDER
        PARENTRELATIVEFORUI         = unchecked((int)0x80094001), // SHGDN_INFOLDER | SHGDN_FORADDRESSBAR
    }
}