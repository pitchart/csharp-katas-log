using System;

namespace language_ext.kata.Account
{
    public record User(Guid Id, string Email, string Name, string Password);
}
