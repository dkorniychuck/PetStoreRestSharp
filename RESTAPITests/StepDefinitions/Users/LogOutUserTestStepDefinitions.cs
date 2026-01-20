using PetStoreRestSharp.Clients;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Users
{
    [Binding]
    public class LogOutUserTestStepDefinitions
    {
        private static readonly UserClient _globalUser = new UserClient();
        private string? _logOutResponse;

        [Given("I want to log out a user")]
        public void GivenIWantToLogOutAUser()
        {

        }

        [When("I send a request to log out the user")]
        public async Task WhenISendARequestToLogOutTheUserAsync()
        {
            Console.WriteLine("Logging out user...");
            _logOutResponse = await _globalUser.LogOutUserAsync();
        }

        [Then("The user is logged out successfully")]
        public void ThenTheUserIsLoggedOutSuccessfully()
        {
            Assert.That(_logOutResponse, Is.Not.Null.And.Not.Empty, "Logout response should not be null or empty.");

            Console.WriteLine("User logged out successfully.");
        }
    }
}
