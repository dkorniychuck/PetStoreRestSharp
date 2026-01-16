using PetStoreRestSharp.Models;
using RestSharp;
using System.Net;

namespace PetStoreRestSharp.Clients
{
    public class OrderClient : BaseClient
    {
        public OrderClient() : base(new Uri("https://petstore.swagger.io/v2/")) { }

        public async Task<Order?> CreateOrderAsync(Order newOrder)
        {
            var order = ExecuteWithDeserialization<Order>(Method.Post, "store/order", newOrder, HttpStatusCode.OK);
            return await Task.FromResult(order);
        }

        public async Task<Order?> GetOrderByIdAsync(long orderId)
        {
            var order = ExecuteWithDeserialization<Order>(Method.Get, $"store/order/{orderId}", null, HttpStatusCode.OK);
            return await Task.FromResult(order);
        }

        public async Task<Order?> DeleteOrderByIdAsync(long orderId)
        {
            var buffOrder = await GetOrderByIdAsync(orderId);
            var response = ExecuteWithoutDeserialization(Method.Delete, $"store/order/{orderId}", null, HttpStatusCode.OK);
            if (response.IsSuccessful)
            {
                if (buffOrder != null)
                {
                    await CreateOrderAsync(buffOrder);
                }
                return null;
            }
            else
            {
                throw new Exception($"Error deleting order with id: {orderId} : {response.ErrorMessage ?? response.StatusDescription}");
            }
        }
    }
}
