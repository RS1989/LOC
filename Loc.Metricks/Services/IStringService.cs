using System;
using System.Collections.Generic;
using System.Text;

namespace Loc.Metricks.Services
{
    public interface IStringService
    {
        List<string> SplitStringToLines(string source);
        int GetEmptyCount(List<string> source);

    }
}
