using CodeCool.SeasonalProductDiscounter.Extensions;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Browsers;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Menus.CatalogSubmenu;

public class CatalogSumbenu : ICatalogSubmenu
{
    private readonly ILogger _consoleLogger;
    private readonly IUIGetter _uIGetter;
    private readonly IUIPrinter _uIPrinter;
    private readonly IProductProvider _productProvider;
    private readonly IProductBrowser _productBrowser;

    private IEnumerable<Product> _products;
    private List<string> _filterNames = new();

    public CatalogSumbenu(SortedList<string,ILogger> loggers, IUIGetter uIGetter, IUIPrinter uIPrinter, IProductProvider productProvider, IProductBrowser productBrowser)
    {
        _consoleLogger = loggers["consoleLogger"];
        _uIGetter = uIGetter;
        _uIPrinter = uIPrinter;
        _productProvider = productProvider;
        _productBrowser = productBrowser;

        _products = _productProvider.Products;
    }

    public void Run()
    {
        int select = 0;

        while (select != 16)
        {

            _uIPrinter.PrintProducts(_products);
            DisplayAddedFilters();
            DisplayCatalogSubmenu();
            select = _uIGetter.GetIntFromUser();

            switch (select)
            {
                case 1:
                    var dateFromUser = _uIGetter.GetDateFromUser();
                    _consoleLogger.Clear();
                    var chosenSeason = SeasonExtensions.GetSeason(dateFromUser);
                    _products = _productBrowser.GetProductsFromSpecificSeason(_products, chosenSeason);
                    _filterNames.Add($"Filtered by season - {chosenSeason}");
                    break;
                case 2:
                    var phraseFromUser = _uIGetter.GetPhraseFromUser();
                    _consoleLogger.Clear();
                    _products = _productBrowser.GetProductsWithNameContainingGivenString(_products, phraseFromUser);
                    _filterNames.Add($"Names filtered with phrase - {phraseFromUser}");
                    break;
                case 3:
                    var colorFromUser = _uIGetter.GetColorFromUser();
                    _consoleLogger.Clear();
                    _products = _productBrowser.GetProductsWithSpecificColor(_products, colorFromUser);
                    _filterNames.Add($"Filtered by color - {colorFromUser}");
                    break;
                case 4:
                    var priceSmallerThan = _uIGetter.GetPriceFromUser();
                    _consoleLogger.Clear();
                    _products = _productBrowser.GetByPriceSmallerThan(_products, priceSmallerThan);
                    _filterNames.Add($"Filtered by price smaller than - {priceSmallerThan}");
                    break;
                case 5:
                    var priceGreaterThan = _uIGetter.GetPriceFromUser();
                    _consoleLogger.Clear();
                    _products = _productBrowser.GetByPriceGreaterThan(_products, priceGreaterThan);
                    _filterNames.Add($"Filtered by price smaller than - {priceGreaterThan}");
                    break;
                case 6:
                    var priceRange = _uIGetter.GetPriceRangeFromUser();
                    _consoleLogger.Clear();
                    _products = _productBrowser.GetByPriceRange(_products, priceRange);
                    _filterNames.Add($"Filtered by price greater than {priceRange.Minimum} and smaller than {priceRange.Minimum}");
                    break;
                case 7:
                    _consoleLogger.Clear();
                    var productsGroupedByName = _productBrowser.GroupByName(_products);
                    _uIPrinter.PrintGroupedProducts(productsGroupedByName);
                    _uIGetter.GetKeyToContinue();
                    _consoleLogger.Clear();
                    break;
                case 8:
                    _consoleLogger.Clear();
                    var productsGroupedBySeason = _productBrowser.GroupBySeason(_products);
                    _uIPrinter.PrintGroupedProducts(productsGroupedBySeason);
                    _uIGetter.GetKeyToContinue();
                    _consoleLogger.Clear();
                    break;
                case 9:
                    _consoleLogger.Clear();
                    var productsGroupedByColor = _productBrowser.GroupByColor(_products);
                    _uIPrinter.PrintGroupedProducts(productsGroupedByColor);
                    _uIGetter.GetKeyToContinue();
                    _consoleLogger.Clear();
                    break;
                case 10:
                    _consoleLogger.Clear();
                    var productsGroupedByPriceRange = _productBrowser.GroupByPriceRange(_products);
                    _uIPrinter.PrintGroupedProducts(productsGroupedByPriceRange);
                    _uIGetter.GetKeyToContinue();
                    _consoleLogger.Clear();
                    break;
                case 11:
                    _consoleLogger.Clear();
                    _products = _productBrowser.SortAscendingByName(_products);
                    break;
                case 12:
                    _consoleLogger.Clear();
                    _products = _productBrowser.SortDescendingByName(_products);
                    break;
                case 13:
                    _consoleLogger.Clear();
                    _products = _productBrowser.SortAscendingByPrice(_products);
                    break;
                case 14:
                    _consoleLogger.Clear();
                    _products = _productBrowser.SortDescendingByPrice(_products);
                    break;
                case 15:
                    _consoleLogger.Clear();
                    _products = _productProvider.Products;
                    _filterNames.Clear();
                    break;
                case 16:
                    _consoleLogger.Clear();
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
    private void DisplayCatalogSubmenu()
    {
        var menuContent = new List<string>();

        menuContent.Add("------------Catalog Menu------------");
        menuContent.Add("1.  Add filter by season");
        menuContent.Add("2.  Add filter by phrase");
        menuContent.Add("3.  Add filter by color");
        menuContent.Add("4.  Add filter by price smaller than");
        menuContent.Add("5.  Add filter by price greater than");
        menuContent.Add("6.  Add filter by price range");
        menuContent.Add("7.  Display grouped by name");
        menuContent.Add("8.  Display grouped by season");
        menuContent.Add("9.  Display grouped by color");
        menuContent.Add("10. Display grouped by price range");
        menuContent.Add("11. Sort ascending by name");
        menuContent.Add("12. Sort descending by name");
        menuContent.Add("13. Sort ascending by price");
        menuContent.Add("14. Sort descending by price");
        menuContent.Add("15. Reset filters");
        menuContent.Add("16. Back");
        menuContent.Add("------------------------------------");

        _uIPrinter.PrintList(menuContent);
    }
}
