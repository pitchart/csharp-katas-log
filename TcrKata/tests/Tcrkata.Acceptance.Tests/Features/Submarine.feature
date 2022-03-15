Feature: Submarine
Verifying the submarine controls are correct

    @InProgress
    Scenario: Submarine default position
        Given submarine is initialized
        Then submarine depth should be 0
        And submarine position should be 0

    @InProgress
    Scenario: Step 1
        Given submarine is initialized
        When submarine receives command forward 5
        Then submarine depth should be 0
        And submarine position should be 5
        And submarine aim should be 0

    @InProgress
    Scenario: Step 2
        Given submarine is initialized
        And submarine receives command forward 5
        When submarine receives command down 5
        Then submarine depth should be 0
        And submarine position should be 5
        And submarine aim should be 5

    @InProgress
    Scenario: Step 3
        Given submarine is initialized
        And submarine receives command forward 5
        And submarine receives command down 5
        When submarine receives command forward 8
        Then submarine depth should be 40
        And submarine position should be 13
        And submarine aim should be 5

    @InProgress
    Scenario: Step 4
        Given submarine is initialized
        And submarine receives command forward 5
        And submarine receives command down 5
        And submarine receives command forward 8
        When submarine receives command up 3
        Then submarine depth should be 40
        And submarine position should be 13
        And submarine aim should be 2

    @InProgress
    Scenario: Step 5
        Given submarine is initialized
        And submarine receives command forward 5
        And submarine receives command down 5
        And submarine receives command forward 8
        And submarine receives command up 3
        When submarine receives command down 8
        Then submarine depth should be 40
        And submarine position should be 13
        And submarine aim should be 10

    @InProgress
    Scenario: Step 6
        Given submarine is initialized
        And submarine receives command forward 5
        And submarine receives command down 5
        And submarine receives command forward 8
        And submarine receives command up 3
        And submarine receives command down 8
        When submarine receives command forward 2
        Then submarine depth should be 60
        And submarine position should be 15
        And submarine aim should be 10
        And submarine final value should be 900

    @InProgress
    Scenario: Full example
        Given submarine is initialized
        When submarine receives all commands from file /Features/SubmarineCommands.txt
        Then submarine final value should match value from file /Features/SubmarineFinalValue.txt