using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;

namespace PetCareAndAdoption.Bots.Dialogs.InternalDiseasesDialog
{
    public class VaccinationDialog:ComponentDialog
    {
        public VaccinationDialog(string dialogId)
            : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("vaccinationDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "vaccinationDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("What issues about VACCINEs do you want to ask?")
            });
        }

        private async Task<DialogTurnResult> ProcessAnswer(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var userQuestion = stepContext.Result.ToString().Trim().ToLower();
            string response = "";

            if (userQuestion.Contains("why") && userQuestion.Contains("vaccine"))
            {
                response = "Vaccination is crucial for pets as it helps stimulate their immune system, protecting them from dangerous infectious diseases. It prevents the spread of various bacteria, viruses, and other pathogens, ensuring the overall health and well-being of the pet.";
            }
            else if ((userQuestion.Contains("common") || userQuestion.Contains("what common")) && userQuestion.Contains("vaccine"))
            {
                response = "Common vaccines for pets include core vaccines such as those for rabies, distemper, and parvovirus. Non-core vaccines may include protection against diseases like kennel cough or Lyme disease, depending on the pet's specific needs and environment.";
            }
            else if (userQuestion.Contains("when") && userQuestion.Contains("start") && userQuestion.Contains("vaccin"))
            {
                response = "Pets should begin their vaccination series when they are young, typically around six to eight weeks old. The initial vaccinations are often followed by booster shots to ensure long-lasting immunity.";
            }
            else if (userQuestion.Contains("how often") && userQuestion.Contains("pet") && userQuestion.Contains("need") && userQuestion.Contains("booster shot"))
            {
                response = "Booster shots are necessary to maintain immunity. The frequency of booster shots depends on the specific vaccine and the pet's age. Your veterinarian will provide a personalized schedule based on your pet's health and risk factors.";
            }
            else if (userQuestion.Contains("side effect") && userQuestion.Contains("vaccin"))
            {
                response = "While most pets tolerate vaccinations well, some may experience mild side effects such as lethargy or slight swelling at the injection site. Serious reactions are rare, and any concerns should be promptly discussed with your veterinarian.";
            }
            else if (userQuestion.Contains("indoor") && userQuestion.Contains("skip") && userQuestion.Contains("vaccin"))
            {
                response = "Even indoor pets can be exposed to certain diseases, so it's essential to consult with your veterinarian to determine the appropriate vaccines based on your pet's lifestyle and potential risks.";
            }
            else if ((userQuestion.Contains("cat") || userQuestion.Contains("dog")) && userQuestion.Contains("need") && userQuestion.Contains("same") && userQuestion.Contains("vaccin"))
            {
                response = "No, cats and dogs have different vaccination needs. Cats, for example, require vaccines for diseases like feline leukemia and feline immunodeficiency virus, which are not relevant to dogs.";
            }
            else if (userQuestion.Contains("pet") && userQuestion.Contains("vaccin") && userQuestion.Contains("sick"))
            {
                response = "Generally, it's recommended to vaccinate healthy pets. Sick pets may have compromised immune systems, and vaccination could exacerbate their condition. Your veterinarian will advise on the appropriate timing.";
            }
            else if (userQuestion.Contains("miss") && userQuestion.Contains("schedule") && userQuestion.Contains("vaccin"))
            {
                response= "If you miss a scheduled vaccination, it's essential to consult with your veterinarian to reschedule. Depending on the vaccine and the time elapsed, your pet may need a booster or restart the vaccination series. Regular vaccinations are crucial for continued protection.";
            }
            else
            {
                response = "I'm sorry, I couldn't understand your question. Please feel free to ask something else.";
            }
            await stepContext.Context.SendActivityAsync(response);

            return await stepContext.ReplaceDialogAsync(InitialDialogId, cancellationToken);
        }
        public static string Id => "checkVaccinationDialog";
        public static VaccinationDialog Instance { get; } = new VaccinationDialog(Id);
    }
}
