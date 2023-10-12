using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products;

namespace CodeCool.SeasonalProuctDiscounter.UnitTests
{
    public class RandomProductGeneratorTests
    {
        private IEnumerable<Product> products;

        [SetUp]
        public void Setup()
        {
            IProductProvider productProvider = new RandomProductGenerator();
            products = productProvider.Products;
        }

        [Test]
        public void GenerateRandomProducts_WhenCalled_ReturnedProductsHasValidNameFormat()
        {

            foreach (var product in products)
            {
                Assert.That(product.Name, Does.Match(@"^\w+ \w+$"));  
            }
        }

        [Test]
        public void GenerateRandomProducts_WhenCalled_ReturnedProductsPriceAreRoundedToTwoSpaces()
        {


            foreach (var product in products)
            {
                string priceString = product.Price.ToString("0.00");
                int decimalPlaces = priceString.Split(',')[1].Length;

                Assert.That(decimalPlaces, Is.LessThanOrEqualTo(2));
            }
        }

        [Test]
        public void GenerateRandomProducts_WhenCalled_ReturnedProductsHaveUniqueIds()
        {
            var uniqueIds = new HashSet<int>(products.Select(product => product.Id));
            var allIds = new List<int>(products.Select(product => product.Id)); // wont let compile if product implement IEnumerable only

            Assert.That(uniqueIds.Count, Is.EqualTo(allIds.Count));
        }
    }
}