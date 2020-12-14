using Loc.Metricks.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace LOC
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            ConfigureServices();
            var stringService = _serviceProvider.GetService<IStringService>();
            var regexService = _serviceProvider.GetService<IRegexService>();
            var fileService = _serviceProvider.GetService<IFileService>();
            var calculationService = _serviceProvider.GetService<ICalculationService>();

            Console.WriteLine("Do you want read data from local file - print 'y', if you want pass data directly press any button");
            var decission = Console.ReadLine();
            var source = string.Empty;
            if (string.Equals(decission, "y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Provide local file path");
                var path = Console.ReadLine();
                source = fileService.GetContent(path);
            }
            else 
            {
                Console.WriteLine("Provide source code");
                source = Console.ReadLine();
            }          
                        
            var allLines = stringService.SplitStringToLines(source);
            var dataWthoutComments = regexService.RemoveComments(source);
            var linesWithoutComments = stringService.SplitStringToLines(dataWthoutComments);
            var emptyLinesCount = stringService.GetEmptyCount(linesWithoutComments);            
            var commentsLineCount = calculationService.GetCommentLineCount(allLines.Count, linesWithoutComments.Count);
            var commentAndEmptyCount = calculationService.GetCountEmptyAndCommentLine(emptyLinesCount, commentsLineCount);
            var executableLineCount = calculationService.GetExecutionCount(allLines.Count, commentAndEmptyCount);

            Console.WriteLine($"Executavle lines count: {executableLineCount}; Comments and whitespaces lines count: {commentAndEmptyCount}");
            Console.WriteLine("Press any button to exit");
            Console.ReadLine();
            DisposeService();

        }

        private static void ConfigureServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddScoped<IRegexService, RegexService>()
                .AddScoped<IStringService, StringService>()
                .AddScoped<IFileService, FileService>()
                .AddScoped<ICalculationService, CalculationService>()
                .BuildServiceProvider();
        }

        private static void DisposeService()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
