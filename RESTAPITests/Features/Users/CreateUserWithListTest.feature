Feature: CreateUserWithListTest

A short summary of the feature

@User
Scenario: I want create user with list
	Given I want to create List of user with the following details:
	| Id | Username   | FirstName | LastName | Email                  | Password    | Phone        | UserStatus |
	|  1 | john_doe   | John      | Doe      | john.doe@example.com   | password123 | 123-456-7890 |          0 |
	|  2 | jane_smith | Jane      | Smith    | jane.smith@example.com | password456 | 987-654-3210 |          0 |
	When I send a request to create the list
	Then The list of users is created successfully
