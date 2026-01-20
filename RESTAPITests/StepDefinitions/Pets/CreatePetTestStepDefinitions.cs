using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Pets
{
    [Binding]
    public class CreatePetTestStepDefinitions
    {
        private static readonly PetClient _globalPet = new PetClient();
        private Pet _newPet;
        private Pet _createdPet;

        [Given("I want to create a new pet with folowing details:")]
        public void GivenIWantToCreateANewPetWithFolowingDetails(DataTable dataTable)
        {
            _newPet = dataTable.CreateInstance<Pet>();
        }

        [When("I send a request to create the pet")]
        public async Task WhenISendARequestToCreateThePet()
        {
            Console.WriteLine("Creating a new pet...");
            _createdPet = await _globalPet.CreatePetAsync(_newPet);
        }

        [Then("The pet is created successfully with a valid pet ID")]
        public void ThenThePetIsCreatedSuccessfullyWithAValidPetID()
        {
            Assert.That(_createdPet, Is.Not.Null);
            Assert.That(_createdPet.Name, Is.EqualTo(_newPet.Name));

            Console.WriteLine("Success! New Pet ID: " + _createdPet.Id);
        }
    }
}
