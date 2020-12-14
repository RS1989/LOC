
namespace Loc.Metricks.Services
{
    public interface ICalculationService
    {
        int GetCountEmptyAndCommentLine(int emptyCount, int commentsCount);
        int GetCommentLineCount(int withCommentsCount, int withoutCommentsCount);
        int GetExecutionCount(int allCount, int withoutEmptyAndEmptycount);
    }
}
