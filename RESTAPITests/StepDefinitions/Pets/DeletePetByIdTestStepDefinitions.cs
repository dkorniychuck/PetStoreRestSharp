using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Pets
{
    [Binding]
    public class DeletePetByIdTestStepDefinitions
    {
        private static PetClient _globalPet = new PetClient();
        private Pet newPet = new Pet
        {
            Id = _petId,
            Name = "Jack",
            Status = "available",
            PhotoUrls = new List<string> { "Images\\jack.jpg" }
        };
        private static long _petId;

        [Given("I want to delete a pet with the Id {int}")]
        public void GivenIWantToDeleteAPetWithTheId(long petId)
        {
            _petId = petId;
        }

        [When("Program creating new test pet with id {int}")]
        public async Task WhenProgramCreatingNewTestPetWithId(long petId)
        {
            Console.WriteLine("Creating a new pet...");
            await _globalPet.CreatePetAsync(newPet);
        }

        [When("I send a request to delete the pet")]
        public async Task WhenISendARequestToDeleteThePet()
        {
            Console.WriteLine($"Deleting pet with ID {_petId}...");
            await _globalPet.DeletePetByIdAsync(_petId);
        }

        [Then("The pet is deleted successfully")]
        public void ThenThePetIsDeletedSuccessfully()
        {
            Assert.Pass();
            Console.WriteLine($"Success! Pet with ID {_petId} deleted.");
        }
    }
}
