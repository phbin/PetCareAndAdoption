using Microsoft.Bot.Builder.Dialogs;
using PetCareAndAdoption.Helpers;

namespace PetCareAndAdoption.Bots.Dialogs.ExternalDiseaseDialog
{
    public class EyesDialog : WaterfallDialog
    {
        public EyesDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
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

            //AddStep(async (stepContext, cancellationToken) =>
            //{
            //    var state = await (stepContext.Context.TurnState["BotAccessors"] as BotAccessors).FlowerShopStateStateAccessor.GetAsync(stepContext.Context);
            //    state.Amount = stepContext.Result.ToString();

            //    return await stepContext.PromptAsync("textPrompt",
            //        new PromptOptions
            //        {
            //            Prompt = stepContext.Context.Activity.CreateReply($"Tôi xin xác nhận bạn muốn mua {state.Amount}, cho tôi xin tên của bạn?"),
            //        });

            //});

            //AddStep(async (stepContext, cancellationToken) =>
            //{
            //    var state = await (stepContext.Context.TurnState["BotAccessors"] as BotAccessors).FlowerShopStateStateAccessor.GetAsync(stepContext.Context);
            //    state.Name = stepContext.Result.ToString();

            //    return await stepContext.PromptAsync("numberPrompt",
            //        new PromptOptions
            //        {
            //            Prompt = stepContext.Context.Activity.CreateReply($"{state.Name}, cho tôi số điện thoại liên lạc nhé?"),
            //            RetryPrompt = stepContext.Context.Activity.CreateReply("Xin lỗi, hãy cung cấp cho chúng tôi số điện thoại của bạn")
            //        });

            //});
            //AddStep(async (stepContext, cancellationToken) =>
            //{
            //    var state = await (stepContext.Context.TurnState["BotAccessors"] as BotAccessors).FlowerShopStateStateAccessor.GetAsync(stepContext.Context);
            //    state.PhoneNumber = int.Parse(stepContext.Result.ToString());

            //    return await stepContext.PromptAsync("textPrompt",
            //        new PromptOptions
            //        {
            //            Prompt = stepContext.Context.Activity.CreateReply($"{state.Name}, vui lòng cho tôi địa chỉ của bạn."),
            //        });
            //});

            //AddStep(async (stepContext, cancellationToken) =>
            //{
            //    var state = await (stepContext.Context.TurnState["BotAccessors"] as BotAccessors).FlowerShopStateStateAccessor.GetAsync(stepContext.Context);
            //    state.Address = stepContext.Result.ToString();

            //    await stepContext.Context.SendActivityAsync($"Tôi xin xác nhận lại thông tin  \n" +
            //        $"Bạn muốn mua {state.Amount}  \n" +
            //        $"Khách hàng {state.Name}  \n" +
            //        $"Số điện thoại:  {state.PhoneNumber}  \n" +
            //        $"Địa chỉ:  {state.Address}  \n" +
            //        $"Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi! Vui lòng kiểm tra điện thoại để chắc rằng hoa được giao đúng thời điểm!  \n" +
            //        $"Hẹn gặp lại! 💸");
            //    return await stepContext.EndDialogAsync();
            //});
        }
        public static string Id => "checkEyesDialog";
        public static EyesDialog Instance { get; } = new EyesDialog(Id);
    }
}
