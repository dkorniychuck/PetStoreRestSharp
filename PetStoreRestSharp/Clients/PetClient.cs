using PetStoreRestSharp.Models;
using RestSharp;
using System.Net;

namespace PetStoreRestSharp.Clients
{
    public class PetClient : BaseClient
    {
        public PetClient() : base(new Uri("https://petstore.swagger.io/v2/")) { }

        public async Task<Pet?> GetPetByIdAsync(long petId)
        {
            var pet = ExecuteWithDeserialization<Pet>(Method.Get, $"pet/{petId}", null, HttpStatusCode.OK);
            return await Task.FromResult(pet);
        }

        public async Task<Pet?> CreatePetAsync(Pet newPet)
        {
            var pet = ExecuteWithDeserialization<Pet>(Method.Post, "pet", newPet, HttpStatusCode.OK);
            return await Task.FromResult(pet);
        }

        public async Task<Pet?> UpdatePetAsync(long petId, Pet updatedPet)
        {
            var pet = ExecuteWithDeserialization<Pet>(Method.Put, "pet", updatedPet, HttpStatusCode.OK);
            return await Task.FromResult(pet);
        }

        public async Task<Pet?> FindByStatusAsync(string status)
        {
            var request = new RestRequest("pet/findByStatus", Method.Get);
            request.AddParameter("status", status);
            var response = Execute(request, "pet/findByStatus", null, HttpStatusCode.OK);
            return await HandleResponseAsync(response, async () =>
            {
                var list = DeserializeResponse<List<Pet>>(response);
                return list?.FirstOrDefault();
            }, $"Error finding pets by status '{status}'");
        }

        public async Task<Pet?> CreatePetByIdAsync(Pet newPet, long petId)
        {
            var pet = ExecuteWithDeserialization<Pet>(Method.Post, $"pet/{petId}", newPet, HttpStatusCode.OK);
            return await Task.FromResult(pet);
        }

        public async Task<Pet?> DeletePetByIdAsync(long petId)
        {
            var buffPet = await GetPetByIdAsync(petId);
            var response = ExecuteWithoutDeserialization(Method.Delete, $"pet/{petId}", null, HttpStatusCode.OK);
            return await HandleResponseAsync(response, async () =>
            {
                if (buffPet != null)
                {
                    await CreatePetAsync(buffPet);
                }
                return (Pet?)null;
            }, $"Error deleting pet with ID {petId}");
        }

        public async Task<Pet?> UploadPetImageByIdAsync(long petId, string imagePath)
        {
            var request = new RestRequest($"pet/{petId}/uploadImage", Method.Post);
            request.AddFile("file", imagePath);
            var response = Execute(request, $"pet/{petId}/uploadImage", null, HttpStatusCode.OK);
            var pet = await HandleResponseAsync(response, async () => DeserializeResponse<Pet>(response),
            $"Error uploading image for pet with ID {petId}");
            return await Task.FromResult(pet);
        }
    }
}