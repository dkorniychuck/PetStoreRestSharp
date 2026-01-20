using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Users
{
    [Binding]
    public class LogInUserTestStepDefinitions
    {
        private static readonly UserClient _globalUser = new UserClient();
        private string? _loginResponse;
        private static string _username;
        private static string _password;

        [Given("I want to log in a user with the following credentials:")]
        public void GivenIWantToLogInAUserWithTheFollowingCredentials(Table table)
        {
            var user = table.CreateInstance<User>();
            _username = user.Username;
            _password = user.Password;
        }

        [When("I send a request to log in the user")]
        public async Task WhenISendARequestToLogInTheUser()
        {
            _loginResponse = await _globalUser.LogInUserAsync(_username, _password);
        }

        [Then("The user is logged in successfully")]
        public void ThenTheUserIsLoggedInSuccessfully()
        {
            Assert.That(_loginResponse, Is.Not.Null.And.Not.Empty, "Login response should not be null or empty.");
            Console.WriteLine("Login response: " + _loginResponse);
        }
    }
}
