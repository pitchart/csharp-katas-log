namespace SupermarketReceipt
{
    public enum SpecialOfferType
    {
        ThreeForTwo,
        TenPercentDiscount,
        TwoForAmount,
        FiveForAmount
    }

    public class Offer
    {
        private Product _product;

        public Offer(SpecialOfferType offerType, Product product, double argument)
        {
            OfferType = offerType;
            Argument = argument;
            _product = product;
        }

        public SpecialOfferType OfferType { get; }
        public double Argument { get; }

        public bool IsApplicable(int quantityAsInt)
        {
            var nbOfProductNecessaryForOffer = this.OfferType switch
            {
                SpecialOfferType.ThreeForTwo => 3,
                SpecialOfferType.TwoForAmount => 2,
                SpecialOfferType.FiveForAmount => 5,
                _ => 1
            };

            return quantityAsInt >= nbOfProductNecessaryForOffer;
        }
    }
}
