using System.Collections.Generic;
using BookInvoicing.Domain.Book;
using BookInvoicing.Domain.Country;
using BookInvoicing.Purchase;
using BookInvoicing.Report;
using BookInvoicing.Tests.Storage;
using Xunit;

namespace BookInvoicing.Tests
{
    public class ReportGeneratorTests
    {
        [Fact]
        public void ShouldComputeTotalAmount_WithoutDiscount_WithoutTaxExchange()
        {
            // Todo : add tests for invoice with no discount and no tax exchange
        }

        [Fact]
        public void ShouldComputeTotalAmount_WithDiscount_WithTaxExchanges()
        {
            // Todo : add tests for invoice with discount and tax exchanges
        }
    }
}
