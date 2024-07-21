using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var bot = new EchoBot();
            var adapter = new ConsoleAdapter();

            Console.WriteLine("Bot is running... Type 'exit' to stop.");
            await adapter.ProcessAsync(bot, CancellationToken.None);

            Console.WriteLine("Bot has stopped.");
        }
    }
}
