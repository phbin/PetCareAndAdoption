using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using PetCareAndAdoption.Helpers;

namespace PetCareAndAdoption.Bots.Dialogs.FindPetDialog.SexDialog
{
    public class ResultDialog:ComponentDialog
    {

        public ResultDialog(string dialogId)
            : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("resultFindDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "resultFindDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("Please tell me the age of pet you want, just enter number only.")
            });
        }

        private async Task<DialogTurnResult> ProcessAnswer(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var userQuestion = stepContext.Result.ToString().Trim().ToLower();
            string response = "";

            if (int.TryParse(userQuestion, out int age))
            {
                var state = await (stepContext.Context.TurnState["BotAccessors"] as BotAccessors).PetBotStateAccessor.GetAsync(stepContext.Context);
                state.Age = age;
                response = $"Great! You are looking for a {state.Sex} {state.Species} aged {state.Age}. Here is a random option we found, hope you like it!";
                return await stepContext.EndDialogAsync();
            }
            else
            {
                response = "Please enter number only.";
            }
            await stepContext.Context.SendActivityAsync(response);

            return await stepContext.ReplaceDialogAsync(InitialDialogId, cancellationToken);
        }
        public static string Id => "resultDialog";
        public static ResultDialog Instance { get; } = new ResultDialog(Id);
    }
}
