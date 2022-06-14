using System.Collections.Generic;

namespace SupermarketReceipt
{

    public class ShoppingCart
    {
        private readonly List<ProductQuantity> _items = new List<ProductQuantity>();

        private readonly Dictionary<Product, double> _productQuantities = new Dictionary<Product, double>();

        public List<ProductQuantity> GetItems()
        {
            return new List<ProductQuantity>(_items);
        }

        public void AddItem(Product product)
        {
            AddItemQuantity(product, 1.0);
        }

        public void AddItemQuantity(Product product, double quantity)
        {
            _items.Add(new ProductQuantity(product, quantity));
            if (_productQuantities.ContainsKey(product))
            {
                var newAmount = _productQuantities[product] + quantity;
                _productQuantities[product] = newAmount;
            }
            else
            {
                _productQuantities.Add(product, quantity);
            }
        }

        public void HandleOffers(Receipt receipt, Dictionary<Product, Offer> offers, SupermarketCatalog catalog)
        {
            foreach (var p in _productQuantities.Keys)
            {
                var quantity = _productQuantities[p];
                var quantityAsInt = (int) quantity;
                if (offers.ContainsKey(p))
                {
                    var offer = offers[p];
                    var unitPrice = catalog.GetUnitPrice(p);
                    Discount discount = null;
                    var nbOfProductNecessaryForOffer = offer.OfferType switch
                    {
                        SpecialOfferType.ThreeForTwo => 3,
                        SpecialOfferType.TwoForAmount => 2,
                        SpecialOfferType.FiveForAmount => 5,
                        _ => 1
                    };

                    if (offer.IsApplicable(quantityAsInt))
                    {
                        int nbOfPacks = quantityAsInt / nbOfProductNecessaryForOffer;
                        switch (offer.OfferType)
                        {
                            case SpecialOfferType.ThreeForTwo:
                            {
                                var discountAmount = quantity * unitPrice - (nbOfPacks * 2 * unitPrice + quantityAsInt % 3 * unitPrice);
                                discount = new Discount(p, "3 for 2", -discountAmount);

                                break;
                            }
                            case SpecialOfferType.TenPercentDiscount:
                                discount = new Discount(p,
                                    offer.Argument + "% off",
                                    -quantity * unitPrice * offer.Argument / 100.0);

                                break;
                            case SpecialOfferType.TwoForAmount:
                            {
                                var total = offer.Argument * nbOfPacks + quantityAsInt % 2 * unitPrice;
                                var discountN = unitPrice * quantity - total;
                                discount = new Discount(p, "2 for " + offer.Argument, -discountN);

                                break;
                            }
                            case SpecialOfferType.FiveForAmount:
                            {
                                var discountTotal = unitPrice * quantity -
                                                    (offer.Argument * nbOfPacks + quantityAsInt % 5 * unitPrice);
                                discount = new Discount(p,
                                    nbOfProductNecessaryForOffer + " for " + offer.Argument,
                                    -discountTotal);

                                break;
                            }
                        }
                    }

                    if (discount != null) receipt.AddDiscount(discount);
                }
            }
        }
    }

}
