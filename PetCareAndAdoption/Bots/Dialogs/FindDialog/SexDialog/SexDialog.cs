using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using PetCareAndAdoption.Bots.Dialogs.FindPetDialog.SexDialog;
using PetCareAndAdoption.Helpers;

namespace PetCareAndAdoption.Bots.Dialogs.FindPetDialog.SpeciesDialog
{
    public class SexDialog:WaterfallDialog
    {
        public SexDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply($"Please choose one?"),
                        Choices = new[] { new Choice { Value = "Male" }, new Choice { Value = "Female" }
                        }.ToList()
                    });
            });

            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = stepContext.Result as FoundChoice;
                var state = await (stepContext.Context.TurnState["BotAccessors"] as BotAccessors).PetBotStateAccessor.GetAsync(stepContext.Context);
                state.Sex = response.Value.ToString();
                if (response.Value == "Male")
                {
                    return await stepContext.BeginDialogAsync(ResultDialog.Id);
                }
                if (response.Value == "Female")
                {
                    return await stepContext.BeginDialogAsync(ResultDialog.Id);
                }
                return await stepContext.NextAsync();
            });
        }

        public static string Id => "sexDialog";
        public static SexDialog Instance { get; } = new SexDialog(Id);
    }
}
