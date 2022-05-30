using System;
using FluentAssertions;
using language_ext.kata.Account;
using Moq;
using Xunit;

namespace language_ext.kata.tests
{
    public class RealLifeExample
    {
        private static readonly Guid BudSpencer = Guid.Parse("376510ae-4e7e-11ea-b77f-2e728ce88125");
        private static readonly Guid UnknownUser = Guid.Parse("376510ae-4e7e-11ea-b77f-2e728ce88121");
        private readonly AccountService _accountService;
        private readonly Mock<IBusinessLogger> _loggerMock = new Mock<IBusinessLogger>();

        public RealLifeExample() => _accountService =
            new AccountService(
                new UserService(),
                new TwitterService(),
                _loggerMock.Object);

        [Fact]
        public void Register_BudSpencer_should_return_a_new_tweet_url()
        {
            var tweetUrl = _accountService.Register(BudSpencer);
            _loggerMock.Verify(_=>_.LogFailureRegister(It.IsAny<Guid>(),It.IsAny<Exception>()),Times.Never);
            _loggerMock.Verify(_=>_.LogSuccessRegister( BudSpencer),Times.Once);
            tweetUrl.Should().Be("TweetUrl", tweetUrl);
        }

        [Fact]
        public void Register_an_unknown_user_should_return_an_error_message()
        {
            var tweetUrl = _accountService.Register(UnknownUser);
            _loggerMock.Verify(_=>_.LogFailureRegister(UnknownUser,It.IsAny<InvalidOperationException>()),Times.Once);
            _loggerMock.Verify(_=>_.LogSuccessRegister( It.IsAny<Guid>()),Times.Never);
            tweetUrl.Should().BeNull();
        }
    }
}
