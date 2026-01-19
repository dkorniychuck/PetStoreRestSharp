using PetStoreRestSharp.Models;
using RestSharp;
using System.Net;

namespace PetStoreRestSharp.Clients
{
    public class UserClient : BaseClient
    {
        public UserClient() : base(new Uri("https://petstore.swagger.io/v2/")) { }

        public async Task<User?> CreateUserWithListAsync(List<User> list)
        {
            var response = ExecuteWithoutDeserialization(Method.Post, "user/createWithList", list, HttpStatusCode.OK);
            return await HandleResponseAsync(response, async () => list.FirstOrDefault(), "Error creating users with list");
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var user = ExecuteWithDeserialization<User>(Method.Get, $"user/{username}", null, HttpStatusCode.OK);
            return await Task.FromResult(user);
        }

        public async Task<User?> UpdateUserAsync(string username, User user)
        {
            var response = ExecuteWithoutDeserialization(Method.Put, $"user/{username}", user, HttpStatusCode.OK);
            return await HandleResponseAsync(response, async () => user, "Error updating user");
        }

        public async Task<User?> DeleteUserByUsernameAsync(string username)
        {
            var response = ExecuteWithoutDeserialization(Method.Delete, $"user/{username}", null, HttpStatusCode.OK);
            return await HandleResponseAsync(response, async () => (User?)null, "Error deleting user by username");
        }

        public async Task<string?> LogInUserAsync(string username, string password)
        {
            var request = new RestRequest("user/login", Method.Get);
            request.AddParameter("username", username);
            request.AddParameter("password", password);

            var response = Execute(request, "user/login", null, HttpStatusCode.OK);
            return await HandleResponseAsync(response, async () => response.Content, "Error logging in user");
        }

        public async Task<string?> LogOutUserAsync()
        {
            var response = ExecuteWithoutDeserialization(Method.Get, "user/logout", null, HttpStatusCode.OK);
            return await HandleResponseAsync(response, async () => response.Content, "Error logging out user");
        }
        public async Task<User?> CreateUserWithArrayAsync(User[] users)
        {
            var response = ExecuteWithoutDeserialization(Method.Post, "user/createWithArray", users, HttpStatusCode.OK);
            return await HandleResponseAsync(response, async () => users.FirstOrDefault(), "Error creating users with array");
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            var response = ExecuteWithoutDeserialization(Method.Post, "user", user, HttpStatusCode.OK);
            return await HandleResponseAsync(response, async () => user, "Error creating user");
        }
    }
}
