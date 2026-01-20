using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Orders
{
    [Binding]
    public class GetOrderByIdTestStepDefinitions
    {
        private static readonly OrderClient _globalOrder = new OrderClient();
        private Order order;
        long orderId;

        [Given("I want to get an order with the Id {long}")]
        public void GivenIWantToGetAnOrderWithTheId(long orderId)
        {
            orderId = 3;
            this.orderId = orderId;
        }

        [When("I send a request to get the order")]
        public async Task WhenISendARequestToGetTheOrderAsync()
        {
            Console.WriteLine($"Getting order with ID {orderId}...");
            order = await _globalOrder.GetOrderByIdAsync(orderId);
        }

        [Then("The order details are returned successfully with the correct Id")]
        public void ThenTheOrderDetailsAreReturnedSuccessfullyWithTheCorrectId()
        {
            Assert.That(order, Is.Not.Null);
            Assert.That(order.Id, Is.EqualTo(orderId));

            Console.WriteLine($"Order ID: {order.Id}, Pet ID: {order.PetId} , Quantity: {order.Quantity}, Status: {order.Status}, Complete: {order.Complete}");
        }
    }
}
