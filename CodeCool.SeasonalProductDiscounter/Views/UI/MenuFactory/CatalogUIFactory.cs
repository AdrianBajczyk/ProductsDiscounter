using CodeCool.SeasonalProductDiscounter.Service.Browsers;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.MenuFactory;

public class CatalogUIFactory : AbstractMenuFactory
{
    public override AbstractMenu CreateMenu()
    {


        return new CatalogSumbenu("Catalog Submenu", false, new ProductBrowser());
    }
}
