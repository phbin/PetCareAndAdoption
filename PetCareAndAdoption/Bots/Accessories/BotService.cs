using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using PetCareAndAdoption.Bots.Dialogs;
using PetCareAndAdoption.Bots.Dialogs.ExternalDiseaseDialog;
using PetCareAndAdoption.Bots.Dialogs.InternalDiseasesDialog;
using PetCareAndAdoption.Dialogs;
using PetCareAndAdoption.Helpers;

namespace PetCareAndAdoption.Bots.Accessories
{
    public class BotService:IBot
    {
        private readonly DialogSet dialogs;

        public BotService(BotAccessors botAccessors)
        {
            var dialogState = botAccessors.DialogStateAccessor;
            // compose dialogs
            dialogs = new DialogSet(dialogState);
            dialogs.Add(MainDialog.Instance);
            dialogs.Add(SubInternalDialog.Instance);
            dialogs.Add(SubExternalDialog.Instance);
            dialogs.Add(DermatologyDialog.Instance);
            dialogs.Add(DigestDialog.Instance);
            dialogs.Add(ETMDialog.Instance);
            dialogs.Add(EyesDialog.Instance);
            dialogs.Add(OsteoarthritisDialog.Instance);
            dialogs.Add(ReproductionDialog.Instance);
            dialogs.Add(RespiratoryDialog.Instance);
            dialogs.Add(TraumaDialog.Instance);
            dialogs.Add(UrinaryDialog.Instance);
            dialogs.Add(VaccinationDialog.Instance);
            dialogs.Add(new ChoicePrompt("choicePrompt"));
            dialogs.Add(new TextPrompt("textPrompt"));
            dialogs.Add(new NumberPrompt<int>("numberPrompt"));
            BotAccessors = botAccessors;
        }

        public BotAccessors BotAccessors { get; }


        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                // initialize state if necessary
                //var state = await BotAccessors.FlowerShopStateStateAccessor.GetAsync(turnContext, () => new FlowerShopState(), cancellationToken);

                turnContext.TurnState.Add("BotAccessors", BotAccessors);

                var dialogCtx = await dialogs.CreateContextAsync(turnContext, cancellationToken);

                if (dialogCtx.ActiveDialog == null)
                {
                    await dialogCtx.BeginDialogAsync(MainDialog.Id, cancellationToken: cancellationToken);
                }
                else
                {
                    await dialogCtx.ContinueDialogAsync(cancellationToken);
                }

                await BotAccessors.ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            }
        }
    }
}
