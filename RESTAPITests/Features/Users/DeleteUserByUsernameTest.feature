Feature: DeleteUserByUsernameTest

A short summary of the feature

@User
Scenario: I want to delete a user by username successfully
	Given I want to delete a user with the username "jane_smith"
	When Program creating new test user with the following details:
		| Id | Username   | FirstName | LastName | Email                  | Password    | Phone        | UserStatus |
		|  2 | jane_smith | Jane      | Smith    | jane.smith@example.com | password456 | 987-654-3210 |          0 |
	When I send a request to delete the user
	Then The user is deleted successfully