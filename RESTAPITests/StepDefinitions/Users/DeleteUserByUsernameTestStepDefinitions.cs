using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Users
{
    [Binding]
    public class DeleteUserByUsernameTestStepDefinitions
    {
        private static UserClient _globalUser = new UserClient();
        private static User user;
        private static string _username;
        private static User? result;

        [Given("I want to delete a user with the username {string}")]
        public void GivenIWantToDeleteAUserWithTheUsername(string username)
        {
            _username = username;
        }

        [When("Program creating new test user with the following details:")]
        public async Task WhenProgramCreatingNewTestUserWithTheFollowingDetails(DataTable dataTable)
        {
            user = dataTable.CreateInstance<User>();
            await _globalUser.CreateUserAsync(user);
        }


        [When("I send a request to delete the user")]
        public async Task WhenISendARequestToDeleteTheUser()
        {
            Console.WriteLine($"Deleting user with username {_username}...");
            result = await _globalUser.DeleteUserByUsernameAsync(_username);
        }

        [Then("The user is deleted successfully")]
        public async Task ThenTheUserIsDeletedSuccessfully()
        {
            Assert.That(result, Is.Null);

            Assert.ThrowsAsync<HttpRequestException>(async () => await _globalUser.GetUserByUsernameAsync(_username));

            Console.WriteLine("User deleted successfully: " + _username);
        }
    }
}
