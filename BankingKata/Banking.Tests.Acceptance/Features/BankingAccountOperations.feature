Feature: Complete account statement

Scenario: Printing statement after deposits and withdrawal
	Given a client makes a deposit of 1000 on 10-01-2012
	And a deposit of 2000 on 13-01-2012
	And a withdrawal of 500 on 14-01-2012
	When she prints her bank statement
	Then she would see
		"""
		date       ||   credit ||    debit ||  balance
		10-01-2012 ||  1000.00 ||          ||  1000.00
		13-01-2012 ||  2000.00 ||          ||  3000.00
		14-01-2012 ||          ||   500.00 ||  2500.00
		"""

Scenario: Client makes a transfer
	Given clientA has a balance of 1000
	And clientB has a balance of 0
	When clientA transfer 400 to clientB
	Then clientA balance should be 600 and clientB balance should be 400

Scenario: Client filters it statement
	Given a client makes a deposit of 1000 on 10-01-2012
	And a deposit of 2000 on 13-01-2012
	And a withdrawal of 500 on 14-01-2012
	When she filters by deposit
	And she prints her bank statement
	Then she would see
		"""
		date       ||   credit ||    debit ||  balance
		10-01-2012 ||  1000.00 ||          ||  1000.00
		13-01-2012 ||  2000.00 ||          ||  3000.00
		"""
	
Scenario: Client filters it statement by withdrawal
	Given a client makes a deposit of 1000 on 10-01-2012
	And a deposit of 2000 on 13-01-2012
	And a withdrawal of 500 on 14-01-2012
	When she filters by withdrawal
	And she prints her bank statement
	Then she would see
		"""
		date       ||   credit ||    debit ||  balance
		14-01-2012 ||          ||   500.00 ||  2500.00
		"""

Scenario: Client open new account
	Given a client makes a deposit of 1000 on 10-01-2012
	When she consults account status
	Then she would see Open status

Scenario: Client close an account
	Given a client makes a deposit of 1000 on 10-01-2012
	When she close her account on 11-01-2012
	And she consults account status
	And she prints her bank statement
	Then she would see Close status
	And she would see
		"""
		date       ||   credit ||    debit ||  balance
		10-01-2012 ||  1000.00 ||          ||  1000.00
		11-01-2012 ||          ||  1000.00 ||     0.00
		"""
	
Scenario: Client get a frozen account
	Given a client makes a deposit of 1000 on 10-01-2012
	And a withdrawal of 1500 on 14-01-2012
	When she consults account status
	Then she would see Frozen status