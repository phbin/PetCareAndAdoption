using Microsoft.Bot.Builder.Dialogs;
using PetCareAndAdoption.Bots.Dialogs.InternalDiseasesDialog;

namespace PetCareAndAdoption.Bots.Dialogs.ExternalDiseaseDialog
{
    public class DermatologyDialog : ComponentDialog
    {
        public DermatologyDialog(string dialogId)
          : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("dermaDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "dermaDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("What do you want to know about your pet's DERMATOLOGY health?")
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
            if (userQuestion.Contains("sign") && userQuestion.Contains("skin") && (userQuestion.Contains("allergies") || userQuestion.Contains("allergy")))
            {
                return "Common signs of skin allergies in pets include itching, redness, hair loss, and recurrent ear infections. If you notice these symptoms, consult with your veterinarian for proper diagnosis and treatment.";
            }
            else if (userQuestion.Contains("can") && userQuestion.Contains("sunburned") ||(userQuestion.Contains("protect")&& userQuestion.Contains("skin")))
            {
                return "Pets can get sunburned, especially those with light-colored fur or exposed skin. Use pet-safe sunscreen, provide shade, and limit sun exposure during peak hours to protect their skin.";
            }
            else if (userQuestion.Contains("bath")|| userQuestion.Contains("bathe") && userQuestion.Contains("often"))
            {
                return "The frequency of pet bathing depends on factors like breed, lifestyle, and skin conditions. In general, most pets benefit from a bath every 4-8 weeks using a gentle, pet-friendly shampoo.";
            }
            else if ((userQuestion.Contains("dry") || userQuestion.Contains("flaky")) && userQuestion.Contains("cause") && userQuestion.Contains("skin"))
            {  
                return "Dry, flaky skin in pets can result from factors such as allergies, nutritional deficiencies, or environmental conditions. Consult with your veterinarian to identify the underlying cause and appropriate treatment.";
            }
            else if (userQuestion.Contains("specific breeds") && userQuestion.Contains("prone") && userQuestion.Contains("skin"))
            {
                return "Some breeds are more susceptible to skin issues, such as Bulldogs or Shar-Peis. Regular grooming, a balanced diet, and veterinary check-ups can help manage and prevent skin problems.";
            }
            else if (userQuestion.Contains("help")  && userQuestion.Contains("seasonal shedding"))
            {
                return "Regular brushing, a balanced diet rich in omega-3 fatty acids, and appropriate grooming can help manage seasonal shedding in pets.";
            }
            else if (userQuestion.Contains("can") && userQuestion.Contains("develop skin infections"))
            {
                return "Pets can develop skin infections. Signs include redness, swelling, odor, and discharge. If you suspect a skin infection, seek veterinary attention for diagnosis and treatment.";
            }
            else if (userQuestion.Contains("address hot spots")  && userQuestion.Contains("best way"))
            {
                return "Hot spots, or moist dermatitis, can be treated by keeping the area clean, using prescribed topical medications, and addressing the underlying cause. Consult with your veterinarian for specific guidance.";
            }
            else if (userQuestion.Contains("have reaction") && userQuestion.Contains("certain grooming products"))
            {
                return "Some pets may have allergic reactions to certain grooming products. It's essential to use pet-specific, hypoallergenic products and monitor your pet for any signs of irritation.";
            }
            else if (userQuestion.Contains("prevent") && (userQuestion.Contains("dry") || userQuestion.Contains("cracked")) && userQuestion.Contains("paw pads") )
            {
                return "Prevent dry, cracked paw pads by applying pet-safe paw balms, avoiding harsh surfaces, and ensuring proper hydration. Regular veterinary check-ups can also identify and address potential issues.";
            }

            return "I'm sorry, I couldn't understand your question. Please feel free to ask something else.";
        }
     
        public static string Id => "checkDermatologyDialog";
        public static DermatologyDialog Instance { get; } = new DermatologyDialog(Id);
    }
}
