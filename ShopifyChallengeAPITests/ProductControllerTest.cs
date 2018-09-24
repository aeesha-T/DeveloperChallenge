using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopifyChallengeAPI.Controllers;
using ShopifyChallengeAPI.Models;
using System.Net;
using System.Web.Http.Results;

namespace ShopifyChallengeAPITests
{
    [TestClass]
   public class ProductControllerTest
    {
        [TestMethod]
        public void  RetrieveProducts()
        {
            var controller = new ProductsController();
            var result = controller.Get();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RetrieveById()
        {
            var controller = new ProductsController();
            // Act on Test  
            var response = controller.Get(1);
            var contentResult = response as OkNegotiatedContentResult<Product>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
           // Assert.AreEqual(1, contentResult.Content.ProductId);
        }
    }
}
