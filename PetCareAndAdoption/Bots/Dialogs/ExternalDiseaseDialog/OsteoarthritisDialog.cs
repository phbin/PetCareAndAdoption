using Microsoft.Bot.Builder.Dialogs;

namespace PetCareAndAdoption.Bots.Dialogs.ExternalDiseaseDialog
{
    public class OsteoarthritisDialog : ComponentDialog
    {
        public OsteoarthritisDialog(string dialogId)
            : base(dialogId)
        {
            AddDialog(new TextPrompt("textPrompt"));

            AddDialog(new WaterfallDialog("jointHealthDialog", new WaterfallStep[]
            {
                AskQuestion,
                ProcessAnswer
            }));

            InitialDialogId = "jointHealthDialog";
        }

        private async Task<DialogTurnResult> AskQuestion(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync("textPrompt", new PromptOptions
            {
                Prompt = stepContext.Context.Activity.CreateReply("What do you want to know about your pet's Osteoarthritis health?")
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
            if (userQuestion.Contains("signs") && (userQuestion.Contains("joint issues") || userQuestion.Contains("joint problems")))
            {
                return "Common signs of joint issues in pets include limping, stiffness, reluctance to climb stairs, decreased activity levels, and difficulty getting up or lying down.";
            }
            else if (userQuestion.Contains("certain breeds") && (userQuestion.Contains("prone to joint problems") || userQuestion.Contains("predisposed to joint issues")))
            {
                return "Yes, certain breeds are predisposed to joint problems, particularly large breeds like Labrador Retrievers and German Shepherds. However, joint issues can affect pets of any size or breed.";
            }
            else if (userQuestion.Contains("obesity") && (userQuestion.Contains("contribute to joint problems")))
            {
                return "Yes, obesity is a significant contributor to joint problems in pets. Excess weight places additional strain on joints, increasing the risk of conditions like arthritis.";
            }
            else if (userQuestion.Contains("preventive measures") && (userQuestion.Contains("support my pet's joint health")))
            {
                return "Providing a balanced diet, regular exercise, maintaining a healthy weight, and incorporating joint supplements, if recommended by your veterinarian, are crucial preventive measures.";
            }
            else if (userQuestion.Contains("arthritis") && (userQuestion.Contains("diagnosed in pets")))
            {
                return "Arthritis is diagnosed through a combination of physical examination, observation of symptoms, and sometimes imaging studies such as X-rays. Consult with your veterinarian if you suspect your pet has arthritis.";
            }
            else if (userQuestion.Contains("joint issues") && (userQuestion.Contains("managed without surgery")))
            {
                return "Yes, many joint issues can be managed without surgery. Treatment may include medication, weight management, physical therapy, and joint supplements to improve mobility and comfort.";
            }
            else if (userQuestion.Contains("benefits of providing joint supplements") && (userQuestion.Contains("to my pet")))
            {
                return "Joint supplements containing glucosamine, chondroitin, and omega-3 fatty acids can promote joint health, reduce inflammation, and alleviate symptoms associated with joint problems.";
            }
            else if (userQuestion.Contains("modify my home") && (userQuestion.Contains("accommodate a pet with joint issues")))
            {
                return "Modify your home by providing soft bedding, ramps instead of stairs, and non-slip surfaces to make it easier for a pet with joint problems to move around comfortably.";
            }
            else if (userQuestion.Contains("specific exercises") && (userQuestion.Contains("strengthen my pet's joints")))
            {
                return "Low-impact exercises, such as swimming or controlled walks, can help strengthen a pet's joints without placing excessive stress on them. Consult with your veterinarian for a tailored exercise plan.";
            }
            else if (userQuestion.Contains("joint problems") && (userQuestion.Contains("hereditary")))
            {
                return "Yes, some joint problems can have a hereditary component. Breeds with a genetic predisposition to joint issues may be more susceptible, but environmental factors also play a role. Regular veterinary check-ups are important for early detection.";
            }
            else
            {
                return "I'm sorry, I couldn't understand your question. Please feel free to ask something else.";
            }
        }

        public static string Id => "checkOsteoarthritisDialog";
        public static OsteoarthritisDialog Instance { get; } = new OsteoarthritisDialog(Id);
    }
}
