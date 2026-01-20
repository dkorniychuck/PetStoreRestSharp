using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Users
{
    [Binding]
    public class CreateUserWithListTestStepDefinitions
    {
        private static UserClient _globalUser = new UserClient();
        private List<User> users;
        private User? createdUsers;

        [Given("I want to create List of user with the following details:")]
        public void GivenIWantToCreateListOfUserWithTheFollowingDetails(DataTable dataTable)
        {
            users = dataTable.CreateSet<User>().ToList();
        }

        [When("I send a request to create the list")]
        public async Task WhenISendARequestToCreateTheListAsync()
        {
            Console.WriteLine("Creating new user with list...");
            createdUsers = await _globalUser.CreateUserWithListAsync(users);
        }

        [Then("The list of users is created successfully")]
        public void ThenTheListOfUsersIsCreatedSuccessfully()
        {
            Assert.That(createdUsers, Is.Not.Null);

            foreach (var user in users)
            {
                Console.WriteLine("Success! New User ID: " + user.Id);
            }
        }
    }
}
