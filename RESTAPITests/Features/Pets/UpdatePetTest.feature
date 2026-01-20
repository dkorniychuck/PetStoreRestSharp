Feature: UpdatePetTest

A short summary of the feature

@tag1
Scenario: I want to update a pet successfully
	Given I want to update an existing pet with ID 3 and the following details:
		| Name | Status | PhotoUrls       |
		| Max  | sold   | Images\\max.jpg |
	When I send a request to update the pet
	Then The pet is updated successfully with the new details