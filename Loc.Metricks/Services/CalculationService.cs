using System;
using System.Collections.Generic;
using System.Text;

namespace Loc.Metricks.Services
{
    public class CalculationService: ICalculationService
    {
        public int GetCountEmptyAndCommentLine(int emptyCount, int commentsCount)
        {
            return emptyCount + commentsCount;
        }

        public int GetCommentLineCount(int withCommentsCount, int withoutCommentsCount)
        {
            return withCommentsCount - withoutCommentsCount;
        }

        public int GetExecutionCount(int allCount, int withoutEmptyAndEmptycount)
        {
            return allCount - withoutEmptyAndEmptycount;
        }
    }
}
