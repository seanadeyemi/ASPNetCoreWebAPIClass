using ASPNetCoreWebAPIClass.Domain.Models.API;
using Newtonsoft.Json;

namespace ASPNetCoreWebAPIClass.Domain.Services
{
    public interface IUserService
    {
        Task<GetUserResponse> GetUser(int id);
    }
    public class UserService : IUserService
    {
        private IHttpClientFactory _clientFactory;

        public UserService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<GetUserResponse> GetUser(int id)
        {
            var client = _clientFactory.CreateClient("reqres");
            var response = await client.GetAsync($"api/users/{id}");

            var result = await response.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<GetUserResponse>(result);

            return userResponse;
        }
    }
}
