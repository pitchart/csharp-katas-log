namespace CupCake.Tests
{
    public class CakeWithToppingsTests
    {
        [Fact]
        public void Check_if_have_value_when_try_to_get_name()
        {
            var cupCake = new Chocolate(new CupCakeBase());

            Assert.Equal("🧁 with 🍫", cupCake.GetName());
        }

        [Fact]
        public void Check_if_have_value_when_try_to_get_price()
        {
            var cupCake = new Chocolate(new CupCakeBase());

            Assert.Equal("1.1$", cupCake.GetFormatedPrice());
        }

        [Fact]
        public void Check_if_cookie_have_a_chocolate_topping()
        {
            var cake = new Chocolate(new Cookie());

            Assert.Equal("🍪 with 🍫", cake.GetName());
        }

        [Fact]
        public void Check_if_cookie_with_chocolate_topping_have_a_price()
        {
            var cupCake = new Chocolate(new Cookie());

            Assert.Equal("2.1$", cupCake.GetFormatedPrice());
        }

        [Fact]
        public void Check_if_cookie_have_a_chocolate_and_nuts_topping()
        {
            var cake = new Nut(new Chocolate(new Cookie())) ;

            Assert.Equal("🍪 with 🍫 and 🥜", cake.GetName());
        }

        [Fact]
        public void Check_if_cookie_with_chocolate_and_nut_toppings_have_a_price()
        {
            var cake = new Nut(new Chocolate(new Cookie()));

            Assert.Equal("2.3$", cake.GetFormatedPrice());
        }

        [Fact]
        public void Check_if_cookie_with_chocolate_nuts_and_topping_have_a_price()
        {
            var cake = new Chocolate(new Nut(new Cookie()));

            Assert.Equal("2.3$", cake.GetFormatedPrice());
        }

        [Fact]
        public void Check_if_cookie_have_nuts_and_chocolate_topping()
        {
            var cake = new Chocolate(new Nut(new Cookie()));

            Assert.Equal("🍪 with 🥜 and 🍫", cake.GetName());
        }
    }
}
