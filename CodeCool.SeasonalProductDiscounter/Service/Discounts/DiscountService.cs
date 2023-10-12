using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Discounts;

public class DiscountService : IDiscounterService
{
    private IDiscountProvider _discountProvider;

    public DiscountService(IDiscountProvider discountProvider)
    {
        _discountProvider = discountProvider;
    }
    public Offer GetOffer(Product product, DateTime date)
    {
        var discountsBuffer = new List<IDiscount>();
        double priceBuffer = product.Price;

        foreach (var discount in _discountProvider.Discounts)
        {
          if (discount.Accepts(product, date))
            {
                discountsBuffer.Add(discount);
                priceBuffer -= priceBuffer * ((double)discount.Rate/100);
            }
        }
        
        var offer = new Offer(product, date, discountsBuffer, priceBuffer);
        return offer;
    }

    public IEnumerable<Offer> GetOffers(IEnumerable<Product> products, DateTime date)
    {
        List<Offer> discounted = new();
        foreach (var product in products)
        {
            var offer = GetOffer(product, date);
            if (offer.Discounts.Any())
            {
                discounted.Add(offer);
            }
        }

        return discounted;
    }
}
