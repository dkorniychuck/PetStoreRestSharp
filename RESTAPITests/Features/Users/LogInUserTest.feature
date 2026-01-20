Feature: LogInUserTest

A short summary of the feature

@User
Scenario: I want to log in a user successfully
	Given I want to log in a user with the following credentials:
		| username | password    |
		| john_doe | password123 |
	When I send a request to log in the user
	Then The user is logged in successfully