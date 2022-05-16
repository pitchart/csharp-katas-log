using System;
using LanguageExt;
using static LanguageExt.Prelude;


namespace language_ext.kata.Account;

public class AccountService
{
    private readonly IBusinessLogger _businessLogger;
    private readonly TwitterService _twitterService;
    private readonly UserService _userService;

    public AccountService(
        UserService userService,
        TwitterService twitterService,
        IBusinessLogger businessLogger)
    {
        _userService = userService;
        _twitterService = twitterService;
        _businessLogger = businessLogger;
    }

    public string Register(Guid id)
    {

        Try<string> result = FindUser(id).Bind(u => Try(()=>TweetForNewUser(u)) );

        return result.IfFail(ex =>
        {
            _businessLogger.LogFailureRegister(id, ex);

            return null;
        });
    }

    private string TweetForNewUser(User user)
    {
        var accountId = _twitterService.Register(user.Email, user.Name);

        if (accountId == null) return null;

        var twitterToken = _twitterService.Authenticate(user.Email, user.Password);

        if (twitterToken == null) return null;

        var tweetUrl = _twitterService.Tweet(twitterToken, "Hello I am " + user.Name);

        if (tweetUrl == null) return null;

        _userService.UpdateTwitterAccountId(user.Id, accountId);
        _businessLogger.LogSuccessRegister(user.Id);

        return tweetUrl;
    }

    private Try<User> FindUser(Guid id)
    {
       return Try(()=> _userService.FindById(id));
    }
}
