using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Loc.Metricks.Services
{
    public class RegexService: IRegexService
    {
        private readonly string _blockComments;
        private readonly string _lineComments;
        private readonly string _stringComment;
        private readonly string _verbatimString;

        public RegexService()
        {
            _blockComments = @"/\*(.*?)\*/";
            _lineComments = @"//(.*?)\r?\n";
            _stringComment = @"""((\\[^\n]|[^""\n])*)""";
            _verbatimString = @"@(""[^""]*"")+";
        }

        public string RemoveComments(string source)
        {           
            string result = Regex.Replace(source, _blockComments + "|" + _lineComments + "|" + _stringComment + "|" + _verbatimString,
                s => {
                    if (s.Value.StartsWith("/*") || s.Value.StartsWith("//"))
                        return s.Value.StartsWith("//") ? Environment.NewLine : "";
                    return s.Value;
                },RegexOptions.Singleline);
            return result;
        }     
    }
}
