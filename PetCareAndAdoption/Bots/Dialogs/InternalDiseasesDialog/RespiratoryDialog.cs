using Microsoft.Bot.Builder.Dialogs;

namespace PetCareAndAdoption.Bots.Dialogs.InternalDiseasesDialog
{
    public class RespiratoryDialog : ComponentDialog
    {
        public RespiratoryDialog(string dialogId)
            : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("respiratoryHealthDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "respiratoryHealthDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("What do you want to know about your pet's RESPIRATORY health?")
            });
        }

        private async Task<DialogTurnResult> ProcessAnswer(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var userQuestion = stepContext.Result.ToString().Trim().ToLower();
            string response = GetCommonResponse(userQuestion);

            await stepContext.Context.SendActivityAsync(response);

            return await stepContext.ReplaceDialogAsync(InitialDialogId, cancellationToken);
        }

        private string GetCommonResponse(string userQuestion)
        {
            if (userQuestion.Contains("normal respiratory rate"))
            {
                return "For dogs, it's 10-30 breaths per minute, and for cats, it's 20-30 breaths per minute. Monitoring helps identify respiratory issues.";
            }
            else if (userQuestion.Contains("infection") && (userQuestion.Contains("human")))
            {
                return "Pets can get respiratory infections, but not the common cold. Infections are usually species-specific.";
            }
            else if (userQuestion.Contains("sign") && (userQuestion.Contains("respiratory distress")))
            {
                return "Signs include rapid breathing, coughing, wheezing, and bluish discoloration. Seek vet attention if observed.";
            }
            else if (userQuestion.Contains("certain breeds") && (userQuestion.Contains("dogs") || userQuestion.Contains("cats")) && userQuestion.Contains("higher risk of respiratory issues"))
            {
                return "Brachycephalic breeds may be prone to breathing difficulties due to their anatomy.";
            }
            else if (userQuestion.Contains("secondhand smoke") && userQuestion.Contains("respiratory health of pets"))
            {
                return "Secondhand smoke can lead to respiratory conditions like asthma. A smoke-free environment is crucial.";
            }
            else if (userQuestion.Contains("respiratory diseases") && userQuestion.Contains("prevented through vaccination"))
            {
                return "Vaccination can prevent diseases like canine cough in dogs or upper respiratory infections in cats.";
            }
            else if (userQuestion.Contains("role of exercise") && userQuestion.Contains("maintain respiratory health") && userQuestion.Contains("pets"))
            {
                return "Regular exercise strengthens respiratory muscles and improves lung function.";
            }
            else if (userQuestion.Contains("allergies") && userQuestion.Contains("affect") && userQuestion.Contains("pet's respiratory system"))
            {
                return "Yes, allergies can lead to symptoms like sneezing, coughing, or nasal discharge.";
            }
            else if (userQuestion.Contains("friendly environment") && userQuestion.Contains("pet"))
            {
                return "Ensure good ventilation, avoid smoke or strong odors, keep areas clean, and provide a dust-free space.";
            }
            else if ((userQuestion.Contains("what to do") || userQuestion.Contains("if my pet")) && userQuestion.Contains("difficulty breathing"))
            {
                return "Difficulty breathing is an emergency. Seek immediate veterinary attention, keep the pet calm, and avoid exertion.";
            }
            else
            {
                return "I'm sorry, I couldn't understand your question. Please feel free to ask something else.";
            }
        }
        public static string Id => "checkRespiratoryDialog";
        public static RespiratoryDialog Instance { get; } = new RespiratoryDialog(Id);
    }
}
