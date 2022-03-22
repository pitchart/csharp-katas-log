using System;
using VerifyTests;

namespace Approval.Tests
{
    public static class VerifyExtensions
    {
        public static SettingsTask WithSettings(
            this SettingsTask settings,
            Action<SerializationSettings>? action)
            => action == null
                ? settings
                : settings.ModifySerialization(action);
    }
}

