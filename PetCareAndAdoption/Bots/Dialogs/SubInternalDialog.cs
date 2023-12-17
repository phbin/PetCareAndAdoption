using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using PetCareAndAdoption.Bots.Dialogs.InternalDiseasesDialog;

namespace PetCareAndAdoption.Bots.Dialogs
{
    public class SubInternalDialog:WaterfallDialog
    {
        public SubInternalDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply($"Please select the issue you'd like advice on regarding INTERNAL organ diseases in pets.?"),
                        Choices = new[] { new Choice { Value = "Digest" }, new Choice { Value = "Respiratory" },
                            new Choice { Value = "Urinary" },  new Choice { Value = "Vaccination" }
                        }.ToList()
                    });
            });

            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = stepContext.Result as FoundChoice;
                if (response.Value == "Digest")
                {
                    return await stepContext.BeginDialogAsync(DigestDialog.Id);
                }
                if (response.Value == "Respiratory")
                {
                    return await stepContext.BeginDialogAsync(RespiratoryDialog.Id);
                }
                if (response.Value == "Urinary")
                {
                    return await stepContext.BeginDialogAsync(UrinaryDialog.Id);
                }
                if (response.Value == "Vaccination")
                {
                    return await stepContext.BeginDialogAsync(VaccinationDialog.Id);
                }
             
                return await stepContext.NextAsync();
            });
        }

        public static string Id => "checkSubInternalDialog";
        public static SubInternalDialog Instance { get; } = new SubInternalDialog(Id);
    }
}
