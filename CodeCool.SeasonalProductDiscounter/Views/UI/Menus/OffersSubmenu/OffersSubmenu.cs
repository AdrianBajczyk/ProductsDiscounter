using CodeCool.SeasonalProductDiscounter.Extensions;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Service.Browsers;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Menus.OffersSubmenu;

public class OffersSubmenu : IOffersSubmenu
{
    private readonly ILogger _logger;
    private readonly IUIGetter _uIGetter;
    private readonly IUIPrinter _uIPrinter;
    private readonly IDiscounterService _discounterService;
    private readonly IProductProvider _productProvider;
    private readonly IOffersBrowser _offersBrowser;

    private IEnumerable<Offer>? _offers;
    private List<string> _filterNames = new();
    public OffersSubmenu(ILogger logger, IUIGetter uIGetter, IUIPrinter uIPrinter, IDiscounterService discounterService, IProductProvider productProvider, IOffersBrowser offersBrowser)
    {
        _logger = logger;
        _uIGetter = uIGetter;
        _uIPrinter = uIPrinter;
        _discounterService = discounterService;
        _productProvider = productProvider;
        _offersBrowser = offersBrowser;
    }

    public void Run()
    {
        int select = 0;

        _logger.LogInfo("To check promotions for the selected day...");
        var dateOfOfferAvailability = _uIGetter.GetDateFromUser();
        _offers = _discounterService.GetOffers(_productProvider.Products, dateOfOfferAvailability);

        while (select != 9)
        {

            _uIPrinter.PrintOffers(_offers);
            DisplayAddedFilters();
            DisplayOffersSumbmenu();
            select = _uIGetter.GetIntFromUser();

            switch (select)
            {
                case 1:
                    var dateFromUser = _uIGetter.GetDateFromUser();
                    _logger.Clear();
                    var chosenSeason = SeasonExtensions.GetSeason(dateFromUser);
                    _offers = _offersBrowser.GetOffersFromSpecificSeason(_offers, chosenSeason);
                    _filterNames.Add($"Filtered by season - {chosenSeason}");

                    break;
                case 2:
                    var phraseFromUser = _uIGetter.GetPhraseFromUser();
                    _logger.Clear();
                    _offers = _offersBrowser.GetOffersWithNameContainingGivenString(_offers, phraseFromUser);
                    _filterNames.Add($"Names filtered with phrase - {phraseFromUser}");
                    break;
                case 3:
                    var colorFromUser = _uIGetter.GetColorFromUser();
                    _logger.Clear();
                    _offers = _offersBrowser.GetOffersWithSpecificColor(_offers, colorFromUser);
                    _filterNames.Add($"Filtered by color - {colorFromUser}");
                    break;
                case 4:
                    _logger.Clear();
                    _offers = _offersBrowser.SortAscendingByName(_offers);
                    break;
                case 5:
                    _logger.Clear();
                    _offers = _offersBrowser.SortDescendingByName(_offers);
                    break;
                case 6:
                    _logger.Clear();
                    _offers = _offersBrowser.SortAscendingByPrice(_offers);
                    break;
                case 7:
                    _logger.Clear();
                    _offers = _offersBrowser.SortDescendingByPrice(_offers);
                    break;
                case 8:
                    _logger.Clear();
                    _offers = _discounterService.GetOffers(_productProvider.Products, dateOfOfferAvailability);
                    _filterNames.Clear();
                    break;
                case 9:
                    _logger.Clear();
                    _filterNames.Clear();
                    break;
                default:
                    break;

            }
        }
    }
    private void DisplayOffersSumbmenu()
    {
        _logger.LogInfo("----------Offers Menu----------");
        _logger.LogInfo("1. Add filter by season");
        _logger.LogInfo("2. Add filter by phrase");
        _logger.LogInfo("3. Add filter by color");
        _logger.LogInfo("4. Sort ascending by name");
        _logger.LogInfo("5. Sort descending by name");
        _logger.LogInfo("6. Sort ascending by price");
        _logger.LogInfo("7. Sort descending by price");
        _logger.LogInfo("8. Reset filters");
        _logger.LogInfo("9. Back");
        _logger.LogInfo("--------------------------------");
    }

    private void DisplayAddedFilters()
    {
        _logger.LogInfo("-------------FILTERS------------");
        foreach (var filterName in _filterNames)
        {
            _logger.LogInfo(filterName);
        }
        _logger.LogInfo("--------------------------------");
        _logger.NewLine();
    }
}
