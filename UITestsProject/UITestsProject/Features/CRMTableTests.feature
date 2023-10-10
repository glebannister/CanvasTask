Feature: CRMTableTests

@CrmUiTest
@UIAuthorization
@QuitWebDriver
Scenario: ContactsTableValidation
	When I go to 'SalesMarketing' and 'Contacts' page
	Then Contacts page is opened
	Then I verify contacts in contacts table
	| Name | AccountName | EmailAndPhone | Category | RowIndex |
	|      |             |               |          | 1        |
	|      |             |               |          | 2        |
