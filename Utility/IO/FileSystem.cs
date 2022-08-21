using System;
using System.IO;
using Utility.Interop.Native;

using static Utility.NumbersOperators;

namespace Utility.IO
{
    public static class FileSystem
    {
        public static void CheckPathArgument(string path, string argumentName)
        {
            if (path.IsNullOrWhiteSpace() || path.IndexOfAny(Path.GetInvalidPathChars()) > -1)
            {
                throw new ArgumentException("Invalid path specified.", argumentName);
            }
        }
        public static void CheckPathArgumentAllowNull(string path, string argumentName)
        {
            if (path != null &&
                (path.IsNullOrWhiteSpace() || path.IndexOfAny(Path.GetInvalidPathChars()) > -1))
            {
                throw new ArgumentException("Invalid path specified.", argumentName);
            }
        }

        public static void CheckFileNameArgument(string fileName, string argumentName)
        {
            if (fileName.IsNullOrWhiteSpace() ||
                fileName.IndexOfAny(Path.GetInvalidFileNameChars()) > -1)
            {
                throw new ArgumentException("Invalid file name specified.", argumentName);
            }
        }
        public static void CheckFileNameArgumentAllowNull(string fileName, string argumentName)
        {
            if (fileName != null && 
                (fileName.IsNullOrWhiteSpace() ||
                 fileName.IndexOfAny(Path.GetInvalidFileNameChars()) > -1))
            {
                throw new ArgumentException("Invalid file name specified.", argumentName);
            }
        }

        public static bool IsFolder(this FileSystemInfo fileSystemInfo)
        {
            if (fileSystemInfo == null)
            {
                throw new ArgumentNullException(nameof(fileSystemInfo));
            }

            return HasAnyOfFlags(fileSystemInfo.Attributes, FileAttributes.Directory);
        }

        public static bool IsDirectorySeparator(char c)
        {
            return c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar;
        }

        public static bool DoesPathExist(string path)
        {
            path = Path.GetFullPath(path);
            if (path.Length > 0 && IsDirectorySeparator(path[path.Length - 1]))
            {
                return false;
            }

            return NativeMethods.PathExists(path);
        }
    }
}