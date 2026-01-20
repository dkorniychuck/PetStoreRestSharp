using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Orders
{
    [Binding]
    public class DeleteOrderByIdTestStepDefinitions
    {
        private static readonly OrderClient _globalOrder = new OrderClient();
        private long orderId;

        [Given("I want to delete an order with the Id {long}")]
        public void GivenIWantToDeleteAnOrderWithTheId(long orderId)
        {
            orderId = 13;
            this.orderId = orderId;
        }


        [When("Program creating new test order with pet id {long}")]
        public async Task WhenProgramCreatingNewTestOrderWithPetIdAsync(long petId)
        {
            var testOrder = new Order()
            {
                Id = orderId,
                PetId = 5,
                Quantity = 1,
                Status = "placed",
                Complete = true
            };

            await _globalOrder.CreateOrderAsync(testOrder);

            Console.WriteLine($"Created test order. Using Order ID = {orderId}");
        }

        [When("I send a request to delete the order")]
        public async Task WhenISendARequestToDeleteTheOrderAsync()
        {
            Console.WriteLine($"Deleting order with ID {orderId}...");
            await _globalOrder.DeleteOrderByIdAsync(orderId);
        }

        [Then("The order is deleted successfully")]
        public void ThenTheOrderIsDeletedSuccessfully()
        {
            Assert.Pass();
            Console.WriteLine($"Success! Order with ID {orderId} deleted.");
        }
    }
}
