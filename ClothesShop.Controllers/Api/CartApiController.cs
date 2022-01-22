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
        public ActionResult<Dictionary<int, ProductCartModel>> Get()
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
        public ActionResult<Dictionary<int, ProductCartModel>> GetCount()
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

            if (this.IsProductInCart(product.Id))
            {
                return this.Ok();
            }

            return this.Ok(uniqueProducts + 1);
        }
    }
}
