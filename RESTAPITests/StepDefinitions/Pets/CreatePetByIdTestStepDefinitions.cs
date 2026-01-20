using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Pets
{
    [Binding]
    public class CreatePetByIdTestStepDefinitions
    {
        private static PetClient _globalPet = new PetClient();
        private Pet newPet;
        private long _petId;

        [Given("I want to create a pet with following details:")]
        public void GivenIWantToCreateAPetWithFollowingDetails(DataTable dataTable)
        {
            _petId = dataTable.CreateInstance<Pet>().Id;
            newPet = dataTable.CreateInstance<Pet>();
        }


        [When("I send a request to create a pet by ID")]
        public async Task WhenISendARequestToCreateAPetByID()
        {
            Console.WriteLine($"Creating a new pet with ID {_petId}...");
            var createdPet = await _globalPet.CreatePetAsync(newPet);
        }

        [Then("The pet is created successfully with the Id {int}")]
        public void ThenThePetIsCreatedSuccessfullyWithTheId(int p0)
        {
            Assert.That(newPet, Is.Not.Null);
            Assert.That(newPet.Id, Is.EqualTo(_petId));
        }

    }
}
