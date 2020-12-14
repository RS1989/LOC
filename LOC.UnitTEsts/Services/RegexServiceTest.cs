using Loc.Metricks.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOC.UnitTEsts.Services
{
    public class RegexServiceTest
    {
        private IRegexService _regexService;
        private IFileService _fileService;

        [SetUp]
        public void Setup()
        {
            _regexService = new RegexService();
            _fileService = new FileService();
        }

        [Test]
        [TestCase("./TestFile/testfile.txt")]
        public void RemoveCommentsTest(string path)
        {
            var source = _fileService.GetContent(path);
            var result = _regexService.RemoveComments(source);

            Assert.IsTrue(!result.Contains("*/"), "RemoveComments returns wrong results");
            Assert.IsTrue(!result.Contains("/*"), "RemoveComments returns wrong results");
            Assert.IsTrue(!result.Contains("//"), "RemoveComments returns wrong results");

        }
    }
}
