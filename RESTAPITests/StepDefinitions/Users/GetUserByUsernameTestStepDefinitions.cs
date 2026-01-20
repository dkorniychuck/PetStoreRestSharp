using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Users
{
    [Binding]
    public class GetUserByUsernameTestStepDefinitions
    {
        private static UserClient _globalUser = new UserClient();
        private string _username;
        private static User user;

        [Given("I want to get a user by following username {string}")]
        public void GivenIWantToGetAUserByFollowingUsername(string username)
        {
            _username = username;
        }

        [When("I send a request to get the user")]
        public async Task WhenISendARequestToGetTheUser()
        {
            Console.WriteLine($"Getting user with username {_username}...");
            user = await _globalUser.GetUserByUsernameAsync(_username);

        }

        [Then("The user details are returned successfully with the correct username")]
        public void ThenTheUserDetailsAreReturnedSuccessfullyWithTheCorrectUsername()
        {
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Username, Is.EqualTo(_username));

            Console.WriteLine($"User ID: {user.Id}, Username: {user.Username}, First Name: {user.FirstName}, Last Name: {user.LastName}, Email: {user.Email}");
        }
    }
}
