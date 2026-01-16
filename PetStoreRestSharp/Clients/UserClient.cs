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
            var user = ExecuteWithDeserialization<User>(Method.Get, $"user/{username}", null, HttpStatusCode.OK);
            return await Task.FromResult(user);
        }

        public async Task<User?> UpdateUserAsync(string username, User user)
        {
            var response = ExecuteWithoutDeserialization(Method.Put, $"user/{username}", user, HttpStatusCode.OK);
            if (response.IsSuccessful)
            {
                return user;
            }
            else
            {
                throw new Exception($"Error updating user: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }

        public async Task<User?> DeleteUserByUsernameAsync(string username)
        {
            var response = ExecuteWithoutDeserialization(Method.Delete, $"user/{username}", null, HttpStatusCode.OK);
            if (response.IsSuccessful)
            {
                return null;
            }
            else
            {
                throw new Exception($"Error deleting user by username: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }

        public async Task<string?> LogInUserAsync(string username, string password)
        {
            var request = new RestRequest("user/login", Method.Get);
            request.AddParameter("username", username);
            request.AddParameter("password", password);

            var response = Execute(request, "user/login", null, HttpStatusCode.OK);
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
            var response = ExecuteWithoutDeserialization(Method.Get, "user/logout", null, HttpStatusCode.OK);
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
            var response = ExecuteWithoutDeserialization(Method.Post, "user/createWithArray", users, HttpStatusCode.OK);
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
            var response = ExecuteWithoutDeserialization(Method.Post, "user", user, HttpStatusCode.OK);
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
