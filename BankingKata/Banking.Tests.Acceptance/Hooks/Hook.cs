using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace Banking.Tests.Acceptance.Hooks
{

    [Binding]
    public class Hooks
    {
        [StepArgumentTransformation(@"(\d{2}-\d{2}-\d{4})")]
        public DateTime ConvertTableDate(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
    }

}
