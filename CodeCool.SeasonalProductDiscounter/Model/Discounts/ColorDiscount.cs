using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Model.Discounts;

//
public record ColorDiscount(string name, int rate) : IDiscount
{
    public string Name => name;

    public int Rate => rate;

    public bool Accepts(Product product, DateTime date)
    {
        return (product.Season == Enums.Season.Winter && product.Color == Enums.Color.Blue)   ||
               (product.Season == Enums.Season.Spring && product.Color == Enums.Color.Green)  ||
               (product.Season == Enums.Season.Summer && product.Color == Enums.Color.Yellow) ||
               (product.Season == Enums.Season.Autumn && product.Color == Enums.Color.Brown);
    }
}
