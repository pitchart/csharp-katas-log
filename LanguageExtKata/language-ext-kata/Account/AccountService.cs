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

        Try<string> result = FindUser(id)
            .Bind(RegisterAndUpdateAccount)
            .Bind(u => Try(() => TweetForNewUser(u)));

        return result.IfFail(ex =>
        {
            _businessLogger.LogFailureRegister(id, ex);

            return null;
        });
    }

    private string TweetForNewUser(Option<User> user)
    {
        return user
            .Map(u =>
                (token: _twitterService.Authenticate(u.Email, u.Password),user: u)
            )
            .Map(o=> (url:_twitterService.Tweet(o.token, "Hello I am " + o.user.Name),o.user))
            .Map(o =>
            {
                 _businessLogger.LogSuccessRegister(o.user.Id);
                 return o.url;
            })
            .IfNone(default(string));
    }

    private Try<User> FindUser(Guid id)
    {
        return Try(() => _userService.FindById(id));
    }

    private Try<Option<User>> RegisterAndUpdateAccount(User user)
    {
        return Try(() =>
        {
            return Some(_twitterService.Register(user.Email, user.Name))
            .Bind(accountId =>
            {
                _userService.UpdateTwitterAccountId(user.Id, accountId);
                return Some(user);
            });
        });
    }
}
