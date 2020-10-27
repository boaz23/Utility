namespace Utility.Interop.Native.Types
{
    public enum SICHINTF : int
    {
        SICHINT_DISPLAY                       = 0x00000000,                 // iOrder based on display in a folder view
        SICHINT_ALLFIELDS                     = unchecked((int)0x80000000), // exact instance compare
        SICHINT_CANONICAL                     = 0x10000000,                 // iOrder based on canonical name (better performance)
        SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL = 0x20000000,
    }
}