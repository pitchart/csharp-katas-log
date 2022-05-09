# Test Data Builders

![IMAGE](../images/GrowingObjectOrientedSoftwareGuidedByTests.PNG)

[Copyright:[Growing Object-Oriented Software, Guided by Tests](http://www.informit.com/store/growing-object-oriented-software-guided-by-tests-9780321503626), 
by [Nat Pryce](http://natpryce.com/bio.html) and [Steve Freeman](https://www.higherorderlogic.com/)]

## Summary

'Test Data Builders' is a technique that leverages on the [Builder Pattern](https://en.wikipedia.org/wiki/Builder_pattern#C#) 
to construct complex objects in tests.  
With 'Test Data Builders' we can omit fields or properties that do not 
contribute to the behavior of the object being tested.  
A test data builder class has the following features: 

1. A field for each constructor parameter 
1. The fields are initialized to a default safe value
1. Fluent public methods to override the default values
1. A 'build' method that returns an instance of object initialized with 
the fields' values. 

## Examples

Below is an example of a TestBuilder for the Country object from our code:

```csharp
using Application.Domain.Country;
using static Application.Domain.Country.Currency;
using static Application.Domain.Country.Language;

namespace Application.Tests
{
    public class CountryTestBuilder
    {
        private string _name = "";
        private Currency _currency = UsDollar;
        private Language _language = English;
      
        public static CountryTestBuilder ACountry() => new CountryTestBuilder();

        public CountryTestBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CountryTestBuilder WithCurrency(Currency currency)
        {
            _currency = currency;
            return this;
        }

        public CountryTestBuilder WithLanguage(Language language)
        {
            _language = language;
            return this;
        }

        public Country Build() => new Country(_name, _currency, _language);
    }
}
```

By using the above builder, we can now easily create a country instance 
for France with this code: 
> Note that using the static imports made our code even clearer and shorter    

```csharp
using Xunit;
using static Application.Domain.Country.Currency;
using static Application.Domain.Country.Language;
using static Application.Tests.CountryTestBuilder; 
        
[Fact]
public void Test()
{
    var france = ACountry()
        .WithName("France")
        .WithCurrency(Euro)
        .WithLanguage(French)
        .Build();
}
```

## Best Practices 
### Where to place the Test Data Builders?
There is no definite answer for that. But, as mentioned earlier, the Test Data
Builder is based on the Builder pattern. In general, it is better to have the 
builder next to the class it is building.   
Thus, with Test Data Builders, it would be better for our builders to be in the
same package/namespace as a real class, but in the test structure.
to its tests. 

## Benefits

Mainly, Test Data Builders helps us create tests that are expressive and 
more resilient to change. Test Data Builders achieve this by: 

1. Wrapping up most of the syntax noise when creating new objects 
1. Making the default case simple, and special cases not much complicated
1. Protecting tests against changes in the object structure. Existing tests
will not fail if new fields were added to existing objects.
1. Making test code more readable and easier to spot the errors
1. Removes a lot of duplication between tests 
1. Makes writing new tests easier 


## Advanced Usage 

### Creating Similar Objects 
Test Data Builders can help create similar objects in a cleaner way. 

For example, assume we want to create country instances for France and Germany. 
Knowing that both have Euro as a currency, we can do the following: 

```charp
using Xunit;
using static Application.Domain.Country.Currency;
using static Application.Domain.Country.Language;
using static Application.Tests.CountryTestBuilder;
   
[Fact]
public void Test()
{
    var europeCountryBuilder = ACountry().WithCurrency(Euro);

    var france = europeCountryBuilder
        .WithName("France")
        .WithLanguage(French)
        .Build();

    var germany = europeCountryBuilder
        .WithName("Germany")
        .WithLanguage(German)
        .Build();
}
```

In most cases with more complex code, this approach will also help get rid of 
duplicated code in tests!

### Passing Builders as Parameters 
We can also pass Test Data Builders as parameters to other Test Data Builders. 

For example, the Author class has Country as one of its fields. Thus, its 
builder class should contain an instance of the respective Country as well. 
Instead of passing an instance of Country as parameter to the withCountry 
method, we can pass an instance of CountryTestBuilder as shown below: 

```csharp
public class AuthorTestBuilder
{
    private string _name = "";
    private CountryTestBuilder _countryTestBuilder;

    public static AuthorTestBuilder AnAuthor() => new AuthorTestBuilder();

    public AuthorTestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public AuthorTestBuilder WithCountry(CountryTestBuilder countryTestBuilder)
    {
        _countryTestBuilder = countryTestBuilder;
        return this;
    }

    public Author Build() => new Author(_name, _countryTestBuilder.Build());
}
```

Here is an example of how to build an instance of the Author class:

```csharp 
[Fact]
public void Test()
{
    var author = AnAuthor()
        .WithName("Victor Hugo")
        .WithCountry(ACountry()
            .WithName("France")
            .WithCurrency(Euro)
            .WithLanguage(French))
        .Build();
}
```

## Variations

### Test Constants
Another approach that can help reduce duplication in the tests is by using 
Tests Constants. Those constants can be initialized: 
1. using the Test Data Builder or calling constructor directly 
1. in a separate class or the Test Class itself.

For example, we can initialize the instances of France and Germany this way:

```csharp
using Application.Domain.Country;
using static Application.Domain.Country.Currency;
using static Application.Domain.Country.Language;
using static Application.Tests.CountryTestBuilder;

namespace Application.Tests
{
    public sealed class TestConstants
    {
        public readonly Country FRANCE = new Country("France", Euro, French);

        public readonly Country GERMANY = ACountry()
            .WithName("Germany")
            .WithCurrency(Euro)
            .WithLanguage(German)
            .Build();
    }
}
```

### Wrapping dependencies in small test objects

Objects in legacy code are often very messy! It is very common to have an
object you need to instantiate in your test doing some problematic side
effect in its constructor. Loading something from the DB is the canonical
example. We cannot use Test Data Builders by the book in this situation.

We have a small example of this in this codebase, with the [ReportGenerator](../../Application/Report/ReportGenerator.cs)
constructor calling the [MainRepository](../../Application/MainRepository.cs)
singleton directly.

Here's a technique inspired from [Working Effectively with Legacy Code](https://www.r7krecon.com/legacy-code), by [Michael C. Feathers](https://www.r7krecon.com/)

* Find a place where you can inject a different implementation (here,
  [IRepository](../../Application/Storage/IRepository.cs))
* Write an in-memory fake implementation of this implementation (here, it
  already exists in [InMemoryRepository](../../Application.Tests/Storage/InMemoryRepository.cs))
* Inject it before the test

```csharp
public class AppTest : IDisposable
{
    public AppTest()
    {
        MainRepository.Override(new InMemoryRepository());
    }
}
```

* Remove the fake after the test

```csharp
namespace Application.Tests
{
    public class AppTest : IDisposable
    {
        public void Dispose()
        {
            MainRepository.Reset();
        }
    }
}
```

One drawback of this solution is that we must not forget to reset the injected
dependency after each test.

Here we are using [xUnit shared context capabilities](https://xunit.github.io/docs/shared-context.html).

### Dealing with cyclic dependencies between objects

Cyclic dependency between objects is very common in Legacy code. That adds 
complexity to the testing phase.   
Here again, test data builders can help us!   
Assume you have 2 objects that are cyclically dependent: 
1. Create a Test Data Builder for each class 
1. Create a parent Test Data Builder and let it handle creating the cyclic 
dependency between the objects. 

Be aware that in this case things might become a bit messy especially if you 
have a big number of interdependent objects!  

## Book References
1. [Growing Object-Oriented Software, Guided by Tests](http://www.informit.com/store/growing-object-oriented-software-guided-by-tests-9780321503626), 
by [Nat Pryce](http://natpryce.com/bio.html) and [Steve Freeman](https://www.higherorderlogic.com/)
2. [Working Effectively with Legacy Code](https://www.r7krecon.com/legacy-code), by [Michael C. Feathers](https://www.r7krecon.com/)