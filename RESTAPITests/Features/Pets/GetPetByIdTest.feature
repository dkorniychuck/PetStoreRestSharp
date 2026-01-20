Feature: GetPetByIdTest

A short summary of the feature

@Pet
Scenario: I want to get a pet by ID successfully
	Given I want to get a pet with the Id 9
	When I send a request to get the pet
	Then The pet details are returned successfully with the correct Id