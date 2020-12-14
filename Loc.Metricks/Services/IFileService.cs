using System;
using System.Collections.Generic;
using System.Text;

namespace Loc.Metricks.Services
{
    public interface IFileService
    {
        string GetContent(string path);
    }
}
