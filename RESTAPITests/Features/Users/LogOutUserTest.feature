Feature: LogOutUserTest

A short summary of the feature

@User
Scenario: I want to log out a user successfully
	Given I want to log out a user
	When I send a request to log out the user
	Then The user is logged out successfully