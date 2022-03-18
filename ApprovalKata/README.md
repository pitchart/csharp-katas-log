# Approval CSharp kata
## Objectives
* Discover how and why use an object-object mapper library
* Practice Approval testing approach and discover how powerful it can be with several Use Cases :
  * Check mappings
  * Check API results in Integration Tests
  * Check non deterministic data
  * Combination approvals

## Prerequisites
* .NET 6
* Your favorite IDE
* Access to nuget.org

## Libraries
* Object-object mapper : [`AutoMapper`](https://automapper.org/)
* Approval Testing : [`Verify`](https://github.com/VerifyTests/Verify)
* Test Framework : [`xUnit`](https://xunit.net/)
* Assertions : [`FluentAssertions`](https://fluentassertions.com/)

## Step-by-step kata
### 1) Object-object mapper
* Fix the test `Should_Map_Employee_To_EmployeeEntity` by using `Auto-Mapper`
  * What is surprising you ?
  * How could it be helpful in your current projects ?
* Add a new "feature" that brings mapping from `PersonAccount` to `IndividualParty`
  * Discuss how easy it is to add new mappings

### 2) Approval Testing
Also called : Characterization Tests OR Snapshot Tests or Golden Master

> A picture’s worth a 1000 tests.

* Unit testing assertions can be difficult to use and long to write
* Approval tests simplify this by taking a snapshot of the results / confirming that they have not changed at each run

This technique can be used on :
* On any new code
* On legacy code

#### Check your mapping
* Add a new test to check this mapping `PersonAccount -> IndividualParty` by using the `Verify` library
  * What do you think about it ?

#### Integration Tests with Verify
* Create a `Controller` containing a GET method returning `IndividualParties`
  * Hardcoded once by using `DataBuilder` (Capone / Mesrine)
  * Check its behavior by using "classical" assertions
  * Check it with `Verify`
  * Compare the effort needed in both cases
  * Discuss the pros and cons of those 2 approaches

#### Non deterministic data
* Create a new `Controller` containing a GET method returning `Montana`
  * How do you handle non-deterministic data in your tests ?
  * Use `Verify` to check your API result

#### Refactor legacy code
We have an improvable piece of code in our code base :
```c#
public static Template FindTemplateFor(string documentType, string recordType)
{
    foreach (var dtt in TemplateMappings())
    {
        if (dtt.DocumentType.ToString().Equals(documentType, StringComparison.InvariantCultureIgnoreCase) &&
            dtt.RecordType.ToString().Equals(recordType, StringComparison.InvariantCultureIgnoreCase))
        {
            return dtt;
        }
        else if (dtt.DocumentType.ToString()
                     .Equals(documentType, StringComparison.InvariantCultureIgnoreCase) &&
                 dtt.RecordType.ToString().Equals("ALL"))
        {
            return dtt;
        }
    }

    throw new ArgumentException("Invalid Document template type or record type");
}
```

* Before refactoring it we need to add some tests
  * Add at least 2 Test Cases : Successful one and an Edge Case
* Let's use the power of ApprovalTesting to check all the possible combinations without effort
  
* ![cheat sheet](img/approval-testing-cheatsheet.png)
    * Generate combinations and have only 1 `verified` file