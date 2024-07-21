using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace ChatBot
{
    public class ConsoleAdapter : BotAdapter
    {
        public async Task ProcessAsync(IBot bot, CancellationToken cancellationToken)
        {
            while (true)
            {
                Console.Write("User: ");
                var userInput = Console.ReadLine();

                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var activity = new Activity
                {
                    Type = ActivityTypes.Message,
                    Text = userInput,
                    From = new ChannelAccount("user"),
                    Recipient = new ChannelAccount("bot"),
                    Conversation = new ConversationAccount(id: "console")
                };

                using (var context = new TurnContext(this, activity))
                {
                    await bot.OnTurnAsync(context, cancellationToken);
                }
            }
        }

        public override Task DeleteActivityAsync(ITurnContext turnContext, ConversationReference reference, CancellationToken cancellationToken)
        {
            // This adapter does not support deleting activities.
            throw new NotImplementedException();
        }

        public override Task<ResourceResponse[]> SendActivitiesAsync(ITurnContext turnContext, Activity[] activities, CancellationToken cancellationToken)
        {
            foreach (var activity in activities)
            {
                if (activity.Type == ActivityTypes.Message)
                {
                    Console.WriteLine($"Bot: {activity.Text}");
                }
            }

            return Task.FromResult(new ResourceResponse[0]);
        }

        public override Task<ResourceResponse> UpdateActivityAsync(ITurnContext turnContext, Activity activity, CancellationToken cancellationToken)
        {
            // This adapter does not support updating activities.
            throw new NotImplementedException();
        }
    }
}