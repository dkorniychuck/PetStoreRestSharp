Feature: UpdateUserTest

A short summary of the feature

@User
Scenario: I want to update a user successfully
	Given I want to update a user with the following details:
		| username | firstName | lastName | email                | password    | phone      | userStatus |
		| john_doe | John      | Doe      | john.doe@example.com | password123 | 1234567890 |          1 |
	When I send a request to update the user
	Then The user details are updated successfully with the correct data