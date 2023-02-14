namespace CupCake.Tests
{
    public class BundleTests
    {
        [Fact]
        public void check_bundle_name()
        {
            var bundle = new Bundle(new CupProduct());

            Assert.Equal("📦 composed of 1 🧁", bundle.GetName());
        }

        [Fact]
        public void check_bundle_name_with_cookie()
        {
            var bundle = new Bundle(new Cookie());

            Assert.Equal("📦 composed of 1 🍪", bundle.GetName());
        }

        [Fact]
        public void check_bundle_price_who_contained_cookie()
        {
            var bundle = new Bundle(new Cookie());

            Assert.Equal("1.80$", bundle.GetFormatedPrice());
        }

        [Fact]
        public void check_bundle_name_who_contained_chocolate()
        {
            var bundle = new Bundle(new Chocolate(new CupProduct()));

            Assert.Equal("📦 composed of 1 🧁 with 🍫", bundle.GetName());
        }

        [Fact]
        public void check_bundle_name_with_cookies()
        {
            var bundle = new Bundle(new CupProduct(), new Cookie());

            Assert.Equal("📦 composed of 1 🧁 and 1 🍪", bundle.GetName());
        }

        [Fact]
        public void check_bundle_price_who_contained_cake_and_cookie()
        {
            var bundle = new Bundle(new CupProduct(), new Cookie());

            Assert.Equal("2.70$", bundle.GetFormatedPrice());
        }

        [Fact]
        public void check_bundle_name_who_contained_two_cup_cake_and_three_cookie()
        {
            var bundle = new Bundle(new CupProduct(), new CupProduct(), new Cookie(), new Cookie(), new Cookie());

            Assert.Equal("📦 composed of 2 🧁 and 3 🍪", bundle.GetName());
        }

        [Fact]
        public void check_bundle_price_who_contained_two_cup_cake_and_three_cookie()
        {
            var bundle = new Bundle(new CupProduct(), new CupProduct(), new Cookie(), new Cookie(), new Cookie());

            Assert.Equal("7.20$", bundle.GetFormatedPrice());
        }

        [Fact]
        public void check_bundle_name_who_contained_one_bundle_and_two_cup_cake_and_one_cookie()
        {
            var bundle = new Bundle(new Bundle(new CupProduct(), new CupProduct()), new Cookie());

            Assert.Equal("📦 composed of 1 📦 composed of 2 🧁 and 1 🍪", bundle.GetName());
        }

        [Fact]
        public void check_bundle_price_who_contained_one_bundle_and_two_cup_cake_and_one_cookie()
        {
            var bundle = new Bundle(new Bundle(new CupProduct(), new CupProduct()), new Cookie());

            Assert.Equal("3.42$", bundle.GetFormatedPrice());
        }

        [Fact]
        public void check_bundle_name_who_contained_same_bundles()
        {
            var bundle = new Bundle(new Bundle(new CupProduct(), new CupProduct()), 
                new Bundle(new CupProduct(), new CupProduct()));

            Assert.Equal("📦 composed of 2 📦 composed of 2 🧁", bundle.GetName());
        }

        [Fact]
        public void check_bundle_price_who_contained_same_bundles()
        {
            var bundle = new Bundle(new Bundle(new CupProduct(), new CupProduct()),
                new Bundle(new CupProduct(), new CupProduct()));

            Assert.Equal("3.24$", bundle.GetFormatedPrice());
        }
    }

}
