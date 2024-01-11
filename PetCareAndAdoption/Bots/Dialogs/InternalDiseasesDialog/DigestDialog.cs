using Microsoft.Bot.Builder.Dialogs;
using Microsoft.JSInterop.Infrastructure;

namespace PetCareAndAdoption.Bots.Dialogs.InternalDiseasesDialog
{
    public class DigestDialog : ComponentDialog
    {
        public DigestDialog(string dialogId)
           : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("digestDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "digestDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("What issues about DIGEST do you want to ask?")
            });
        }

        private async Task<DialogTurnResult> ProcessAnswer(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var userQuestion = stepContext.Result.ToString().Trim().ToLower();
            string response = "";

            if (userQuestion.Contains("What")&& userQuestion.Contains("cause"))
            {
                response = "Digestive issues in pets can be caused by factors such as dietary changes, food allergies, infections, or underlying health conditions. Identifying the root cause is crucial for effective treatment.";
            }
            else if (userQuestion.Contains("diet") && userQuestion.Contains("important"))
            {
                response = "A balanced diet is crucial for maintaining optimal digestive health in pets. It ensures they receive essential nutrients, proper fiber, and the right balance of proteins and fats to support overall well-being.";
            }
            else if (userQuestion.Contains("human food")) 
            {
                response = "While some human foods are safe for pets, it's generally recommended to stick to pet-specific diets to ensure they receive the right nutrients in proper proportions. Certain human foods can be harmful to pets.";
            }
            else if (userQuestion.Contains("eat grass"))
            {
                response = "Occasional grass consumption is generally considered normal behavior for pets and may help with the natural elimination of hairballs or induce vomiting if they have an upset stomach. However, excessive grass eating should be monitored.";
            }
            else if (userQuestion.Contains("prevent digest problem"))
            {
                response = "Preventing digestive issues involves feeding a balanced diet, avoiding sudden food changes, providing access to fresh water, and keeping your pet's environment clean to reduce the risk of infections.";
            }
            else if (userQuestion.Contains("stress anxiety affect digest"))
            {
                response = "Yes, stress or anxiety can impact a pet's digestion. Changes in routine, new environments, or the presence of other animals can lead to digestive upset. Providing a secure and familiar environment can help alleviate stress.";
            }
            else if (userQuestion.Contains("what should if digest issue"))
            {
                response = "If your pet experiences persistent digestive issues, it's crucial to consult with a veterinarian. They can conduct diagnostics, such as blood tests or imaging, to identify the underlying cause and recommend an appropriate treatment plan.";
            }
            else
            {
                response = "I'm sorry, I couldn't understand your question. Please feel free to ask something else.";
            }
            await stepContext.Context.SendActivityAsync(response);

            return await stepContext.ReplaceDialogAsync(InitialDialogId, cancellationToken);
        }
        public static string Id => "checkDigestDialog";
        public static DigestDialog Instance { get; } = new DigestDialog(Id);
    }
}
