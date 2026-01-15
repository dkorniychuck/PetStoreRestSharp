using PetStoreRestSharp.Models;
using RestSharp;

namespace PetStoreRestSharp.Clients
{
    public class PetClient
    {
        private readonly RestClient _client;

        public PetClient()
        {
            _client = new RestClient("https://petstore.swagger.io/v2/");
        }

        public async Task<Pet?> GetPetByIdAsync(long petId)
        {
            var request = new RestRequest($"pet/{petId}", Method.Get);

            var response = await _client.ExecuteAsync<Pet>(request);
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error retrieving pet with ID {petId}: {response.ErrorMessage}");
            }
        }
        public async Task<Pet?> CreatePetAsync(Pet newPet)
        {
            var request = new RestRequest("pet", Method.Post);
            request.AddJsonBody(newPet);

            var response = await _client.ExecuteAsync<Pet>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error creating pet: {response.ErrorMessage}");
            }
        }
        public async Task<Pet?> UpdatePetAsync(long petId, Pet updatedPet)
        {
            var request = new RestRequest("pet", Method.Put);
            request.AddJsonBody(updatedPet);

            var response = await _client.ExecuteAsync<Pet>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error updating pet with ID {petId}: {response.ErrorMessage}");
            }
        }
        public async Task<Pet?> FindByStatusAsync(string status)
        {
            var request = new RestRequest("pet/findByStatus", Method.Get);
            var response = await _client.ExecuteAsync<List<Pet>>(request.AddParameter("status", status));
            if (response.IsSuccessful)
            {
                return response.Data?.FirstOrDefault();
            }
            else
            {
                throw new Exception($"Error finding pets by status '{status}': {response.ErrorMessage}");
            }
        }
        public async Task<Pet?> CreatePetByIdAsync(Pet newPet, long petId)
        {
            var request = new RestRequest($"pet/{petId}", Method.Post);
            request.AddJsonBody(newPet);

            var response = await _client.ExecuteAsync<Pet>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error creating pet with ID {petId}: {response.ErrorMessage}");
            }
        }
        public async Task<Pet?> DeletePetByIdAsync(long petId)
        {
            var request = new RestRequest($"pet/{petId}", Method.Delete);
            Pet buffPet = await GetPetByIdAsync(petId);
            var response = await _client.ExecuteAsync<Pet>(request);

            if (response.IsSuccessful)
            {
                await CreatePetAsync(buffPet);
                return response.Data;
            }
            else
            {
                throw new Exception($"Error deleting pet with ID {petId}: {response.ErrorMessage}");
            }
        }
        public async Task<Pet?> UploadPetImageByIdAsync(long petId, string imagePath)
        {
            var request = new RestRequest($"pet/{petId}/uploadImage", Method.Post);
            request.AddFile("file", imagePath);

            var response = await _client.ExecuteAsync<Pet>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error uploading image for pet with ID {petId}: {response.ErrorMessage}");
            }
        }
    }
}