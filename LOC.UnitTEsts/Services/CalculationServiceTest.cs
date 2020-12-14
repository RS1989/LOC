using Loc.Metricks.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOC.UnitTEsts.Services
{
    public class CalculationServiceTest
    {
        private ICalculationService _calculationService;

        [SetUp]
        public void Setup()
        {
            _calculationService = new CalculationService();
        }

        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 3)]
        [TestCase(2, 1, 3)]
        [TestCase(5, 3, 8)]
        [TestCase(3, 5, 8)]
        public void GetCountEmptyAndCommentLineTest(int emptyCount, int commentsCount, int expectedResult)
        {
            var result = _calculationService.GetCountEmptyAndCommentLine(emptyCount, commentsCount);

            Assert.IsTrue(expectedResult == result, "GetCountEmptyAndCommentLine function returned wrong results");
        }

        [Test]
        [TestCase(1, 1, 0)]
        [TestCase(1, 2, -1)]
        [TestCase(2, 1, 1)]
        [TestCase(5, 3, 2)]
        [TestCase(3, 5, -2)]
        public void GetCommentLineCountTest(int withCommentsCount, int withoutCommentsCount, int expectedResult)
        {
            var result = _calculationService.GetCommentLineCount(withCommentsCount, withoutCommentsCount);

            Assert.IsTrue(expectedResult == result, "GetCommentLineCount function returned wrong results");
        }

        [Test]
        [TestCase(1, 1, 0)]
        [TestCase(1, 2, -1)]
        [TestCase(2, 1, 1)]
        [TestCase(5, 3, 2)]
        [TestCase(3, 5, -2)]
        public void GetExecutionCountTest(int allCount, int withoutEmptyAndEmptycount, int expectedResult)
        {
            var result = _calculationService.GetExecutionCount(allCount, withoutEmptyAndEmptycount);

            Assert.IsTrue(expectedResult == result, "GetExecutionCount function returned wrong results");
        }
    }
}
