Feature: Create new product
	As user
	I want to create new product

@mytag
Scenario: Create new product
	Given I open products list page
	When I create new product with param "Monster Energy", "Beverages", "Exotic Liquids", "73.0000", "1", "1000", "1", "false"
	Then the list of products should contained "Monster Energy" position 