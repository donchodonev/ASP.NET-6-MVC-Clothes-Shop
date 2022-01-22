namespace ClothesShop.Controllers.Api
{
    using ClothesShop.Controllers.Models;

    using Microsoft.AspNetCore.Mvc;

    using static Infrastructure.ControllerBaseExtensions;

    [ApiController]
    public class CartApiController : ControllerBase
    {
        [Route("api/cart")]
        [HttpGet]
        public ActionResult<Dictionary<string, ProductCartModel>> Get()
        {
            if (!this.CartExists())
            {
                this.CreateCart();

                return this.Redirect("/");
            }

            return this.GetCart();
        }

        [Route("api/cart/count")]
        [HttpGet]
        public ActionResult<int> GetCount()
        {
            if (!this.CartExists())
            {
                this.CreateCart();

                return this.Redirect("/");
            }

            return this.Ok(this.UniqueProductsCount());
        }

        [Route("api/cart")]
        [HttpPost]
        public ActionResult Post([FromBody] ProductCartModel product)
        {
            if (!this.CartExists())
            {
                this.CreateCart();
                return this.RedirectToAction("/");
            }

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
