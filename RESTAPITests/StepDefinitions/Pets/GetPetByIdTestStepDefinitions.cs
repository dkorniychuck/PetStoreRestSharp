using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Pets
{
    [Binding]
    public class GetPetByIdTestStepDefinitions
    {
        private static PetClient _globalPet = new PetClient();
        private Pet pet;
        private long petId;

        [Given("I want to get a pet with the Id {long}")]
        public void GivenIWantToGetAPetWithTheId(long petId)
        {
            petId = 9;
            this.petId = petId;
        }

        [When("I send a request to get the pet")]
        public async Task WhenISendARequestToGetThePet()
        {
            Console.WriteLine($"Getting pet with ID {petId}...");
            pet = await _globalPet.GetPetByIdAsync(petId);
        }

        [Then("The pet details are returned successfully with the correct Id")]
        public void ThenThePetDetailsAreReturnedSuccessfullyWithTheCorrectId()
        {
            Assert.That(pet, Is.Not.Null);
            Assert.That(pet.Id, Is.EqualTo(petId));

            Console.WriteLine($"Pet ID: {pet.Id}, Name: {pet.Name}, Status: {pet.Status}");
        }
    }
}
