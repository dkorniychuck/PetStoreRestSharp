using PetStoreRestSharp.Models;
using RestSharp;

namespace PetStoreRestSharp.Clients
{
    public class UserClient
    {
        private readonly RestClient _client;
        public UserClient()
        {
            _client = new RestClient("https://petstore.swagger.io/v2/user/");
        }
        public async Task<User?> CreateUserWithListAsync(List<User> list)
        {
            var request = new RestRequest("createWithList", Method.Post);
            request.AddJsonBody(list);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return list.FirstOrDefault();
            }
            else
            {
                throw new Exception($"Error creating users with list: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var request = new RestRequest($"{username}", Method.Get);

            var response = await _client.ExecuteAsync<User>(request);
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error retrieving user by username: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }
        public async Task<User?> UpdateUserAsync(string username, User user)
        {
            var request = new RestRequest($"{username}", Method.Put);
            request.AddJsonBody(user);
            var response = await _client.ExecuteAsync<User>(request);
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error updating user: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }
        public async Task<User?> DeleteUserByUsernameAsync(string username)
        {
            var request = new RestRequest($"{username}", Method.Delete);
            var response = await _client.ExecuteAsync<User>(request);
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error deleting user by username: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }
        public async Task<string?> LogInUserAsync(string username, string password)
        {
            var request = new RestRequest("login", Method.Get);
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                throw new Exception($"Error logging in user: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }
        public async Task<string?> LogOutUserAsync()
        {
            var request = new RestRequest("logout", Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                throw new Exception($"Error logging out user: {response.ErrorMessage ?? response.StatusDescription}");
            }

        }
        public async Task<User?> CreateUserWithArrayAsync(User[] users)
        {
            var request = new RestRequest("createWithArray", Method.Post);
            request.AddJsonBody(users);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return users.FirstOrDefault();
            }
            else
            {
                throw new Exception($"Error creating users with array: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }
        public async Task<User?> CreateUserAsync(User user)
        {
            var request = new RestRequest("", Method.Post);
            request.AddJsonBody(user);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return user;
            }
            else
            {
                throw new Exception($"Error creating user: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }
    }
}
