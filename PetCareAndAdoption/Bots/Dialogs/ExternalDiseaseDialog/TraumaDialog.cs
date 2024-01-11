using Microsoft.Bot.Builder.Dialogs;

namespace PetCareAndAdoption.Bots.Dialogs.ExternalDiseaseDialog
{
    public class TraumaDialog : ComponentDialog
    {
        public TraumaDialog(string dialogId)
             : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("emergencyCareDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "emergencyCareDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("What do you want to know about EMERGENCY care for pets?")
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
            if (userQuestion.Contains("pet is bleeding") && (userQuestion.Contains("wound")))
            {
                return "If your pet is bleeding, apply gentle pressure to the wound with a clean cloth or bandage. If the bleeding is severe, visit the vet immediately.";
            }
            else if (userQuestion.Contains("handle a pet with a broken limb"))
            {
                return "Approach the pet calmly, and if possible, secure the broken limb with a splint or bandage. Transport them to the vet as soon as possible for proper diagnosis and treatment.";
            }
            else if (userQuestion.Contains("steps") && (userQuestion.Contains("pet ingests something toxic")))
            {
                return "Contact your veterinarian or a poison control hotline immediately. Provide information on what your pet ingested and follow their advice for immediate care.";
            }
            else if (userQuestion.Contains("use human first aid supplies") && (userQuestion.Contains("on my pet")))
            {
                return "While some human first aid supplies may be used on pets, it's crucial to consult with a veterinarian first. Never give human medications to pets without professional guidance.";
            }
            else if (userQuestion.Contains("recognize signs of heatstroke") && (userQuestion.Contains("in my pet")))
            {
                return "Signs of heatstroke include excessive panting, drooling, rapid breathing, lethargy, and collapse. Move your pet to a cooler place, offer water, and seek veterinary attention urgently.";
            }
            else if (userQuestion.Contains("pet is having a seizure"))
            {
                return "Stay calm, move objects away from your pet to prevent injury, and time the duration of the seizure. After the seizure, keep your pet quiet and contact your veterinarian.";
            }
            else if (userQuestion.Contains("remove a tick from my pet") && (userQuestion.Contains("at home")))
            {
                return "Yes, you can remove a tick at home using fine-tipped tweezers. Grasp the tick close to the skin and pull upward with steady pressure. Clean the area and your hands thoroughly afterward.";
            }
            else if (userQuestion.Contains("perform CPR on my pet") && (userQuestion.Contains("in an emergency")))
            {
                return "Pet CPR involves chest compressions and rescue breaths. Learn the proper technique from your veterinarian or a certified pet first aid course to be prepared for emergencies.";
            }
            else if (userQuestion.Contains("pet is choking"))
            {
                return "For a choking pet, perform the Heimlich maneuver by giving quick abdominal thrusts. If unsuccessful, seek immediate veterinary assistance.";
            }
            else if (userQuestion.Contains("create a pet first aid kit"))
            {
                return "A pet first aid kit should include items like gauze, adhesive tape, antiseptic wipes, scissors, a digital thermometer, and contact information for your veterinarian and emergency clinics. Familiarize yourself with the kit's contents and usage.";
            }
            else
            {
                return "I'm sorry, I couldn't understand your question. Please feel free to ask something else.";
            }
        }
        public static string Id => "checkTraumaDialog";
        public static TraumaDialog Instance { get; } = new TraumaDialog(Id);
    }
}
