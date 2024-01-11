using Microsoft.Bot.Builder.Dialogs;

namespace PetCareAndAdoption.Bots.Dialogs.ExternalDiseaseDialog
{
    public class ReproductionDialog : ComponentDialog
    {
        public ReproductionDialog(string dialogId)
           : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("reproductionControlDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "reproductionControlDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("What do you want to know about REPRODUCTION of pets?")
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
            if (userQuestion.Contains("importance") && (userQuestion.Contains("control the reproduction of pets")))
            {
                return "Controlling pet reproduction is crucial to prevent overpopulation, reduce the number of homeless animals, and ensure responsible pet ownership.";
            }
            else if (userQuestion.Contains("benefits") && (userQuestion.Contains("spaying or neutering my pet")))
            {
                return "Spaying (for females) and neutering (for males) offer benefits such as preventing unwanted litters, reducing the risk of certain health issues, and positively influencing behavior.";
            }
            else if (userQuestion.Contains("intact male and female pets") && (userQuestion.Contains("live together without reproducing")))
            {
                return "While it's possible for intact pets to coexist without reproducing, the risk of accidental mating is high. Spaying or neutering is a more reliable solution to prevent unintended pregnancies.";
            }
            else if (userQuestion.Contains("health risks") && (userQuestion.Contains("associated with not spaying or neutering my pet")))
            {
                return "Yes, intact pets are at a higher risk for reproductive-related health issues, including certain cancers and infections. Spaying or neutering can mitigate these risks.";
            }
            else if (userQuestion.Contains("pet overpopulation") && (userQuestion.Contains("impact shelters and rescues")))
            {
                return "Pet overpopulation contributes to overcrowded shelters and the euthanasia of millions of animals annually. Spaying and neutering play a vital role in reducing these numbers.";
            }
            else if (userQuestion.Contains("difference between spaying and neutering"))
            {
                return "Spaying is the surgical removal of a female animal's reproductive organs, while neutering refers to the removal of a male's testicles. Both procedures are aimed at preventing reproduction.";
            }
            else if (userQuestion.Contains("spaying or neutering change my pet's personality"))
            {
                return "While spaying or neutering may influence certain behaviors, such as aggression or roaming, it typically has a positive impact on a pet's overall temperament and behavior.";
            }
            else if (userQuestion.Contains("alternatives to surgical spaying or neutering"))
            {
                return "Non-surgical alternatives, such as chemical contraceptives, exist but may have side effects and are not as commonly recommended due to potential health risks.";
            }
            else if (userQuestion.Contains("spay or neuter my pet even if it's kept indoors"))
            {
                return "Yes, spaying or neutering is recommended for indoor pets too. Accidental escapes, potential health benefits, and the prevention of behavioral issues are all reasons to consider the procedure.";
            }
            else if (userQuestion.Contains("find affordable spaying or neutering services"))
            {
                return "Many animal welfare organizations, clinics, and shelters offer affordable spaying or neutering services. Research local options, and inquire about any available low-cost programs in your area.";
            }
            else
            {
                return "I'm sorry, I couldn't understand your question. Please feel free to ask something else.";
            }
        }

        public static string Id => "checkReproductionDialog";
        public static ReproductionDialog Instance { get; } = new ReproductionDialog(Id);
    }
}
