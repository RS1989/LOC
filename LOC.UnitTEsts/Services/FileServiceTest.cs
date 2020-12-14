using Loc.Metricks.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOC.UnitTEsts.Services
{
    public class FileServiceTest
    {
        private IFileService _fileService;

        [SetUp]
        public void Setup()
        {
            _fileService = new FileService();
        }

        [Test]
        [TestCase("./TestFile/testfile.txt")]
        public void GetContentTest(string path)
        {
            var result = _fileService.GetContent(path);

            Assert.IsTrue(result.Length > 0, "GetContent returns wrond results ");
        }

    }
}
