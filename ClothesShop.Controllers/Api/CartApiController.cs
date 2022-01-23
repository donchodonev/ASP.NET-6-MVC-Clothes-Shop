namespace ClothesShop.Controllers.Api
{
    using ClothesShop.Controllers.ActionFilters;
    using ClothesShop.Controllers.Models;

    using Microsoft.AspNetCore.Mvc;

    using static Infrastructure.ControllerBaseExtensions;

    [ApiController]
    public class CartApiController : ControllerBase
    {
        [Route("api/cart")]
        [HttpGet]
        [EnsureCartExists]
        public ActionResult<Dictionary<string, ProductCartModel>> Get()
        {
            return this.GetCart();
        }

        [Route("api/cart/count")]
        [HttpGet]
        [EnsureCartExists]
        public ActionResult<int> GetCount()
        {
            return this.Ok(this.UniqueProductsCount());
        }

        [Route("api/cart")]
        [HttpPost]
        [EnsureCartExists]
        public ActionResult Post([FromBody] ProductCartModel product)
        {
            this.AddToCart(product);

            var uniqueProducts = this.UniqueProductsCount();

            var productKey = $"{product.ProductId}:{product.SizeId}";

            if (this.IsProductInCart(productKey))
            {
                return this.Ok();
            }

            return this.Ok(uniqueProducts + 1);
        }
    }
}
