using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products;

public class RandomProductGenerator : IProductProvider
{
    private Random _random = new Random();
    public IEnumerable<Product> Products { get; }

    public RandomProductGenerator()
    {
        Products = GetRandomProducts();
    }
    private IEnumerable<Product> GetRandomProducts()
    {
        

        var products = new List<Product>();
        var ammountOFProducts = _random.Next(50, 70);

        for (int i = 0; i < ammountOFProducts; i++)
        {
            var randomCloth = GetRandomClothType();
            var randomColor = GetRandomColor();
            var randomSeason = GetRandomSeason();
            var randomPrice = GenerateRandomPrice();
            var id = i + 1;

            var randomColouredCloth = ConcatColorAndClothInString(randomColor, randomCloth);

            products.Add(new Product(randomColouredCloth, randomColor, randomSeason, randomPrice, id));
        }

        return products;
    }

    private string ConcatColorAndClothInString(Color randomColor, ClothType randomCloth )
    {
        return $"{randomColor} {randomCloth}";
    }

    private double GenerateRandomPrice()
    {
        double result = _random.Next(5, 100) + _random.NextDouble();
        double roundedResult = Math.Round(result, 2);

        return roundedResult;
    }

    private Season GetRandomSeason()
    {
        const int seasonItemsAmmount = 4;
        var randomIndex = _random.Next(0, seasonItemsAmmount);



        return (Season)randomIndex;
    }

    private ClothType GetRandomClothType()
    {
        var clothTypeItemsAmmount = Enum.GetValues(typeof(ClothType)).Length;
        var randomIndex = _random.Next(0, clothTypeItemsAmmount);



        return (ClothType)randomIndex;
    }

    private Color GetRandomColor()
    {
        var colorItemsAmmount = Enum.GetValues(typeof(Color)).Length;
        var randomIndex = _random.Next(0, colorItemsAmmount);



        return (Color)randomIndex;
    }
}


