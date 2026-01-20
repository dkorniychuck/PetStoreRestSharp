Feature: DeleteOrderByIdTest

A short summary of the feature

@Order
Scenario: I want to delete an order by ID successfully
	Given I want to delete an order with the Id 13
	When Program creating new test order with pet id 13
	When I send a request to delete the order
	Then The order is deleted successfully