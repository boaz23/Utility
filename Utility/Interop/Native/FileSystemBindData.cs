using Utility.Interop.Native.Types;

namespace Utility.Interop.Native
{
    public class FileSystemBindData : IFileSystemBindData
    {
        public FileSystemBindData() { }
        public FileSystemBindData(WIN32_FIND_DATA findData)
        {
            this.FindData = findData;
        }

        public WIN32_FIND_DATA FindData { get; set; }

        void IFileSystemBindData.SetFindData(ref WIN32_FIND_DATA pfd) => this.FindData = pfd;
        WIN32_FIND_DATA IFileSystemBindData.GetFindData() => this.FindData;
    }
}