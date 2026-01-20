Feature: GetOrderByIdTest

A short summary of the feature

@Order
Scenario: I want to get an order by ID successfully
	Given I want to get an order with the Id 3
	When I send a request to get the order
	Then The order details are returned successfully with the correct Id
