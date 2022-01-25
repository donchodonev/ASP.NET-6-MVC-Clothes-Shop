namespace ClothesShop.Controllers.Api
{
    using ClothesShop.Controllers.ActionFilters;
    using ClothesShop.Controllers.Models;

    using Microsoft.AspNetCore.Mvc;

    using static Infrastructure.ControllerBaseExtensions;

    [ApiController]
    [EnsureCartExists]
    public class CartApiController : ControllerBase
    {
        [Route("api/cart")]
        [HttpGet]
        public ActionResult<Dictionary<string, ProductCartCookieModel>> Get()
        {
            return this.GetCart();
        }

        [Route("api/cart/count")]
        [HttpGet]
        public ActionResult<int> GetCount()
        {
            return this.Ok(this.UniqueProductsCount());
        }

        [Route("api/cart")]
        [HttpPost]
        public ActionResult Post([FromBody] ProductCartCookieModel product)
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

        [Route("api/cart/increaseProductCount")]
        [HttpPost]
        public ActionResult<int> IncreaseProductCount([FromBody]ProductCartCookieKeyModel productKey)
        {
            var increasedCount = this.IncreaseProductCountById(productKey.Key);

            if (!increasedCount.HasValue)
            {
                return this.BadRequest();
            }

            return this.Ok(increasedCount.Value);
        }

        [Route("api/cart/decreaseProductCount")]
        [HttpPost]
        public ActionResult<int> DecreaseProductCount([FromBody] ProductCartCookieKeyModel productKey)
        {
            var decreasedCount = this.DecreaseProductCountById(productKey.Key);

            if (!decreasedCount.HasValue)
            {
                return this.BadRequest();
            }

            return decreasedCount.Value;
        }
    }
}
