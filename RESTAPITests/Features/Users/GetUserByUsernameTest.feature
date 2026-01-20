Feature: GetUserByUsernameTest

A short summary of the feature

@User
Scenario: I want to get a user by username
	Given I want to get a user by following username "john_doe"
	When I send a request to get the user 
	Then The user details are returned successfully with the correct username
