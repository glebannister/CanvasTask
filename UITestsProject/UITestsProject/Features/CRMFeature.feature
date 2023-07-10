Feature: CRMFeature

#Background: 
#	Given I navigate to CRM login page
#		And I pass the authorization
#		And Home and Actions page is opened

@UIAuthorization
@QuiteWebDriver
Scenario: CreateContact
	Given I navigate to CRM login page
		And I pass the authorization
		And Home and Actions page is opened
	When I go to Sales & Marketing 'Contacts'
	Then Contacts page is opened
	When I click on Create button 
	Then New contact page is opened
	When I create a new contact
		| FirstName | LastName  | Role | CustomersCategory    |
		| Napoleon5  | Bonaparte | CEO  | Customers, Suppliers |
		And I save a new contact
	Then Created contact page is opened
	  And I check that the contact has proper values