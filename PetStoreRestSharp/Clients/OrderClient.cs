using PetStoreRestSharp.Models;
using RestSharp;

namespace PetStoreRestSharp.Clients
{
    public class OrderClient
    {
        private readonly RestClient _client;

        public OrderClient()
        {
            _client = new RestClient("https://petstore.swagger.io/v2/store/order/");
        }

        public async Task<Order?> CreateOrderAsync(Order newOrder)
        {
            var request = new RestRequest("", Method.Post);
            request.AddJsonBody(newOrder);

            var response = await _client.ExecuteAsync<Order>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error creating order: {response.ErrorMessage}");
            }
        }
        public async Task<Order?> GetOrderByIdAsync(long orderId)
        {
            var request = new RestRequest($"{orderId}", Method.Get);

            var response = await _client.ExecuteAsync<Order>(request);
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"Error getting order with id: {orderId} : {response.ErrorMessage}");
            }
        }
        public async Task<Order?> DeleteOrderByIdAsync(long orderId)
        {
            var request = new RestRequest($"{orderId}", Method.Delete);
            Order buffOrder = await GetOrderByIdAsync(orderId);
            var response = await _client.ExecuteAsync<Order>(request);
            if (response.IsSuccessful)
            {
                CreateOrderAsync(buffOrder);
                return response.Data;
            }
            else
            {
                throw new Exception($"Error deleting order with id: {orderId} : {response.ErrorMessage}");
            }
        }
    }
}
