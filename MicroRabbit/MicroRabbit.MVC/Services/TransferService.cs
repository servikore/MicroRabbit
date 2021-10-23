using MicroRabbit.MVC.Models.DTO;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient httpClient;

        public TransferService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:5001/api/Banking";
            var transferContent = new StringContent(JsonSerializer.Serialize(transferDto),
                    Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
