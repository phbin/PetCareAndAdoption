using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using PetCareAndAdoption.Bots.Dialogs.FindPetDialog.SpeciesDialog;
using PetCareAndAdoption.Bots.Dialogs.InternalDiseasesDialog;
using PetCareAndAdoption.Helpers;

namespace PetCareAndAdoption.Bots.Dialogs
{
    public class FindPetPostDialog:WaterfallDialog
    {
        public FindPetPostDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply($"Which one you want me to find?"),
                        Choices = new[] { new Choice { Value = "Cat" }, new Choice { Value = "Dog" },
                            new Choice { Value = "Others" }
                        }.ToList()
                    });
            });

            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = stepContext.Result as FoundChoice;
                var state = await (stepContext.Context.TurnState["BotAccessors"] as BotAccessors).PetBotStateAccessor.GetAsync(stepContext.Context);
                state.Species = response.Value.ToString();

                if (response.Value == "Cat")
                {
                    return await stepContext.BeginDialogAsync(SexDialog.Id);
                }
                if (response.Value == "Dog")
                {
                    return await stepContext.BeginDialogAsync(SexDialog.Id);
                }
                if (response.Value == "Others")
                {
                    return await stepContext.BeginDialogAsync(SexDialog.Id);
                }
               
                return await stepContext.NextAsync();
            });
        }

        public static string Id => "findPetDialog";
        public static FindPetPostDialog Instance { get; } = new FindPetPostDialog(Id);
    }
}
