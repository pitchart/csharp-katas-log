using System;
using LanguageExt;
using System.ComponentModel.DataAnnotations;
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
        return FindUser(id)
            .Map(u => (accountId: _twitterService.Register(u.Email, u.Name), user: u))
            .Map(o =>
            {
                _userService.UpdateTwitterAccountId(o.user.Id, o.accountId);
                return o.user;
            })
            .Map(Authenticate())
            .Map(Tweet())
            .Map(Log())
            .IfFail(ex =>
                {
                    _businessLogger.LogFailureRegister(id, ex);
                    return null;
                });
    }

    private Func<(string url, User user), string> Log()
    {
        return o =>
        {
            _businessLogger.LogSuccessRegister(o.user.Id);
            return o.url;
        };
    }

    private Func<(string token, User user), (string url, User user)> Tweet()
    {
        return o => (url: _twitterService.Tweet(o.token, "Hello I am " + o.user.Name), o.user);
    }

    private Func<User, (string token, User user)> Authenticate()
    {
        return u => (token: _twitterService.Authenticate(u.Email, u.Password), user: u);
    }

    private Try<User> FindUser(Guid id)
    {
        return Try(() => _userService.FindById(id));
    }

}
