Feature: CreateOrderTest
Tests for the OrderClient

@Order
Scenario: Create new order successfully
	Given I want to create a new order with the following details:
		| PetId | Quantity | Status | Complete |
		|    10 |        1 | placed | false    |
	When I send a request to create the order
	Then The order is created successfully with a valid order ID