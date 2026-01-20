using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Pets
{
    [Binding]
    public class FindPetsByStatusTestStepDefinitions
    {
        private static PetClient _globalPet = new PetClient();
        private Pet pet;
        private string status;

        [Given("I want to find pets with the status {string}")]
        public void GivenIWantToFindPetsWithTheStatus(string available)
        {
            status = available;
        }

        [When("I send a request to find pets by status")]
        public async Task WhenISendARequestToFindPetsByStatus()
        {
            Console.WriteLine($"Finding pets with status '{status}'...");
            pet = await _globalPet.FindByStatusAsync(status);
        }

        [Then("The pets are returned successfully with the status {string}")]
        public void ThenThePetsAreReturnedSuccessfullyWithTheStatus(string available)
        {
            Assert.That(pet, Is.Not.Null);
            Assert.That(pet.Status, Is.EqualTo(status));

            Console.WriteLine($"Pet ID: {pet.Id}, Name: {pet.Name}, Status: {pet.Status}");
        }
    }
}
