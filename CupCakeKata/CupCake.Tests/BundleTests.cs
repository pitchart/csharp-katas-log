namespace CupCake.Tests
{
    public class BundleTests
    {
        [Fact]
        public void check_bundle_name()
        {
            var bundle = new Bundle(new CupCakeBase());

            Assert.Equal("📦 composed of 🧁", bundle.GetName());
        }

        [Fact]
        public void check_bundle_name_with_cookie()
        {
            var bundle = new Bundle(new Cookie());

            Assert.Equal("📦 composed of 🍪", bundle.GetName());
        }

        [Fact]
        public void check_bundle_price_who_contained_cookie()
        {
            var bundle = new Bundle(new Cookie());

            Assert.Equal("1.8$", bundle.GetFormatedPrice());
        }

        [Fact]
        public void check_bundle_name_who_contained_chocolate()
        {
            var bundle = new Bundle(new Chocolate(new CupCakeBase()));

            Assert.Equal("📦 composed of 🧁 with 🍫", bundle.GetName());
        }

        [Fact]
        public void check_bundle_name_with_cookies()
        {
            var bundle = new Bundle(new CupCakeBase(), new Cookie());

            Assert.Equal("📦 composed of 🧁 and 🍪", bundle.GetName());
        }

        [Fact]
        public void check_bundle_price_who_contained_cake_and_cookie()
        {
            var bundle = new Bundle(new CupCakeBase(), new Cookie());

            Assert.Equal("2.7$", bundle.GetFormatedPrice());
        }
    }

}
