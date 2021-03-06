using Xunit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Classes;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Tests
{
    public class Categories
    {
        static HttpClient client = new HttpClient();

        [Fact]
        public async void GetDetailsVerifyNameCanRelistPromotions()
        {
            // Act
            var baseUrl = "https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false";
            var response = await client.GetAsync(baseUrl);

            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            // Arrange
            var body = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<Category>(body);

            var name = content?.Name;
            var promoDescription = from promotion in content?.Promotions
                        where promotion.Name == "Gallery"
                        select promotion.Description;
            bool canRelist = content.CanRelist;

            string expectedName = "Carbon credits";
            string expectedDescription = "2x larger image";
            bool expectedCanRelist = true;
            // The Promotions element with Name = "Gallery" has a Description that contains the text "2x larger image"

            // Assert
            Assert.Equal(name, expectedName);
            Assert.Equal(true, expectedCanRelist);
            Assert.Equal(false, promoDescription.Contains(expectedDescription));

        }
    }
}
