using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;

namespace RESTAPITests;

[TestFixture]
public class OrderTests
{
    private static OrderClient _globalOrder = new OrderClient();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task CreateOrderTest()
    {
        // Arrange
        var newOrder = new Order
        {
            PetId = 10,
            Quantity = 1,
            Status = "placed",
            Complete = false
        };

        // Act
        Console.WriteLine("Creating a new order...");
        var createdOrder = await _globalOrder.CreateOrderAsync(newOrder);

        // Assert
        Assert.That(createdOrder, Is.Not.Null);
        Assert.That(createdOrder.PetId, Is.EqualTo(newOrder.PetId));
        Assert.That(createdOrder.Status, Is.EqualTo("placed"));

        Console.WriteLine("Success! New Order ID: " + createdOrder.Id);
    }

    [Test]
    public async Task GetOrderByIdTest()
    {
        // Arrange
        long orderId = 2;

        // Act
        Console.WriteLine($"Getting order with ID {orderId}...");
        Order order = await _globalOrder.GetOrderByIdAsync(orderId);

        // Assert
        Assert.That(order, Is.Not.Null);
        Assert.That(order.Id, Is.EqualTo(orderId));

        Console.WriteLine($"Order ID: {order.Id}, Pet ID: {order.PetId} , Quantity: {order.Quantity}, Status: {order.Status}, Complete: {order.Complete}");
    }

    [Test]
    public async Task DeleteOrderByIdTest()
    {
        // Arrange
        long orderId = 10;

        // Act
        Console.WriteLine($"Deleting order with ID {orderId}...");
        await _globalOrder.DeleteOrderByIdAsync(orderId);

        // Assert
        Assert.Pass();
        Console.WriteLine($"Success! Order with ID {orderId} deleted.");
    }
}