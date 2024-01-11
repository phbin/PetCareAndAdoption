using Microsoft.Bot.Builder.Dialogs;
using PetCareAndAdoption.Helpers;

namespace PetCareAndAdoption.Bots.Dialogs.ExternalDiseaseDialog
{
    public class EyesDialog : ComponentDialog
    {
        public EyesDialog(string dialogId)
            : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("eyeHealthDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "eyeHealthDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("What do you want to know about your pet's EYES?")
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
            if (userQuestion.Contains("clean my pet's eyes"))
            {
                return "Regular eye cleaning is necessary for pets with tear staining or discharge. Use a moist cotton ball to gently wipe away debris, and consult your veterinarian if you notice persistent issues.";
            }
            else if (userQuestion.Contains("eye infections"))
            {
                return "Yes, pets can develop eye infections caused by bacteria, viruses, or foreign objects. Signs include redness, discharge, squinting, or excessive tearing. Consult your vet for proper diagnosis and treatment.";
            }
            else if (userQuestion.Contains("normal for my pet to have sleep in their eyes"))
            {
                return "Occasional eye discharge, often referred to as 'sleep' or 'eye boogers,' is normal. However, persistent or colored discharge may indicate an underlying issue and should be checked by a veterinarian.";
            }
            else if (userQuestion.Contains("cause redness in my pet's eyes"))
            {
                return "Redness in a pet's eyes may be caused by various factors, including infections, allergies, or irritants. Consult with your veterinarian for an accurate diagnosis and appropriate treatment.";
            }
            else if (userQuestion.Contains("prevent tear staining in my pet"))
            {
                return "Regularly clean the area around your pet's eyes to prevent tear staining. Additionally, addressing the underlying cause, such as blocked tear ducts or allergies, can help minimize staining.";
            }
            else if (userQuestion.Contains("cats develop cataracts"))
            {
                return "Yes, pets can develop cataracts. Treatment may involve surgical removal of the cataract, but the decision depends on factors such as the pet's overall health and the impact on vision.";
            }
            else if (userQuestion.Contains("common signs of eye injuries in pets"))
            {
                return "Signs of eye injuries include squinting, pawing at the eye, tearing, swelling, and changes in eye color. Seek immediate veterinary attention for any suspected eye injury.";
            }
            else if (userQuestion.Contains("breeds more prone to eye issues"))
            {
                return "Some breeds are predisposed to certain eye conditions. For example, brachycephalic breeds may be prone to issues like corneal ulcers. Regular veterinary check-ups are important for early detection.";
            }
            else if (userQuestion.Contains("seasonal allergies affecting their eyes"))
            {
                return "Yes, pets can experience seasonal allergies that affect their eyes, leading to symptoms like redness, itching, and tearing. Your veterinarian can recommend appropriate treatments.";
            }
            else if (userQuestion.Contains("administer eye drops to my pet"))
            {
                return "To administer eye drops, gently restrain your pet, tilt their head back, and carefully apply the drops to the lower eyelid. Be cautious and reward your pet afterward for positive reinforcement. If unsure, consult your veterinarian for guidance.";
            }
            else
            {
                return "I'm sorry, I couldn't understand your question. Please feel free to ask something else.";
            }
        }
        public static string Id => "checkEyesDialog";
        public static EyesDialog Instance { get; } = new EyesDialog(Id);
    }
}
