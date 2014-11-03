Feature: Get Account Details
	In order to deal with customers by viewing account information
	As an accountant
	I want to view account detail by providing account id

@mytag
Scenario: Get account details by providing account id ==> Happy path
	Given I have the following accounts:
	| AccountId | Balance |
	| 1         | 100     |
	| 9         | 900     |
	| 15        | 700     |
	When I ask for details of account with id 9
	Then I should get account with balance 900
