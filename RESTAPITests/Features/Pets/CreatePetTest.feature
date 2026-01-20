Feature: CreatePetTest

A short summary of the feature

@Pet
Scenario: I want to create a pet successfully	
	Given I want to create a new pet with folowing details:
		| Name | Status    | PhotoUrls        |
		| Jack | available | Images\\jack.jpg |
	When I send a request to create the pet
	Then The pet is created successfully with a valid pet ID