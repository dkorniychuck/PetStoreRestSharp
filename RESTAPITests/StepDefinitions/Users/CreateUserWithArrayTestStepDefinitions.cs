using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Users
{
    [Binding]
    public class CreateUserWithArrayTestStepDefinitions
    {
        private static readonly UserClient _globalUser = new UserClient();
        private User[] _users = Array.Empty<User>();
        private User? _createdUser;

        [Given("I want to create an array of users with the following details:")]
        public void GivenIWantToCreateAnArrayOfUsersWithTheFollowingDetails(Table table)
        {
            _users = table.CreateSet<User>().ToArray();
        }

        [When("I send a request to create the array of users")]
        public async Task WhenISendARequestToCreateTheArrayOfUsersAsync()
        {
            Console.WriteLine("Creating new users with array...");
            _createdUser = await _globalUser.CreateUserWithArrayAsync(_users);
        }

        [Then("The users are created successfully")]
        public void ThenTheUsersAreCreatedSuccessfully()
        {
            Assert.That(_createdUser, Is.Not.Null, "API should return at least one created user (first element).");

            Console.WriteLine("Success! Created User ID (first returned): " + _createdUser!.Id);
        }
    }
}
