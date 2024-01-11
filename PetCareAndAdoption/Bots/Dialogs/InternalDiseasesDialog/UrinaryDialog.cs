using Microsoft.Bot.Builder.Dialogs;

namespace PetCareAndAdoption.Bots.Dialogs.InternalDiseasesDialog
{
    public class UrinaryDialog : ComponentDialog
    {
        public UrinaryDialog(string dialogId)
           : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("urinaryDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "urinaryDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("What do you want to know about your pet's URINARY health?")
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
            if (userQuestion.Contains("how often") && userQuestion.Contains("monitor") && (userQuestion.Contains("water") || userQuestion.Contains("pet's water intake")))
            {
                return "Regularly monitoring your pet's water intake is essential. Changes, such as increased or decreased thirst, can indicate potential issues with the urinary system or kidneys.";
            }
            else if (userQuestion.Contains("signs") && (userQuestion.Contains("urinary tract infection") ))
            {
                return "Signs of a urinary tract infection in pets include frequent urination, straining to urinate, blood in the urine, and changes in urine color or odor. If you notice these symptoms, consult with your veterinarian.";
            }
            else if (userQuestion.Contains("pet's diet") && (userQuestion.Contains("affect") || userQuestion.Contains("impact")) && (userQuestion.Contains("urinary health") || userQuestion.Contains("urinary system")))
            {
                return "Yes, diet plays a crucial role in urinary health. Feeding a balanced diet that supports urinary function can help prevent issues like urinary stones or crystals. Your veterinarian can recommend suitable dietary options.";
            }
            else if ((userQuestion.Contains("train") || userQuestion.Contains("teach")) && (userQuestion.Contains("pet") || userQuestion.Contains("cat") || userQuestion.Contains("dog")) && (userQuestion.Contains("litter box") || userQuestion.Contains("go outside") || userQuestion.Contains("urination")))
            {
                return "Proper training is crucial. For cats, provide a clean litter box, and for dogs, establish a routine for outdoor bathroom breaks. Consistency and positive reinforcement are key elements in successful training.";
            }
            else if (userQuestion.Contains("drink") && (userQuestion.Contains("water") || userQuestion.Contains("thirst") || userQuestion.Contains("hot weather")))
            {
                return "Increased water intake during hot weather is normal, as pets need to stay hydrated. However, excessive thirst, especially in cooler temperatures, could signal an underlying health issue and should be evaluated by a veterinarian.";
            }
            else if ((userQuestion.Contains("stress") || userQuestion.Contains("anxiety")) && (userQuestion.Contains("affect") || userQuestion.Contains("impact")) && (userQuestion.Contains("urinary health") || userQuestion.Contains("urinary system")))
            {
                return "Yes, stress or anxiety can contribute to urinary issues in pets. Changes in the environment, routine, or the presence of new pets can impact their urinary habits. Creating a calm and secure environment can help alleviate stress.";
            }
            else if (userQuestion.Contains("preventive measures") && (userQuestion.Contains("avoid urinary stones") || userQuestion.Contains("prevent urinary stones")))
            {
                return "Providing ample water, feeding a balanced diet, and ensuring regular veterinary check-ups are key preventive measures against urinary stones. Some pets may require specialized diets to minimize the risk.";
            }
            else if ((userQuestion.Contains("what should") || userQuestion.Contains("if my pet")) && (userQuestion.Contains("strain to urinate") || userQuestion.Contains("difficulty urinating")))
            {
                return "Straining to urinate is a concerning sign that requires immediate veterinary attention. It could indicate a urinary blockage or infection, both of which can be serious and require prompt intervention.";
            }
            else if (userQuestion.Contains("pets suffer from kidney disease") && (userQuestion.Contains("symptoms") || userQuestion.Contains("signs")))
            {
                return "Yes, pets can develop kidney disease. Symptoms include increased thirst, decreased appetite, weight loss, and changes in urination habits. Early detection through regular veterinary check-ups is crucial for managing kidney disease.";
            }
            else if (userQuestion.Contains("how often") && (userQuestion.Contains("clean") || userQuestion.Contains("cleaning")) && (userQuestion.Contains("litter box") || userQuestion.Contains("bathroom area")))
            {
                return "Cleaning frequency depends on the type of pet and their habits. Cats generally prefer a clean litter box and may avoid using it if it's dirty. Regular cleaning helps prevent odors and promotes good urinary hygiene.";
            }

            return "I'm sorry, I couldn't understand your question. Please feel free to ask something else.";
        }
        public static string Id => "checkUrinaryDialog";
        public static UrinaryDialog Instance { get; } = new UrinaryDialog(Id);
    }
}
