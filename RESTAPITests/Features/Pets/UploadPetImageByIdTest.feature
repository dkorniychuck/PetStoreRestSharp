Feature: UploadPetImageByIdTest

A short summary of the feature

@tag1
Scenario: I want to upload an image for a pet by ID successfully
	Given I want to upload an image for a pet with the Id 17
	When I send a request to upload the pet image with file "Images\\jaddu.jpg"
	Then The pet image is uploaded successfully