using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Offers;

namespace CodeCool.SeasonalProductDiscounter.Service.Browsers;

public class OffersBrowser : IOffersBrowser
{
    public IEnumerable<Offer> GetOffersFromSpecificSeason(IEnumerable<Offer> offers, Season season)
    {
        return offers.Where(o => o.Product.Season == season);
    }

    public IEnumerable<Offer> GetOffersWithNameContainingGivenString(IEnumerable<Offer> offers, string phrase)
    {
        return offers.Where(o => o.Product.Name.Contains(phrase));
    }

    public IEnumerable<Offer> GetOffersWithSpecificColor(IEnumerable<Offer> offers, Color color)
    {
        return offers.Where(o => o.Product.Color == color);
    }

    public IEnumerable<Offer> SortAscendingByName(IEnumerable<Offer> offers)
    {
        return offers.OrderBy(o => o.Product.Name);
    }

    public IEnumerable<Offer> SortAscendingByPrice(IEnumerable<Offer> offers)
    {
        return offers.OrderBy(o => o.Product.Price);
    }

    public IEnumerable<Offer> SortDescendingByName(IEnumerable<Offer> offers)
    {
        return offers.OrderByDescending(o => o.Product.Name);
    }

    public IEnumerable<Offer> SortDescendingByPrice(IEnumerable<Offer> offers)
    {
        return offers.OrderByDescending(o => o.Product.Price);
    }
}
