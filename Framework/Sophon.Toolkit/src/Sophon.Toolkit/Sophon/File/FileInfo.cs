using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.File
{
    public class FileInfo
    {
        public FileInfo(string path, string fileName, long? size, string id = null)
        {
            Id = id;
            Path = path;
            FileName = fileName.IsNullOrWhiteSpace() ? System.IO.Path.GetFileName(path) : fileName;
            Extension = System.IO.Path.GetExtension(fileName).TrimStart('.');
            Size = size.SafeValue();
        }
        public string Id { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string SaveName { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Md5 { get; set; }
    }
}
