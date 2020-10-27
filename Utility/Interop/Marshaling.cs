using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Utility.Interop
{
    public static class Marshaling
    {
        public delegate IntPtr Alloc(int size);
        public delegate IntPtr Alloc<T>();
        public delegate IntPtr AllocStruct<T>(out int structSize);

        public delegate void FreePtr(IntPtr ptr);

        public static void FreeHGlobal(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        public static void FreeCoTaskMem(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(ptr);
            }
        }

        public static IntPtr AllocHGlobal<T>(out int structSize)
        {
            structSize = Marshal.SizeOf<T>();
            return Marshal.AllocHGlobal(structSize);
        }
        public static IntPtr AllocHGlobal<T>()
        {
            return Marshal.AllocHGlobal(Marshal.SizeOf<T>());
        }

        public static IntPtr AllocCoTaskMem<T>(out int structSize)
        {
            structSize = Marshal.SizeOf<T>();
            return Marshal.AllocCoTaskMem(structSize);
        }
        public static IntPtr AllocCoTaskMem<T>()
        {
            return Marshal.AllocCoTaskMem(Marshal.SizeOf<T>());
        }

        public static void CopyToByteArray(IntPtr ptr, byte[] buffer)
        {
            Marshal.Copy(ptr, buffer, 0, buffer.Length);
        }

        public static byte[] ToByteArray(IntPtr ptr, int count)
        {
            return ToByteArrayCore(ptr, count, 0, count);
        }
        public static byte[] ToByteArray(IntPtr ptr, int size, int bufferOffset, int count)
        {
            return ToByteArrayCore(ptr, size, bufferOffset, count);
        }
        private static byte[] ToByteArrayCore(IntPtr ptr, int size, int bufferOffset, int count)
        {
            byte[] buffer = new byte[size];
            Marshal.Copy(ptr, buffer, bufferOffset, count);
            return buffer;
        }

        public static void CopyToPtr(byte[] buffer, IntPtr ptr)
        {
            Marshal.Copy(buffer, 0, ptr, buffer.Length);
        }

        public static IntPtr ToPtrHGlobal(byte[] buffer)
        {
            return ToPtrHGlobal(buffer, 0, buffer.Length);
        }
        [HandleProcessCorruptedStateExceptions]
        public static IntPtr ToPtrHGlobal(byte[] buffer, int bufferOffset, int count)
        {
            return ToPtr(buffer, bufferOffset, count, Marshal.AllocHGlobal, FreeHGlobal);
        }
        public static IntPtr ToPtrCoTaskMem(byte[] buffer)
        {
            return ToPtrCoTaskMem(buffer, 0, buffer.Length);
        }
        [HandleProcessCorruptedStateExceptions]
        public static IntPtr ToPtrCoTaskMem(byte[] buffer, int bufferOffset, int count)
        {
            return ToPtr(buffer, bufferOffset, count, Marshal.AllocCoTaskMem, FreeCoTaskMem);
        }
        [HandleProcessCorruptedStateExceptions]
        private static IntPtr ToPtr(byte[] buffer, int bufferOffset, int count, Alloc alloc, FreePtr free)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = alloc(count);
                Marshal.Copy(buffer, bufferOffset, ptr, count);
                return ptr;
            }
            catch
            {
                free(ptr);
                throw;
            }
        }

        public static IntPtr ToPtrHGlobal<T>(T structure)
        {
            return ToPtrHGlobal(structure, true);
        }
        [HandleProcessCorruptedStateExceptions]
        public static IntPtr ToPtrHGlobal<T>(T structure, bool fDeleteOld)
        {
            return ToPtr(structure, fDeleteOld, AllocHGlobal<T>, FreeHGlobal);
        }
        public static IntPtr ToPtrCoTaskMem<T>(T structure)
        {
            return ToPtrCoTaskMem(structure, true);
        }
        [HandleProcessCorruptedStateExceptions]
        public static IntPtr ToPtrCoTaskMem<T>(T structure, bool fDeleteOld)
        {
            return ToPtr(structure, fDeleteOld, AllocCoTaskMem<T>, FreeCoTaskMem);
        }
        [HandleProcessCorruptedStateExceptions]
        public static IntPtr ToPtr<T>(T structure, bool fDeleteOld, Alloc<T> alloc, FreePtr free)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = alloc();
                Marshal.StructureToPtr(structure, ptr, fDeleteOld);
                return ptr;
            }
            catch
            {
                free(ptr);
                throw;
            }
        }

        public static byte[] ToByteArray<T>(T structure)
        {
            return ToByteArray(structure, true);
        }
        public static byte[] ToByteArray<T>(T structure, bool fDeleteOld)
        {
            return ToByteArray(structure, fDeleteOld, AllocHGlobal<T>, FreeHGlobal);
        }
        [HandleProcessCorruptedStateExceptions]
        private static byte[] ToByteArray<T>(T structure, bool fDeleteOld, AllocStruct<T> alloc, FreePtr free)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = alloc(out int structSize);
                Marshal.StructureToPtr(structure, ptr, fDeleteOld);
                return ToByteArray(ptr, structSize);
            }
            finally
            {
                free(ptr);
            }
        }

        public static T ToStructure<T>(byte[] buffer)
        {
            return ToStructure<T>(buffer, 0);
        }
        public static T ToStructure<T>(byte[] buffer, int bufferOffset)
        {
            return ToStructure<T>(buffer, bufferOffset, AllocHGlobal<T>, FreeHGlobal);
        }
        [HandleProcessCorruptedStateExceptions]
        public static T ToStructure<T>(byte[] buffer, int bufferOffset, AllocStruct<T> alloc, FreePtr free)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = alloc(out int structSize);
                Marshal.Copy(buffer, bufferOffset, ptr, structSize);
                return Marshal.PtrToStructure<T>(ptr);
            }
            finally
            {
                free(ptr);
            }
        }
    }
}