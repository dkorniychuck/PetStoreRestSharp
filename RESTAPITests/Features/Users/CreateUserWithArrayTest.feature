Feature: CreateUserWithArrayTest

A short summary of the feature

@User
Scenario: I want to create users with an array successfully
	Given I want to create an array of users with the following details:
		| Id | Username   | FirstName | LastName | Email                  | Password    | Phone        | UserStatus |
		|  1 | john_doe   | John      | Doe      | john.doe@example.com   | password123 | 123-456-7890 |          0 |
		|  2 | jane_smith | Jane      | Smith    | jane.smith@example.com | password456 | 987-654-3210 |          0 |  
	When I send a request to create the array of users
	Then The users are created successfully