Feature: CreatePetByIdTest

A short summary of the feature

@Pet
Scenario: I want to create a pet by ID successfully
	Given I want to create a pet with following details:
		| Id | Name  | Status    | PhotoUrls         |
		|  6 | Bella | available | Images\\bella.jpg |
	When I send a request to create a pet by ID
	Then The pet is created successfully with the Id 6