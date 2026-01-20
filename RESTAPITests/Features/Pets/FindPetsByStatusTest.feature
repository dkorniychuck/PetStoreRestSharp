Feature: FindPetsByStatusTest

A short summary of the feature

@Pet
Scenario: I want to find pets by status successfully
	Given I want to find pets with the status "available"
	When I send a request to find pets by status
	Then The pets are returned successfully with the status "available"	