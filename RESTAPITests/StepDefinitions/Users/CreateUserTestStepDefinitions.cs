using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Users
{
    [Binding]
    public class CreateUserTestStepDefinitions
    {
        private static readonly UserClient _globalUser = new UserClient();
        private User createdUser;
        private User user;

        [Given("I want to create a user with the following details:")]
        public void GivenIWantToCreateAUserWithTheFollowingDetails(DataTable dataTable)
        {
            user = dataTable.CreateInstance<User>();
        }

        [When("I send a request to create the user")]
        public async Task WhenISendARequestToCreateTheUser()
        {
            Console.WriteLine("Creating new user...");
            createdUser = await _globalUser.CreateUserAsync(user);
        }

        [Then("The user is created successfully")]
        public void ThenTheUserIsCreatedSuccessfully()
        {
            Assert.That(createdUser, Is.Not.Null);
            Assert.That(createdUser.Id, Is.EqualTo(user.Id));

            Console.WriteLine("Success! New User ID: " + createdUser.Id);
        }
    }
}
