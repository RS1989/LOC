using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loc.Metricks.Services
{
    public class StringService: IStringService
    {
        private readonly string[] _lineBreaks;
        public StringService()
        {
            _lineBreaks = new string[] { "\r\n" };
        }

        public List<string> SplitStringToLines(string source)
        {
            var result = source.Split(_lineBreaks, StringSplitOptions.None);
            return result.ToList();
        }

        public int GetEmptyCount(List<string> source)
        {
            return source.Where(s => string.IsNullOrEmpty(s) | string.IsNullOrWhiteSpace(s)).Count();
        }
    }
}
