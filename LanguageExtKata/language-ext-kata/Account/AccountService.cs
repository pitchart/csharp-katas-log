using LanguageExt;
using System;
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
            .Map(Register)
            .Map(UpdateTwitterAccount)
            .Map(Authenticate)
            .Map(Tweet)
            .Map(LogSuccess)
            .IfFail(ex =>
                {
                    _businessLogger.LogFailureRegister(id, ex);
                    return null;
                });
    }

    private Context UpdateTwitterAccount(Context o)
    {
        _userService.UpdateTwitterAccountId(o.user.Id, o.accountId);
        return o;
    }

    private Context Register(User u) => new Context(_twitterService.Register(u.Email, u.Name), u, null, null);

    private string LogSuccess(Context context)
    {
        _businessLogger.LogSuccessRegister(context.user.Id);
        return context.url;
    }

    private Context Tweet(Context context) => new(context.accountId, context.user,
        context.token, _twitterService.Tweet(context.token, "Hello I am " + context.user.Name));

    private Context Authenticate(Context context) => new(context.accountId, context.user,
        _twitterService.Authenticate(context.user.Email, context.user.Password), null);

    private Try<User> FindUser(Guid id)
    {
        return Try(() => _userService.FindById(id));
    }

}
