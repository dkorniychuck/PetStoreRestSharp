using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Pets
{
    [Binding]
    public class UpdatePetTestStepDefinitions
    {
        private readonly PetClient _petClient = new PetClient();
        private Pet _updatedPet;
        private long _petId;

        [Given("I want to update an existing pet with ID {long} and the following details:")]
        public void GivenIWantToUpdateAnExistingPetWithIDAndTheFollowingDetails(long petId, Table table)
        {
            _petId = petId;
            _updatedPet = table.CreateInstance<Pet>();
            _updatedPet.Id = _petId;
        }

        [When("I send a request to update the pet")]
        public async Task WhenISendARequestToUpdateThePet()
        {
            var result = await _petClient.UpdatePetAsync(_petId, _updatedPet);
            if (result != null)
            {
                _updatedPet = result;
            }
        }

        [Then("The pet is updated successfully with the new details")]
        public void ThenThePetIsUpdatedSuccessfullyWithTheNewDetails()
        {
            Assert.That(_updatedPet, Is.Not.Null);
            Assert.That(_updatedPet.Id, Is.EqualTo(_petId));
        }
    }
}
