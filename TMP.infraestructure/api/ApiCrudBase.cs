using System.Text.Json;
using TMP.domain.commons.response.api;
using TMP.domain.commons.response.chatGpt;
using TMP.domain.contracts.api;

namespace TMP.infraestructure.api
{
    public class ApiCrudBase : IApiCrud<ApiResponse>
    {
        private readonly HttpClient _httpClien = new HttpClient();
        private readonly string _apiKey = string.Empty;

        public ApiCrudBase()
        {
            _apiKey = "sk-B8jK80krZMAMtZevwZ42T2g9IKimoAq4S5EpzghdaUT3BlbkFJJgDCadEuvsTjbMGgOvXrosfZlwMAgcP6odskwsDhEA";
        }
        public async Task<ApiResponse> Post(string url, StringContent? content)
        {
            _httpClien.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            try
            {
                var response = await _httpClien.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                ChatGptResponse chatGptResponse = JsonSerializer.Deserialize<ChatGptResponse>(responseBody)!;
                string jsonString = JsonSerializer.Serialize(chatGptResponse, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(responseBody);
                return new ApiResponse()
                {
                    Status = true,
                    Message = "Operacion realizada correctamente",
                    Response = chatGptResponse
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Status = true,
                    Message = "Ocurrio un error al realizar la operacion" + ex.Message,
                    Response = null
                };
            }

        }

    }
}
