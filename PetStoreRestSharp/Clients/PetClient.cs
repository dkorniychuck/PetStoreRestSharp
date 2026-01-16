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
            if (response.IsSuccessful)
            {
                var list = DeserializeResponse<List<Pet>>(response);
                return list?.FirstOrDefault();
            }
            else
            {
                throw new Exception($"Error finding pets by status '{status}': {response.ErrorMessage ?? response.StatusDescription}");
            }
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
            if (response.IsSuccessful)
            {
                if (buffPet != null)
                {
                    await CreatePetAsync(buffPet);
                }
                return null;
            }
            else
            {
                throw new Exception($"Error deleting pet with ID {petId}: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }

        public async Task<Pet?> UploadPetImageByIdAsync(long petId, string imagePath)
        {
            var request = new RestRequest($"pet/{petId}/uploadImage", Method.Post);
            request.AddFile("file", imagePath);
            var response = Execute(request, $"pet/{petId}/uploadImage", null, HttpStatusCode.OK);
            if (response.IsSuccessful)
            {
                return DeserializeResponse<Pet>(response);
            }
            else
            {
                throw new Exception($"Error uploading image for pet with ID {petId}: {response.ErrorMessage ?? response.StatusDescription}");
            }
        }
    }
}