using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Loc.Metricks.Services
{
    public class FileService: IFileService
    {
        public string GetContent(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
