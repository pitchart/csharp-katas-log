using System;
using System.Threading.Tasks;
using FluentAssertions;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using Xunit;
using Xunit.Abstractions;
using static LanguageExt.Prelude;

namespace language_ext.kata.tests
{
    public class TryExercises : PetDomainKata
    {
        private const string SuccessMessage = "I m a fucking genius the result is ";
        
        private readonly ITestOutputHelper _testOutputHelper;

        public TryExercises(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private static Try<int> Divide(int x, int y)
            => Try(() => x / y);

        [Fact]
        public void GetTheResultOfDivide()
        {
            // Divide x = 9 by y = 2
            Try<int> tryResult = Divide(9, 2);
            int result = tryResult.IfFailThrow();

            result.Should().Be(4);
            tryResult.IsSucc().Should().BeTrue();
            tryResult.IsDefault().Should().BeFalse();
            tryResult.IsFail().Should().BeFalse();
        }

        [Fact]
        public void MapTheResultOfDivide()
        {
            // Divide x = 9 by y = 2 and add z to the result
            int z = 3;
            int result = Divide(9, 2).Map(i => i+z).IfFailThrow();

            result.Should().Be(7);
        }

        [Fact]
        public void DivideByZeroIsAlwaysAGoodIdea()
        {
            // Divide x by 0 and get the result
            int x = 1;

            Func<int> divideByZero = () => Divide(x, 0).IfFail(_ => throw new DivideByZeroException());

            divideByZero.Should().Throw<DivideByZeroException>();
        }

        [Fact]
        public void DivideByZeroOrElse()
        {
            // Divide x by 0, on exception returns 0
            int x = 1;
            int result = Divide(x, 0).IfFail(0);

            result.Should().Be(0);
        }

        [Fact]
        public void MapTheFailure()
        {
            // Divide x by 0, log the failure message to the console and get 0
            int x = 1;

            int result = Divide(x, 0).IfFail(exception =>
            {
                _testOutputHelper.WriteLine(exception.Message);
                return 0;
            });

            result.Should().Be(0);
        }

        [Fact]
        public void MapTheSuccess()
        {
            // Divide x by y
            // log the failure message to the console
            // Log your success to the console
            // Get the result or 0 if exception
            int x = 8;
            int y = 4;

            var result = Divide(x, y).Match(i =>
            {
                _testOutputHelper.WriteLine(SuccessMessage);
                return i;
            }, exception =>
            {
                _testOutputHelper.WriteLine(exception.Message);
                return 0;
            });

            result.Should().Be(2);
        }

        [Fact]
        public void ChainTheTry()
        {
            // Divide x by y
            // Chain 2 other calls to divide with x = previous Divide result
            // log the failure message to the console
            // Log your success to the console
            // Get the result or 0 if exception
            int x = 27;
            int y = 3;

            int result = Divide(x, y)
                .Bind(i => Divide(i, y))
                .Bind(i => Divide(i, y))
                .Match(i =>
            {
                _testOutputHelper.WriteLine(SuccessMessage);
                return i;
            }, exception =>
            {
                _testOutputHelper.WriteLine(exception.Message);
                return 0;
            });

            result.Should().Be(1);
        }

        [Fact]
        public void TryAndReturnOption()
        {
            // Create a Divide function that return an Option on Divide
            // If something fails -> return None
            // Can be useful sometimes
            Func<int, int, Option<int>> DivideOption = (x, y) => Divide(x, y).ToOption();

            var result = DivideOption(9,3).Value();
            result.Should().Be(3);
        }
        
        [Fact]
        public void TryAndReturnOptionWithZero()
        {
            // Create a Divide function that return an Option on Divide
            // If something fails -> return None
            // Can be useful sometimes
            Func<int, int, TryOption<int>> DivideOption = (x, y) => Divide(x, y).ToTryOption();

            //var result = DivideOption(9,0).IfNoneOrFail<int>(none => { return None;}, e => { return None;});
            //result.Should().Be(3);
        }

        [Fact]
        public async Task TryOnAsync()
        {
            // Create a Divide function that return a TryAsync
            Func<int, int, TryAsync<Func<int>>> DivideAsync = (x, y) => TryAsync(() => x / y);
            
            var result = DivideAsync(0, 1);
            var test = await result();
            var resultFinal = test.IfFail(() =>5);
            resultFinal.Invoke().Should().Be(0);
        }
    }
} 
