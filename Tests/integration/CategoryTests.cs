using Xunit;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Classes;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace IntegrationTests
{
    public class CategoryTests : IClassFixture<RequestFixture>
    {
        // private readonly HttpClient client;
        // public string requestUrl = "https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false";
        private RequestFixture fixture;
        public CategoryTests(RequestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void GetDetailsAndVerifyName()
        {
            // Arrange
            var name = fixture.category.Name;
            var expectedName = "Carbon credits";

            // Assert
            Assert.Equal(name, expectedName);
        }

        [Fact]
        public void GetDetailsAndVerifyCanRelist()
        {
            // Arange
            var canRelist = fixture.category.CanRelist;

            // Assert
            Assert.True(canRelist);
        }

        [Fact]
        public void GetDetailsAndVerifyDescription()
        {
            var expectedDescription = "2x larger image";

            // Act
            var promoDescription = from promotion in fixture.category.Promotions
                                   where promotion.Name == "Gallery"
                                   select promotion.Description;
            var hasDescription = promoDescription.Contains(expectedDescription);

            // Assert
            Assert.False(hasDescription);
        }

    }
}

