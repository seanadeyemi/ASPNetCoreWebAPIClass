using ASPNetCoreWebAPIClass.Domain.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ASPNetCoreWebAPIClass.Domain.Services
{
    public class ReqResService
    {
        private HttpClient httpClient;
        private readonly ILogger<ReqResService> _logger;

        public ReqResService(HttpClient httpClient, ILogger<ReqResService> logger)
        {
            httpClient.BaseAddress = new Uri("https://reqres.in/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            this.httpClient = httpClient;
            _logger = logger;
        }

        public async Task<UsersResponse> GetUsers(int pageNumber, int itemsPerPage)
        {
            UsersResponse usersResponse = new();
            try
            {
                var response = await httpClient.GetAsync($"api/users?page={pageNumber}&per_page={itemsPerPage}");
                if (response == null)
                {
                    return new UsersResponse { };
                }
                if (response?.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return new UsersResponse { };
                }
                var result = await response.Content.ReadAsStringAsync();
                usersResponse = JsonConvert.DeserializeObject<UsersResponse>(result);

            }
            catch (HttpRequestException ex)
            {

                _logger.LogError(ex.Message, ex);
                usersResponse = new UsersResponse { };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                usersResponse = new UsersResponse { };

            }
            return usersResponse;

        }

    }
}
