using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Users
{
    [Binding]
    public class UpdateUserTestStepDefinitions
    {
        private static UserClient _globalUser = new UserClient();
        private static string _userName = "jane_smith";
        private static User _user;

        [Given("I want to update a user with the following details:")]
        public void GivenIWantToUpdateAUserWithTheFollowingDetails(DataTable dataTable)
        {
            _user = dataTable.CreateInstance<User>();
        }

        [When("I send a request to update the user")]
        public async Task WhenISendARequestToUpdateTheUser()
        {
            _user = await _globalUser.UpdateUserAsync(_userName, _user);
        }

        [Then("The user details are updated successfully with the correct data")]
        public void ThenTheUserDetailsAreUpdatedSuccessfullyWithTheCorrectData()
        {
            Assert.That(_user, Is.Not.Null);

            Console.WriteLine("User updated successfully.");
        }
    }
}
