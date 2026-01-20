Feature: DeletePetByIdTest

A short summary of the feature

@Pet
Scenario: I want to delete a pet by ID successfully
	Given I want to delete a pet with the Id 5
	When Program creating new test pet with id 5
	When I send a request to delete the pet
	Then The pet is deleted successfully