Feature: Get accont details by account id
	In order to view customer account information
	As a receiptionist 
	I want to Load his data 

@mytag
Scenario: Get account details by providing account id
	Given I have the following accounts:
	| AccountId | Balance |
	| 1         | 100     |
	| 9         | 900     |
	| 15        | 700     |
	When I ask for details of account with id 9
	Then I should get account with id 9 and balance 900