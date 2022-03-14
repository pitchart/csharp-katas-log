using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Approval.Shared.SalesForce.Templating;
using VerifyXunit;
using Xunit;
using static VerifyXunit.Verifier;

namespace Approval.Tests.Unit
{
    public static class EnumerableExtensions
    {
        // Generate Combinations of 2 Enum values through this extension method
        public static IEnumerable<Tuple<TEnum1, TEnum2>> CombineEnumValues<TEnum1, TEnum2>()
            where TEnum1 : struct, Enum where TEnum2 : struct, Enum =>from a in Enum.GetValues<TEnum1>()
            from b in Enum.GetValues<TEnum2>()
            select new Tuple<TEnum1, TEnum2>(a, b);
    }

    [UsesVerify]
    public class TemplateTests
    {
        [Fact]
        public Task Should_Find_Template_For_DEER()
        {
            Template template = Template.FindTemplateFor(DocumentType.DEER.ToString(),
                SfRecordType.INDIVIDUAL_PROSPECT.ToString());

            return Verify(template);
        }

        [Fact]
        public Task Should_Find_Template_For()
        {
            return Verify(EnumerableExtensions.CombineEnumValues<DocumentType, SfRecordType>()
                .Select(t => $"[{t.Item1},{t.Item2}] => {TryFindTemplate(t)}").Aggregate(new StringBuilder(), (sb, s) => sb.AppendLine(s)));
        }

        private static string TryFindTemplate(Tuple<DocumentType, SfRecordType> enumValue)
        {
            try
            {
                return Template.FindTemplateFor(enumValue.Item1.ToString(),
                    enumValue.Item2.ToString()).ToString();
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }
    }
}
