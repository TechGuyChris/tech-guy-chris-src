using System;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;


namespace Microsoft.Bot.Sample.LuisBot
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"], 
            ConfigurationManager.AppSettings["LuisAPIKey"], 
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }

        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            var response = context.MakeMessage();
            response.Text = "Welcome to Mixtape! How can I help?";

            response.InputHint = InputHints.ExpectingInput;
            await context.PostAsync(response);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Mixtape")]
        public async Task MixtapeIntent(IDialogContext context, LuisResult result)
        {
            var response = context.MakeMessage();
            response.Text = "Welcome to Mixtape! Let's find a song to play.";

            response.InputHint = InputHints.ExpectingInput;
            await context.PostAsync(response);
            context.Wait(MessageReceived);
        }

        [LuisIntent("PlaySong")]
        public async Task PlaySongIntent(IDialogContext context, LuisResult result)
        {
            var response = context.MakeMessage();
            response.Text = "Here's a song for you.";

            response.InputHint = InputHints.ExpectingInput;
            await context.PostAsync(response);
            context.Wait(MessageReceived);
        }

        [LuisIntent("SaveSong")]
        public async Task SaveSongIntent(IDialogContext context, LuisResult result)
        {
            var response = context.MakeMessage();
            response.Text = "Sign in to save the song to a mixtape.";

            response.InputHint = InputHints.AcceptingInput;
            await context.PostAsync(response);
            context.Wait(MessageReceived);
        }
        
        [LuisIntent("Cancel")]
        public async Task CancelIntent(IDialogContext context, LuisResult result)
        {
            var response = context.MakeMessage();
            response.Text = "Your request has been cancelled";

            response.InputHint = InputHints.ExpectingInput;
            await context.PostAsync(response);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task GreetingIntent(IDialogContext context, LuisResult result)
        {
            var response = context.MakeMessage();
            response.Text = "Hi there! Welcome to Mixtape!";

            response.InputHint = InputHints.ExpectingInput;
            await context.PostAsync(response);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Help")]
        public async Task HelpIntent(IDialogContext context, LuisResult result)
        {
            var response = context.MakeMessage();
            response.Text = "please use one of my commands: Cancel, Greeting, Help, Mixtape, None, PlaySong, SaveSong";

            response.InputHint = InputHints.ExpectingInput;
            await context.PostAsync(response);
            context.Wait(MessageReceived);
        }
        
        private async Task ShowLuisResult(IDialogContext context, LuisResult result) 
        {
            await context.PostAsync($"You have reached {result.Intents[0].Intent}. You said: {result.Query}");
            context.Wait(MessageReceived);
        }
    }
}
