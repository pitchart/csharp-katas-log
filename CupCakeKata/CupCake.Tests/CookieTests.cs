namespace CupCake.Tests
{
    public class CookieTests
    {
        [Fact]
        public void check_if_have_value_when_try_to_get_name()
        {
            var cupCake = new Cookie();

            Assert.Equal("🍪", cupCake.GetName());
        }

        [Fact]
        public void check_if_have_value_when_try_to_get_price()
        {
            var cupCake = new Cookie();

            Assert.Equal("2$", cupCake.GetPrice());
        }
    }
}
