using System;
using System.Threading.Tasks;
using FluentAssertions;
using LanguageExt;
using Xunit;
using static LanguageExt.Prelude;

namespace language_ext.kata.tests
{
    public class TryExercises : PetDomainKata
    {
        private const string SuccessMessage = "I m a fucking genius the result is ";

        private static Try<int> Divide(int x, int y)
            => Try(() => x / y);

        [Fact]
        public void GetTheResultOfDivide()
        {
            // Divide x = 9 by y = 2
            Try<int> tryResult = Divide(9, 2);
            int result = 0;

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
            int result = 0;

            result.Should().Be(7);
        }

        [Fact]
        public void DivideByZeroIsAlwaysAGoodIdea()
        {
            // Divide x by 0 and get the result
            int x = 1;

            Func<int> divideByZero = () => 0;

            divideByZero.Should().Throw<DivideByZeroException>();
        }

        [Fact]
        public void DivideByZeroOrElse()
        {
            // Divide x by 0, on exception returns 0
            int x = 1;
            int result = -1;

            result.Should().Be(0);
        }

        [Fact]
        public void MapTheFailure()
        {
            // Divide x by 0, log the failure message to the console and get 0
            int x = 1;

            int result = -1;

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

            var result = -1;

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

            int result = -1;

            result.Should().Be(1);
        }

        [Fact]
        public void TryAndReturnOption()
        {
            // Create a Divide function that return an Option on Divide
            // If something fails -> return None
            // Can be useful sometimes
            var result = 0;
            result.Should().Be(3);
        }

        [Fact]
        public async Task TryOnAsync()
        {
            // Create a Divide function that return a TryAsync
            var result = 1;
            result.Should().Be(0);
        }
    }
}
