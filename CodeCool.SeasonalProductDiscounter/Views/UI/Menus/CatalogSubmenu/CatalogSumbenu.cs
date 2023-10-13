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
    private readonly ILogger _logger;
    private readonly IUIGetter _uIGetter;
    private readonly IUIPrinter _uIPrinter;
    private readonly IProductProvider _productProvider;
    private readonly IProductBrowser _productBrowser;

    private IEnumerable<Product> _products;
    private List<string> _filterNames = new();

    public CatalogSumbenu(ILogger logger, IUIGetter uIGetter, IUIPrinter uIPrinter, IProductProvider productProvider, IProductBrowser productBrowser)
    {
        _logger = logger;
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
                    var priceSmallerThan = _uIGetter.GetPriceFromUser();
                    _logger.Clear();
                    _products = _productBrowser.GetByPriceSmallerThan(_products, priceSmallerThan);
                    _filterNames.Add($"Filtered by price smaller than - {priceSmallerThan}");
                    break;
                case 5:
                    var priceGreaterThan = _uIGetter.GetPriceFromUser();
                    _logger.Clear();
                    _products = _productBrowser.GetByPriceGreaterThan(_products, priceGreaterThan);
                    _filterNames.Add($"Filtered by price smaller than - {priceGreaterThan}");
                    break;
                case 6:
                    var priceRange = _uIGetter.GetPriceRangeFromUser();
                    _logger.Clear();
                    _products = _productBrowser.GetByPriceRange(_products, priceRange);
                    _filterNames.Add($"Filtered by price greater than {priceRange.Minimum} and smaller than {priceRange.Minimum}");
                    break;
                case 7:
                    _logger.Clear();
                    var productsGroupedByName = _productBrowser.GroupByName(_products);
                    _uIPrinter.PrintGroupedProducts(productsGroupedByName);
                    _uIGetter.GetKeyToContinue();
                    _logger.Clear();
                    break;
                case 8:
                    _logger.Clear();
                    var productsGroupedBySeason = _productBrowser.GroupBySeason(_products);
                    _uIPrinter.PrintGroupedProducts(productsGroupedBySeason);
                    _uIGetter.GetKeyToContinue();
                    _logger.Clear();
                    break;
                case 9:
                    _logger.Clear();
                    var productsGroupedByColor = _productBrowser.GroupByColor(_products);
                    _uIPrinter.PrintGroupedProducts(productsGroupedByColor);
                    _uIGetter.GetKeyToContinue();
                    _logger.Clear();
                    break;
                case 10:
                    _logger.Clear();
                    var productsGroupedByPriceRange = _productBrowser.GroupByPriceRange(_products);
                    _uIPrinter.PrintGroupedProducts(productsGroupedByPriceRange);
                    _uIGetter.GetKeyToContinue();
                    _logger.Clear();
                    break;
                case 11:
                    _logger.Clear();
                    _products = _productBrowser.SortAscendingByName(_products);
                    break;
                case 12:
                    _logger.Clear();
                    _products = _productBrowser.SortDescendingByName(_products);
                    break;
                case 13:
                    _logger.Clear();
                    _products = _productBrowser.SortAscendingByPrice(_products);
                    break;
                case 14:
                    _logger.Clear();
                    _products = _productBrowser.SortDescendingByPrice(_products);
                    break;
                case 15:
                    _logger.Clear();
                    _products = _productProvider.Products;
                    _filterNames.Clear();
                    break;
                case 16:
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
        _logger.LogInfo("------------Catalog Menu------------");
        _logger.LogInfo("1.  Add filter by season");
        _logger.LogInfo("2.  Add filter by phrase");
        _logger.LogInfo("3.  Add filter by color");
        _logger.LogInfo("4.  Add filter by price smaller than");
        _logger.LogInfo("5.  Add filter by price greater than");
        _logger.LogInfo("6.  Add filter by price range");
        _logger.LogInfo("7.  Display grouped by name");
        _logger.LogInfo("8.  Display grouped by season");
        _logger.LogInfo("9.  Display grouped by color");
        _logger.LogInfo("10. Display grouped by price range");
        _logger.LogInfo("11. Sort ascending by name");
        _logger.LogInfo("12. Sort descending by name");
        _logger.LogInfo("13. Sort ascending by price");
        _logger.LogInfo("14. Sort descending by price");
        _logger.LogInfo("15. Reset filters");
        _logger.LogInfo("16. Back");
        _logger.LogInfo("------------------------------------");
    }
}
