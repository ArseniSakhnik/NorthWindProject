using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NorthWind.Core.Entities.Services;
using NorthWindProject.Application.ConfigurationModels;

namespace NorthWindProject.Application.Services.BotService
{
    public class BotService
    {
        private readonly AppSettings _appSettings;

        public BotService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }


        public async Task<HttpResponseMessage> SendRequestCall(SendRequestCallDto requestCallDto)
        {
            var botUrl = _appSettings.BotUrl;
            var jsonRequestCall = JsonConvert.SerializeObject(requestCallDto);
            var data = new StringContent(jsonRequestCall, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            return await client.PostAsync(botUrl, data);
        }
    }
}