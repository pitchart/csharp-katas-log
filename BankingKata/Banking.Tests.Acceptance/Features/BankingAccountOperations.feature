Feature: Complete account statement

    Scenario: Printing statement after deposits and withdrawal
        Given a client makes a deposit of 1000 on 10-01-2012
        And a deposit of 2000 on 13-01-2012
        And a withdrawal of 500 on 14-01-2012
        When she prints her bank statement
        Then she would see
        """
        date       ||   credit ||    debit ||  balance
        14-01-2012 ||          ||   500.00 ||  2500.00
        13-01-2012 ||  2000.00 ||          ||  3000.00
        10-01-2012 ||  1000.00 ||          ||  1000.00
        """

    Scenario: Printing statement after deposits and withDifferent amount size
        Given a client makes a deposit of 1000 on 10-01-2012
        And a deposit of 10000.50 on 13-01-2012
        And a withdrawal of 500 on 14-01-2012
        And a withdrawal of 8 on 15-01-2012
        When she prints her bank statement
        Then she would see
        """
        date       ||   credit ||    debit ||  balance
        15-01-2012 ||          ||     8.00 || 10492.50
        14-01-2012 ||          ||   500.00 || 10500.50
        13-01-2012 || 10000.50 ||          || 11000.50
        10-01-2012 ||  1000.00 ||          ||  1000.00
        """

    Scenario: Printing deposit statement only after deposite and withdrawal
        Given a client makes a deposit of 1000 on 10-01-2012
        And a withdrawal of 500 on 12-01-2012
        When she prints her only deposit statement
        Then she would see
        """
        date       ||   credit ||  balance
        10-01-2012 ||  1000.00 ||  1000.00
        """