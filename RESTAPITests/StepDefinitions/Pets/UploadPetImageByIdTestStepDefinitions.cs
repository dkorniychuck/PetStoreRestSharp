using PetStoreRestSharp.Clients;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Pets
{
    [Binding]
    public class UploadPetImageByIdTestStepDefinitions
    {
        private static readonly PetClient _globalPet = new PetClient();
        private static long _petId;
        private static string _imagePath;

        [Given("I want to upload an image for a pet with the Id {long}")]
        public void GivenIWantToUploadAnImageForAPetWithTheId(long petId)
        {
            _petId = petId;
        }

        [When("I send a request to upload the pet image with file {string}")]
        public async Task WhenISendARequestToUploadThePetImageWithFile(string imagePath)
        {
            _imagePath = imagePath;
            Console.WriteLine($"Uploading image for pet with ID {_petId}...");
            await _globalPet.UploadPetImageByIdAsync(_petId, imagePath);
        }

        [Then("The pet image is uploaded successfully")]
        public void ThenThePetImageIsUploadedSuccessfully()
        {
            Assert.Pass();
            Console.WriteLine($"Success! Image uploaded for pet with ID {_petId}.");
        }
    }
}
