namespace ClothesShop.Controllers.Api
{
    using ClothesShop.Controllers.ActionFilters;
    using ClothesShop.Controllers.Models.Product;
    using ClothesShop.Services.Contracts;
    using ClothesShop.Services.Models.Product;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [EnsureCartExists]
    public class CartApiController : ControllerBase
    {
        private readonly ICartService cart;

        public CartApiController(ICartService cart)
        {
            this.cart = cart;
        }
        [Route("api/cart")]
        [HttpGet]
        public ActionResult<Dictionary<string, ProductCartCookieModel>> Get()
        {
            return cart.Get(this.HttpContext);
        }

        [Route("api/cart/count")]
        [HttpGet]
        public ActionResult<int> GetCount()
        {
            var uniqueProductsCount = cart.UniqueProductsCount(this.HttpContext);

            return this.Ok(uniqueProductsCount);
        }

        [Route("api/cart")]
        [HttpPost]
        public ActionResult Post([FromBody] ProductCartCookieModel product)
        {
            cart.Add(this.HttpContext, product);

            var uniqueProducts = cart.UniqueProductsCount(this.HttpContext);

            var productKey = $"{product.ProductId}:{product.SizeId}";

            if (cart.IsProductInCart(this.HttpContext, productKey))
            {
                return this.Ok();
            }

            return this.Ok(uniqueProducts + 1);
        }

        [Route("api/cart/increaseProductCount")]
        [HttpPost]
        public ActionResult<ProductCountChangeServiceModel> IncreaseProductCount([FromBody] ProductCartCookieKeyModel productKey)
        {
            var increasedCountAndTotal = cart.IncreaseProductCountById(this.HttpContext, productKey.Key);

            if (increasedCountAndTotal == null)
            {
                return this.BadRequest();
            }

            return increasedCountAndTotal;
        }

        [Route("api/cart/decreaseProductCount")]
        [HttpPost]
        public ActionResult<ProductCountChangeServiceModel> DecreaseProductCount([FromBody] ProductCartCookieKeyModel productKey)
        {
            var decreasedCountAndTotal = cart.DecreaseProductCountById(this.HttpContext, productKey.Key);

            if (decreasedCountAndTotal == null)
            {
                return this.BadRequest();
            }

            return decreasedCountAndTotal;
        }
    }
}
