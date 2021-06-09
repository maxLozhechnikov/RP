using System.Threading.Tasks;
<<<<<<< Updated upstream
using Valuator;
=======
using Microsoft.Extensions.Logging;
using SharedLib;
>>>>>>> Stashed changes

namespace RankCalculator
{
    internal static class Program
    {
        private static async Task Main()
        {
<<<<<<< Updated upstream
            var calculator = new RankCalculator(new RedisStorage());
            calculator.Run();
=======
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Debug);
            });

            using var calculator = new RankCalculator(loggerFactory.CreateLogger<RankCalculator>(), new RedisStorage());
            calculator.Subscribe();
>>>>>>> Stashed changes
            await Task.Delay(-1);
        }
    }
}