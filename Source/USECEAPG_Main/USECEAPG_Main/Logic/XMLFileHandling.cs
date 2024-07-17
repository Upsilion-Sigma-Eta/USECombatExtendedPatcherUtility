using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USECEAPG_Main.Logic
{
    public class XMLFileHandling
    {
        public List<FileInfo> _fileInofs = new List<FileInfo>();
        public List<DirectoryInfo> _directoryInfos = new List<DirectoryInfo>();

        public List<FileInfo> Files
        {
            get
            {
                return _fileInofs;
            }
        }

        public List<DirectoryInfo> Directories
        {
            get
            {
                return _directoryInfos;
            }
        }
    }
}
