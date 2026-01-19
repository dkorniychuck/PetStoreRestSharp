using PetStoreRestSharp.Clients;
using PetStoreRestSharp.Models;

namespace RESTAPITests;

[TestFixture]
public class UserTests
{
    private static UserClient _globalUser = new UserClient();

    private static User user1 = new User
    {
        Id = 1,
        Username = "john_doe",
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        Password = "password123",
        Phone = "123-456-7890",
        UserStatus = 0
    };

    private static User user2 = new User
    {
        Id = 2,
        Username = "jane_smith",
        FirstName = "Jane",
        LastName = "Smith",
        Email = "jane.smith@example.com",
        Password = "password456",
        Phone = "987-654-3210",
        UserStatus = 0
    };

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task CreateUserWithListTest()
    {
        // Arrange
        var users = new List<User> { user1, user2 };

        // Act
        Console.WriteLine("Creating new user with list...");
        var createdUsers = await _globalUser.CreateUserWithListAsync(users);

        // Assert
        Assert.That(createdUsers, Is.Not.Null);

        foreach (var user in users)
        {
            Console.WriteLine("Success! New User ID: " + user.Id);
        }
    }

    [Test]
    public async Task GetUserByUsernameTest()
    {
        // Arrange
        string username = user2.Username;

        // Act
        Console.WriteLine($"Getting user with username {username}...");
        User user = await _globalUser.GetUserByUsernameAsync(username);

        // Assert
        Assert.That(user, Is.Not.Null);
        Assert.That(user.Username, Is.EqualTo(username));

        Console.WriteLine($"User ID: {user.Id}, Username: {user.Username}, First Name: {user.FirstName}, Last Name: {user.LastName}, Email: {user.Email}");
    }

    [Test]
    public async Task UpdateUserTest()
    {
        // Arrange
        string username = user1.Username;
        var updatedUser = user2;

        // Act
        Console.WriteLine("Updating user with username " + username + "...");
        var user = await _globalUser.UpdateUserAsync(username, updatedUser);

        // Assert
        Assert.That(user, Is.Not.Null);

        Console.WriteLine("User updated successfully.");
    }

    [Test]
    public async Task DeleteUserByUsernameTest()
    {
        // Arrange
        string username = user1.Username;

        await _globalUser.CreateUserAsync(user1);

        // Act
        Console.WriteLine($"Deleting user with username {username}...");
        var result = await _globalUser.DeleteUserByUsernameAsync(username);

        // Assert
        Assert.That(result, Is.Null);

        Assert.ThrowsAsync<HttpRequestException>(async () => await _globalUser.GetUserByUsernameAsync(username));

        Console.WriteLine("User deleted successfully: " + username);
    }

    [Test]
    public async Task LogInUserTest()
    {
        // Arrange
        string username = user1.Username;
        string password = user1.Password;

        // Act
        Console.WriteLine($"Logging in user with username {username}...");
        var user = await _globalUser.LogInUserAsync(username, password);

        // Assert
        Assert.That(user, Is.Not.Null);

        Console.WriteLine("User logged in successfully: " + username);
    }

    [Test]
    public async Task LogOutUserTest()
    {
        // Arrange

        // Act
        Console.WriteLine("Logging out user...");
        var user = await _globalUser.LogOutUserAsync();

        // Assert
        Assert.That(user, Is.Not.Null);

        Console.WriteLine("User logged out successfully.");
    }

    [Test]
    public async Task CreateUserWithArrayTest()
    {
        // Arrange
        var users = new User[] { user1, user2 };

        // Act
        Console.WriteLine("Creating new user with array...");
        var createdUsers = await _globalUser.CreateUserWithArrayAsync(users);

        // Assert
        Assert.That(createdUsers, Is.Not.Null);

        foreach (var user in users)
        {
            Console.WriteLine("Success! New User ID: " + user.Id);
        }
    }

    [Test]
    public async Task CreateUserTest()
    {
        // Arrange
        var user = user2;

        // Act
        Console.WriteLine("Creating new user...");
        var createdUser = await _globalUser.CreateUserAsync(user);

        // Assert
        Assert.That(createdUser, Is.Not.Null);
        Assert.That(createdUser.Id, Is.EqualTo(user.Id));

        Console.WriteLine("Success! New User ID: " + createdUser.Id);
    }
}