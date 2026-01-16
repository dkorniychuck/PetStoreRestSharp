using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;

namespace RESTAPITests
{
    [TestFixture]
    public class PetTests
    {
        private static PetClient _globalPet = new PetClient();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetPetByIdTest()
        {
            // Arrange
            int petId = 9;

            // Act
            Console.WriteLine($"Getting pet with ID {petId}...");
            Pet pet = await _globalPet.GetPetByIdAsync(petId);

            // Assert
            Assert.That(pet, Is.Not.Null);
            Assert.That(pet.Id, Is.EqualTo(petId));

            Console.WriteLine($"Pet ID: {pet.Id}, Name: {pet.Name}, Status: {pet.Status}");
        }

        [Test]
        public async Task CreatePetTest()
        {
            // Arrange
            var newPet = new Pet
            {
                Name = "Jack",
                Status = "available",
                PhotoUrls = new List<string> { "Images\\jack.jpg" }
            };

            // Act
            Console.WriteLine("Creating a new pet...");
            var createdPet = await _globalPet.CreatePetAsync(newPet);

            // Assert
            Assert.That(createdPet, Is.Not.Null);
            Assert.That(createdPet.Name, Is.EqualTo(newPet.Name));

            Console.WriteLine("Success! New Pet ID: " + createdPet.Id);
        }

        [Test]
        public async Task UpdatePetTest()
        {
            // Arrange
            int petId = 3;
            var updatedPet = new Pet
            {
                Id = petId,
                Name = "Max",
                Status = "sold",
                PhotoUrls = new List<string> { "Images\\max.jpg" }
            };

            // Act
            Console.WriteLine($"Updating pet with ID {petId}...");
            var pet = await _globalPet.UpdatePetAsync(petId, updatedPet);

            // Assert
            Assert.That(pet, Is.Not.Null);
            Assert.That(pet.Status, Is.EqualTo("sold"));

            Console.WriteLine($"Success! Updated Pet ID: {pet.Id}, Name: {pet.Name}, Status: {pet.Status}");
        }

        [Test]
        public async Task FindPetsByStatusTest()
        {
            // Arrange
            string status = "available";

            // Act
            Console.WriteLine($"Finding pets with status '{status}'...");
            var pet = await _globalPet.FindByStatusAsync(status);

            // Assert
            Assert.That(pet, Is.Not.Null);
            Assert.That(pet.Status, Is.EqualTo(status));

            Console.WriteLine($"Pet ID: {pet.Id}, Name: {pet.Name}, Status: {pet.Status}");
        }

        [Test]
        public async Task CreatePetByIdTest()
        {
            // Arrange
            int petId = 6;
            var newPet = new Pet
            {
                Id = petId,
                Name = "Bella",
                Status = "available",
                PhotoUrls = new List<string> { "Images\\bella.jpg" }
            };

            // Act
            Console.WriteLine($"Creating a new pet with ID {petId}...");
            var createdPet = await _globalPet.CreatePetAsync(newPet);

            // Assert
            Assert.That(createdPet, Is.Not.Null);
            Assert.That(createdPet.Id, Is.EqualTo(petId));

            Console.WriteLine("Success! New Pet ID: " + createdPet.Id);
        }

        [Test]
        public async Task DeletePetByIdTest()
        {
            // Arrange
            int petId = 5;

            // Act
            Console.WriteLine($"Deleting pet with ID {petId}...");
            await _globalPet.DeletePetByIdAsync(petId);

            // Assert
            Assert.Pass();
            Console.WriteLine($"Success! Pet with ID {petId} deleted.");
        }

        [Test]
        public async Task UploadPetImageByIdTest()
        {
            // Arrange
            int petId = 17;
            string imagePath = "Images\\jaddu.jpg";

            // Act
            Console.WriteLine($"Uploading image for pet with ID {petId}...");
            await _globalPet.UploadPetImageByIdAsync(petId, imagePath);

            // Assert
            Assert.Pass();
            Console.WriteLine($"Success! Image uploaded for pet with ID {petId}.");
        }
    }
}