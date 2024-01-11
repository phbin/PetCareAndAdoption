using Microsoft.Bot.Builder.Dialogs;

namespace PetCareAndAdoption.Bots.Dialogs.ExternalDiseaseDialog
{
    public class ETMDialog : ComponentDialog
    {
        public ETMDialog(string dialogId)
            : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("etmDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "etmDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("What do you want to know about your pet's EARS, NOSE, or THROAT?")
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
            if (userQuestion.Contains("clean")&&userQuestion.Contains("ears")&&userQuestion.Contains("home"))
            {
                return "Use a vet-approved ear cleaner and a cotton ball to gently wipe away dirt. Avoid using cotton swabs, and if you notice signs of infection or discomfort, consult your veterinarian.";
            }
            else if (userQuestion.Contains("signs of respiratory issues") && (userQuestion.Contains("pet") || userQuestion.Contains("animal")))
            {
                return "Common signs include sneezing, coughing, nasal discharge, labored breathing, and changes in appetite. If you observe these symptoms, it's essential to seek veterinary attention.";
            }
            else if (userQuestion.Contains("help my pet with a stuffy nose"))
            {
                return "Use a humidifier, keep your pet hydrated, and encourage them to eat by offering moist or aromatic food. If symptoms persist, consult with your veterinarian.";
            }
            else if (userQuestion.Contains("specific breeds")&&userQuestion.Contains("prone"))
            {
                return "Brachycephalic breeds (short-nosed), such as Bulldogs and Persian cats, are more prone to respiratory issues due to their anatomy.";
            }
            else if (userQuestion.Contains("cold")&& userQuestion.Contains("from human"))
            {
                return "While pets can contract respiratory infections, the viruses causing the common cold in humans are typically not the same for pets.";
            }
            else if (userQuestion.Contains("check for signs of dental problems") && (userQuestion.Contains("pet's mouth")))
            {
                return "Look for signs of bad breath, swollen gums, tartar buildup, and difficulty eating. Regular dental check-ups with your veterinarian are crucial for preventing dental issues.";
            }
            else if (userQuestion.Contains("check")&&userQuestion.Contains("dental problems"))
            {
                return "Occasional coughing may be normal, but persistent or severe coughing could indicate underlying respiratory issues such as infections or allergies. Consult with your vet for proper diagnosis.";
            }
            else if ((userQuestion.Contains("pets get sore throats") || userQuestion.Contains("develop sore throats")))
            {
                return "Yes, pets can develop sore throats, especially if they have respiratory infections or irritations. Signs may include difficulty swallowing, coughing, or changes in vocalization.";
            }
            else if (userQuestion.Contains("sign")&& userQuestion.Contains("ear infection"))
            {
                return "Signs of ear infections include scratching at the ears, redness, swelling, discharge, and a foul odor. If you suspect an ear infection, consult with your veterinarian for proper diagnosis and treatment.";
            }
            else
            {
                return "I'm sorry, I couldn't understand your question. Please feel free to ask something else.";
            }
        }

        public static string Id => "checkETMDialog";
        public static ETMDialog Instance { get; } = new ETMDialog(Id);
    }
}
