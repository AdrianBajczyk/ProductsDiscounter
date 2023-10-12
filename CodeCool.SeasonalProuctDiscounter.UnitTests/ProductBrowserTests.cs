using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Browsers;

namespace CodeCool.SeasonalProuctDiscounter.UnitTests
{
    public class ProductBrowserTests
    {
        private IProductBrowser _browser;

        [SetUp]
        public void SetUp()
        {
            _browser = new ProductBrowser();
        }

        [Test]
        public void GetProductsFromSpecificSeason_SpecificSeasonIsGiven_OnlyTheSameSeasonProducts()
        {
            var listOfProducts = new List<Product> 
            { 
                new Product("Name1", Color.Red, Season.Spring, 1), 
                new Product("Name2", Color.Yellow, Season.Winter, 1) 
            };

            var specifiedSeason = Season.Winter;

            var result = _browser.GetProductsFromSpecificSeason(listOfProducts, specifiedSeason);

            Assert.That(result.All(r => r.Season == Season.Winter));
        }

        [Test]
        public void GetProductsWithSpecificColor_SpecificColorIsGiven_OnlyTheSameColorProducts()
        {
            var listOfProducts = new List<Product>
            { 
                new Product("Name1", Color.Red, Season.Spring, 1), 
                new Product("Name2", Color.Yellow, Season.Winter, 1) 
            };

            var specifiedColor = Color.Red;

            var result = _browser.GetProductsWithSpecificColor(listOfProducts, specifiedColor);

            Assert.That(result.All(r => r.Color == Color.Red));
        }

        [Test]
        public void GetProductsWithNameContainingGivenString_PhraseIsGiven_OnlyProductsThatContainsPhrase()
        {
            var listOfProducts = new List<Product> 
            { 
                new Product("Name exp", Color.Red, Season.Spring, 1), 
                new Product("Name2", Color.Yellow, Season.Winter, 1) 
            };

            var givenPhrase = "exp";

            var result = _browser.GetProductsWithNameContainingGivenString(listOfProducts, givenPhrase);

            Assert.That(result.All(r => r.Name.Contains("exp")));
        }

        [Test]
        public void SortAscendingByName_WhenCalled_ProductsSortedAscendingByName()
        {
            var listOfProducts = new List<Product> 
            { 
                new Product("Name2", Color.Red, Season.Spring, 1), 
                new Product("Name1", Color.Yellow, Season.Winter, 1) 
            };

            var result = _browser.SortAscendingByName(listOfProducts);

            var expectedSortedProducts = new List<Product>
            {
                new Product("Name1", Color.Yellow, Season.Winter, 1),
                new Product("Name2", Color.Red, Season.Spring, 1)
            };

            CollectionAssert.AreEqual(expectedSortedProducts, result);
        }

        public void SortDescendingByName_WhenCalled_ProductsSortedDescendingByName()
        {
            var listOfProducts = new List<Product> 
            { 
                new Product("Name1", Color.Yellow, Season.Winter, 1),
                new Product("Name2", Color.Red, Season.Spring, 1) 
            };

            var result = _browser.SortDescendingByName(listOfProducts);

            var expectedSortedProducts = new List<Product>
            {
                new Product("Name2", Color.Red, Season.Spring, 1),
                new Product("Name1", Color.Yellow, Season.Winter, 1)
            };

            CollectionAssert.AreEqual(expectedSortedProducts, result);
        }

        [Test]
        public void SortAscendingByPrice_WhenCalled_ProductsSortedAscendingByPrice()
        {
            var listOfProducts = new List<Product> 
            { 
                new Product("Name2", Color.Red, Season.Spring, 2), 
                new Product("Name1", Color.Yellow, Season.Winter, 1) 
            };

            var result = _browser.SortAscendingByPrice(listOfProducts);

            var expectedSortedProducts = new List<Product>
            {
                new Product("Name1", Color.Yellow, Season.Winter, 1),
                new Product("Name2", Color.Red, Season.Spring, 2)
            };

            CollectionAssert.AreEqual(expectedSortedProducts, result);
        }

        [Test]
        public void SortDescendingByPrice_WhenCalled_ProductsSortedDescendingByPrice()
        {
            var listOfProducts = new List<Product>
            {
                new Product("Name1", Color.Yellow, Season.Winter, 1),
                new Product("Name2", Color.Red, Season.Spring, 2)
            };

            var result = _browser.SortDescendingByPrice(listOfProducts);

            var expectedSortedProducts = new List<Product>
            {
                new Product("Name2", Color.Red, Season.Spring, 2),
                new Product("Name1", Color.Yellow, Season.Winter, 1)
            };

            CollectionAssert.AreEqual(expectedSortedProducts, result);
        }
    }
}