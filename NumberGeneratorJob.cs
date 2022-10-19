using System;
using System.Threading.Tasks;
using System.Timers;
using Quartz;

namespace FireBaseMicroServices
{
    public class NumberGeneratorJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Your # is:                   {RandomNumber(1000, 9999)} => {DateTime.Now}");
            await Task.CompletedTask;
        }

        private int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}