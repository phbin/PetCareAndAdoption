using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using Twilio.Rest.Api.V2010.Account;

namespace PetCareAndAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> GetAIBasedResult(string text)
        //{
        //    string APIKey = "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";
        //    string answer = string.Empty;

        //    var openai = new OpenAIAPI(APIKey);
        //    CompletionRequest completion = new CompletionRequest();
        //    completion.Prompt = text;
        //    completion.Model = OpenAI_API.Models.Model.DavinciText;
        //    completion.MaxTokens = 200;

        //    var result = openai.Completions.CreateCompletionAsync(completion);
        //    foreach (var item in result.Result.Completions)
        //    {
        //        answer = item.Text;
        //    }
        //    return Ok(answer);
        //}
    }
}
