
using CodeCool.SeasonalProductDiscounter.Model.Enums;

namespace CodeCool.SeasonalProductDiscounter.Model.Products;

public record Product(string Name, Color Color, Season Season, double Price, int Id = 0)
{
    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, " +
               $"{nameof(Color)}: {Color}, " +
               $"{nameof(Season)}: {Season}, " +
               $"{nameof(Price)}: {Price}";
    }
}
