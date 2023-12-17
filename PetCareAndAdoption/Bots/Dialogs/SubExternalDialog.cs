using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using PetCareAndAdoption.Bots.Dialogs.ExternalDiseaseDialog;
using PetCareAndAdoption.Bots.Dialogs.InternalDiseasesDialog;

namespace PetCareAndAdoption.Bots.Dialogs
{
    public class SubExternalDialog:WaterfallDialog
    {
        public SubExternalDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply($"Please select the issue you'd like advice on regarding EXTERNAL organ diseases in pets.?"),
                        Choices = new[] { new Choice { Value = "Dermatology" }, new Choice { Value = "Eyes" },  
                            new Choice { Value = "Ears/Teeth/Mouth" },  new Choice { Value = "First Aid" }, 
                            new Choice { Value = "Osteoarthritis" },  new Choice { Value = "Reproduction" }
                        }.ToList()
                    });
            });

            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = stepContext.Result as FoundChoice;
                if (response.Value == "Dermatology")
                {
                    return await stepContext.BeginDialogAsync(DermatologyDialog.Id);
                }
                if (response.Value == "Eyes")
                {
                    return await stepContext.BeginDialogAsync(EyesDialog.Id);
                }
                if (response.Value == "Ears/Teeth/Mouth")
                {
                    return await stepContext.BeginDialogAsync(ETMDialog.Id);
                }
                if (response.Value == "First Aid")
                {
                    return await stepContext.BeginDialogAsync(TraumaDialog.Id);
                }
                if (response.Value == "Osteoarthritis")
                {
                    return await stepContext.BeginDialogAsync(OsteoarthritisDialog.Id);
                }
                if (response.Value == "Reproduction")
                {
                    return await stepContext.BeginDialogAsync(ReproductionDialog.Id);
                }

                return await stepContext.NextAsync();
            });
        }

        public static string Id => "checkSubExternalDialog";
        public static SubExternalDialog Instance { get; } = new SubExternalDialog(Id);
    }
}
