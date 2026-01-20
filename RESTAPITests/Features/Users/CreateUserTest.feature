Feature: CreateUserTest

A short summary of the feature

@User
Scenario: I want to create a user successfully
	Given I want to create a user with the following details:
		| Id | Username | FirstName | LastName | Email                | Password    | Phone        | UserStatus |
		|  1 | john_doe | John      | Doe      | john.doe@example.com | password123 | 123-456-7890 |          0 |  
	When I send a request to create the user
	Then The user is created successfully