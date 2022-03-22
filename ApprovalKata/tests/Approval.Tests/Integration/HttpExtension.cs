using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using VerifyTests;
using static VerifyXunit.Verifier;

namespace Approval.Tests.Integration
{
    
    public static class HttpExtensions
    {
        public static async Task<T> Deserialize<T>(this HttpResponseMessage? response)
            => JsonConvert.DeserializeObject<T>(await response!.Content.ReadAsStringAsync())!;

        public static async Task Verify(
            this Task<HttpResponseMessage> call,
            Action<SerializationSettings>? settings = null)
            => await VerifyJson(await (await call).Content.ReadAsStringAsync())
                .WithSettings(settings);
    }
}
