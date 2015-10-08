using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class FileStorage
    {
        public int FileStorageId { get; set; }

        public string FileName { get; set; }


        public string Path { get; set; }

        public FileType FileType { get; set; }

        public bool isSharedWithOthers { get; set; }

        public int MyProperty { get; set; }

    }

    public enum FileType {
        Image,
        Vedio,
        WordDocument,
        Pdf,
        Audio
    }
}
