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
        private RequestFixture fixture;
        public CategoryTests(RequestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void GetDetailsAndVerifyName()
        {
            // Arrange
            var expectedName = "Carbon credits";
            var categoryName = fixture.category.Name;

            // Assert
            Assert.Equal(categoryName, expectedName);
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
            // Arrange
            var expectedDescription = "Good position in category";
            var promoDescription = fixture.category.Promotions
                .Where(p => p.Name == "Gallery")
                .FirstOrDefault()
                .Description;

            // Assert
            Assert.Equal(expectedDescription, promoDescription);
        }

    }
}

