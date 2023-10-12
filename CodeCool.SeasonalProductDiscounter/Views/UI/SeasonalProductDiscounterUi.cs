using System.Collections;
using CodeCool.SeasonalProductDiscounter.Extensions;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Browsers;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using ConsoleTables;

namespace CodeCool.SeasonalProductDiscounter.Views.UI;

public class SeasonalProductDiscounterUi
{
    private readonly IProductProvider _productProvider;
    private readonly IDiscountProvider _discountProvider;
    private readonly IDiscounterService _discounterService;
    private readonly ILogger _logger;
    private readonly IProductBrowser _productBrowser;
    private readonly IOffersBrowser _offersBrowser;

 

    private readonly IUIGetter _uIGetter;


    private List<string[]> _tableContent = new();
    private IEnumerable<Product> _products;
    private IEnumerable<Offer>? _offers;
    private List<string> _filterNames = new();

    public SeasonalProductDiscounterUi(
        IProductProvider productProvider,
        IDiscountProvider discountProvider,
        IDiscounterService discounterService,
        ILogger logger,
        IProductBrowser productBrowser,
        IOffersBrowser offersBrowser,
        IUIGetter uIGetter)
    {
        _productProvider = productProvider;
        _discountProvider = discountProvider;
        _discounterService = discounterService;
        _logger = logger;
        _productBrowser = productBrowser;
        _offersBrowser = offersBrowser;
        _uIGetter = uIGetter;

        _products = _productProvider.Products;
        
    }

    public void Run()
    {
        _logger.LogInfo("Welcome to Seasonal Product Discounter!");
        _logger.NewLine();

        int select = 0;

        while (select != 9)
        {

            DisplayMenu();
            select = _uIGetter.GetIntFromUser();

            switch (select)
            {
                case 1:
                    _logger.Clear();
                    CatalogSubmenu();
                    break;
                case 2:
                    _logger.Clear();
                    PrintDiscounts();
                    break;
                case 3:
                    _logger.Clear();
                    OffersSubmenu();
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
    private void OffersSubmenu()
    {
        int select = 0;

        _logger.LogInfo("To check promotions for the selected day...");
        var dateOfOfferAvailability = _uIGetter.GetDateFromUser();
        _offers = _discounterService.GetOffers(_products, dateOfOfferAvailability);

        while (select != 9)
        {
            
            PrintOffers();
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
                    _offers = _discounterService.GetOffers(_products, dateOfOfferAvailability);
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

    private void CatalogSubmenu()
    {
        int select = 0;

        while (select != 9)
        {
            PrintCatalog();
            DisplayAddedFilters();
            DisplayCatalogSubmenu();
            select = _uIGetter.GetIntFromUser();

            switch (select)
            {
                case 1:
                    var dateFromUser = _uIGetter.GetDateFromUser();
                    _logger.Clear();
                    var chosenSeason = SeasonExtensions.GetSeason(dateFromUser);
                    _products = _productBrowser.GetProductsFromSpecificSeason(_products, chosenSeason);
                    _filterNames.Add($"Filtered by season - {chosenSeason}");
                    break;
                case 2:
                    var phraseFromUser = _uIGetter.GetPhraseFromUser();
                    _logger.Clear();
                    _products = _productBrowser.GetProductsWithNameContainingGivenString(_products, phraseFromUser);
                    _filterNames.Add($"Names filtered with phrase - {phraseFromUser}");
                    break;
                case 3:
                    var colorFromUser = _uIGetter.GetColorFromUser();
                    _logger.Clear();
                    _products = _productBrowser.GetProductsWithSpecificColor(_products, colorFromUser);
                    _filterNames.Add($"Filtered by color - {colorFromUser}");
                    break;
                case 4:
                    _logger.Clear();
                    _products = _productBrowser.SortAscendingByName(_products);
                    break;
                case 5:
                    _logger.Clear();
                    _products = _productBrowser.SortDescendingByName(_products);
                    break;
                case 6:
                    _logger.Clear();
                    _products = _productBrowser.SortAscendingByPrice(_products);
                    break;
                case 7:
                    _logger.Clear();
                    _products = _productBrowser.SortDescendingByPrice(_products);
                    break;
                case 8:
                    _logger.Clear();
                    _products = _productProvider.Products;
                    _filterNames.Clear();
                    break;
                case 9:
                    _logger.Clear();
                    _products = _productProvider.Products;
                    _filterNames.Clear();
                    break;
                default:
                    break;

            }
        }
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

    private void DisplayCatalogSubmenu()
    {
        _logger.LogInfo("----------Catalog Menu----------");
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


    private void DisplayMenu()
    {
        _logger.LogInfo("-----------Main Menu-----------");
        _logger.LogInfo("1. Catalog");
        _logger.LogInfo("2. Discounts");
        _logger.LogInfo("3. Offers for specified date");
        _logger.LogInfo("-------------------------------");
    }

    private void PrintCatalog()
    {


        foreach (var product in _products)
        {
            _tableContent.Add(new string[] { product.Name, product.Color.ToString(), product.Season.ToString(), product.Price.ToString(), product.Id.ToString() });
        }
        _logger.NewLine();
        _logger.LogInfo("Current product catalog (without any discounts):");
        _logger.LogTable(_tableContent, "Name", "Color", "Season", "Price", "Id");
        _tableContent.Clear();
    }

    private void PrintDiscounts()
    {

        foreach (var discount in _discountProvider.Discounts)
        {
            _tableContent.Add(new string[] { discount.Name, discount.Rate.ToString() }); ;
        }
        _logger.NewLine();
        _logger.LogInfo("This year's promotions:");
        _logger.LogTable(_tableContent, "Name", "Rate");
        _tableContent.Clear();
    }

    private void PrintOffers()
    {

        _logger.LogInfo("Promotions for choosen date:");
        _logger.NewLine();

        foreach (var offer in _offers)
        {
            _tableContent.Add(new string[] { offer.Product.Name, offer.Product.Color.ToString(), offer.Product.Season.ToString(), offer.Product.Price.ToString(), offer.Product.Id.ToString() });
            _logger.LogTable(_tableContent, "Product Name", "Color", "Season", "Price", "Id");
            _tableContent.Clear();


            foreach (var discount in offer.Discounts)
            {
                _tableContent.Add(new string[] { discount.Name, discount.Rate.ToString() });
            }

            _logger.LogTable(_tableContent, "Discounts", "Rate");
            _tableContent.Clear();

            _logger.LogInfo("Price after all discounts: " + offer.Price.ToString());
            _logger.NewLine();
            _logger.NewLine();
        }
        _logger.NewLine();


    }


}
