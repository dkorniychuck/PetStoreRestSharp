using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;
using Reqnroll;

namespace RESTAPITests.StepDefinitions.Orders
{
    [Binding]
    public class CreateOrderTestStepDefinitions
    {
        private static readonly OrderClient _globalOrder = new OrderClient();
        private Order _newOrder;
        private Order _createdOrder;

        [Given("I want to create a new order with the following details:")]
        public void GivenIWantToCreateANewOrderWithTheFollowingDetails(Table table)
        {
            _newOrder = table.CreateInstance<Order>();
        }

        [When("I send a request to create the order")]
        public async Task WhenISendARequestToCreateTheOrder()
        {
            _createdOrder = await _globalOrder.CreateOrderAsync(_newOrder);
        }

        [Then("The order is created successfully with a valid order ID")]
        public void ThenTheOrderIsCreatedSuccessfullyWithAValidOrderID()
        {
            Assert.That(_createdOrder, Is.Not.Null);
            Assert.That(_createdOrder.PetId, Is.EqualTo(_newOrder.PetId));
            Assert.That(_createdOrder.Status, Is.EqualTo("placed"));

            Console.WriteLine("Success! New Order ID: " + _createdOrder.Id);
        }
    }
}
