namespace CupCake.Tests
{
    public class CupCakeTests
    {
        [Fact]
        public void check_if_have_value_when_try_to_get_name()
        {
            var cupCake = new CupProduct();

            Assert.Equal("🧁", cupCake.GetName());
        }

        [Fact]
        public void check_if_have_value_when_try_to_get_price()
        {
            var cupCake = new CupProduct();

            Assert.Equal("1$", cupCake.GetFormatedPrice());
        }
    }
}
