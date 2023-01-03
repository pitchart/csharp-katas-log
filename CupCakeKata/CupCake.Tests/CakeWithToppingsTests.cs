namespace CupCake.Tests
{
    public class CakeWithToppingsTests
    {
        [Fact]
        public void check_if_have_value_when_try_to_get_name()
        {
            var cupCake = new Chocolate(new CupCake());

            Assert.Equal("🧁 with 🍫", cupCake.GetName());
        }

        [Fact]
        public void check_if_have_value_when_try_to_get_price()
        {
            var cupCake = new Chocolate(new CupCake());

            Assert.Equal("1.1$", cupCake.GetPrice());
        }
    }

}
