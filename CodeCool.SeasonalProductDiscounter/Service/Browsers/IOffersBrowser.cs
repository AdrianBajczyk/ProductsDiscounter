using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Offers;

namespace CodeCool.SeasonalProductDiscounter.Service.Browsers;

public interface IOffersBrowser
{
    IEnumerable<Offer> GetOffersFromSpecificSeason(IEnumerable<Offer> offers, Season season);

    IEnumerable<Offer> GetOffersWithSpecificColor(IEnumerable<Offer> offers, Color color);

    IEnumerable<Offer> GetOffersWithNameContainingGivenString(IEnumerable<Offer> offers, string phrase);

    IEnumerable<Offer> SortAscendingByPrice(IEnumerable<Offer> offers);

    IEnumerable<Offer> SortDescendingByPrice(IEnumerable<Offer> offers);

    IEnumerable<Offer> SortAscendingByName(IEnumerable<Offer> offers);

    IEnumerable<Offer> SortDescendingByName(IEnumerable<Offer> offers);

}
