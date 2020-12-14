using Loc.Metricks.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOC.UnitTEsts.Services
{
    public class StringServiceTest
    {
        private IStringService _stringService;
        private IFileService _fileService;

        [SetUp]
        public void Setup()
        {
            _stringService = new StringService();
            _fileService = new FileService();
        }

        [Test]
        [TestCase("./TestFile/testfile.txt")]
        public void SplitStringToLinesTest(string path)
        {
            var source = _fileService.GetContent(path);
            var result = _stringService.SplitStringToLines(source);

            Assert.IsTrue(result.Count > 0, "SplitStringToLines returns wrong results");
            Assert.IsTrue(result.Count == 26, "SplitStringToLines returns wrong results");
        }

        [Test]
        [TestCase("./TestFile/testfile.txt")]
        public void GetEmptyCountTest(string path)
        {
            var source = _fileService.GetContent(path);
            var sourceLines = _stringService.SplitStringToLines(source);
            var result = _stringService.GetEmptyCount(sourceLines);

            Assert.IsTrue(result> 0, "SplitStringToLines returns wrong results");
            Assert.IsTrue(result == 2, "SplitStringToLines returns wrong results");
        }
    }
}
