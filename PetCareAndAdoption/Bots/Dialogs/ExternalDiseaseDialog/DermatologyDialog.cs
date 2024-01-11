using Microsoft.Bot.Builder.Dialogs;

namespace PetCareAndAdoption.Bots.Dialogs.ExternalDiseaseDialog
{
    public class DermatologyDialog : WaterfallDialog
    {
        public DermatologyDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("textPrompt",
                    new PromptOptions
                    {

                        Prompt = stepContext.Context.Activity.CreateReply("Chúng tôi có các loại hoa như sau:  \n " +
                        "Tulip: 70k/cành  \n" +
                        "Linh lan: 150k/cành  \n" +
                        "Hồng: 50k/cành  \n" +
                        "Bạn muốn mua loại hoa nào?")
                    });
            });
        }
        public static string Id => "checkDermatologyDialog";
        public static DermatologyDialog Instance { get; } = new DermatologyDialog(Id);
    }
}
