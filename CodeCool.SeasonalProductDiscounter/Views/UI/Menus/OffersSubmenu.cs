using CodeCool.SeasonalProductDiscounter.Extensions;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Service.Browsers;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Menus;

public class OffersSubmenu : AbstractMenu
{
    private readonly IDiscounterService _discounterService;
    private readonly IOffersBrowser _offersBrowser;

    private IEnumerable<Offer>? _offers;
    private List<string> _filterNames = new();


    public OffersSubmenu(
        string title, 
        bool needsAutification,
        IDiscounterService discounterService,
        IOffersBrowser offersBrowser) : base(title, needsAutification)
    {

        _discounterService = discounterService;
        _offersBrowser = offersBrowser;
    }

    public override void Display()
    {
        foreach(var log in _loggers)
        {
            log.Value.LogInfo(Title);
        }
        Run();
    }
    public void Run()
    {
        int select = 0;

        _loggers["consoleLogger"].LogInfo("To check promotions for the selected day...");
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
                    _loggers["consoleLogger"].Clear();
                    var chosenSeason = SeasonExtensions.GetSeason(dateFromUser);
                    _offers = _offersBrowser.GetOffersFromSpecificSeason(_offers, chosenSeason);
                    _filterNames.Add($"Filtered by season - {chosenSeason}");

                    break;
                case 2:
                    var phraseFromUser = _uIGetter.GetPhraseFromUser();
                    _loggers["consoleLogger"].Clear();
                    _offers = _offersBrowser.GetOffersWithNameContainingGivenString(_offers, phraseFromUser);
                    _filterNames.Add($"Names filtered with phrase - {phraseFromUser}");
                    break;
                case 3:
                    var colorFromUser = _uIGetter.GetColorFromUser();
                    _loggers["consoleLogger"].Clear();
                    _offers = _offersBrowser.GetOffersWithSpecificColor(_offers, colorFromUser);
                    _filterNames.Add($"Filtered by color - {colorFromUser}");
                    break;
                case 4:
                    _loggers["consoleLogger"].Clear();
                    _offers = _offersBrowser.SortAscendingByName(_offers);
                    break;
                case 5:
                    _loggers["consoleLogger"].Clear();
                    _offers = _offersBrowser.SortDescendingByName(_offers);
                    break;
                case 6:
                    _loggers["consoleLogger"].Clear();
                    _offers = _offersBrowser.SortAscendingByPrice(_offers);
                    break;
                case 7:
                    _loggers["consoleLogger"].Clear();
                    _offers = _offersBrowser.SortDescendingByPrice(_offers);
                    break;
                case 8:
                    _loggers["consoleLogger"].Clear();
                    _offers = _discounterService.GetOffers(_productProvider.Products, dateOfOfferAvailability);
                    _filterNames.Clear();
                    break;
                case 9:
                    _loggers["consoleLogger"].Clear();
                    _filterNames.Clear();
                    break;
                default:
                    break;

            }
        }
    }
    private void DisplayOffersSumbmenu()
    {
        var menuContent = new List<string>();

        menuContent.Add("----------Offers Menu----------");
        menuContent.Add("1. Add filter by season");
        menuContent.Add("2. Add filter by phrase");
        menuContent.Add("3. Add filter by color");
        menuContent.Add("4. Sort ascending by name");
        menuContent.Add("5. Sort descending by name");
        menuContent.Add("6. Sort ascending by price");
        menuContent.Add("7. Sort descending by price");
        menuContent.Add("8. Reset filters");
        menuContent.Add("9. Back");
        menuContent.Add("--------------------------------");

        _uIPrinter.PrintList(menuContent);
    }

    private void DisplayAddedFilters()
    {
        var filterContent = new List<string>();

        filterContent.Add("-------------FILTERS------------");
        foreach (var filterName in _filterNames)
        {
            filterContent.Add(filterName);
        }
        filterContent.Add("--------------------------------");
        filterContent.Add("\n");

        _uIPrinter.PrintList(filterContent);
    }

    
}
