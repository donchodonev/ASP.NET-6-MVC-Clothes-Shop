namespace ClothesShop.Controllers.Api
{
    using AutoMapper;

    using ClothesShop.Controllers.Models;

    using Microsoft.AspNetCore.Mvc;

    using static Infrastructure.ControllerBaseExtensions;

    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly IMapper mapper;

        public CartApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }

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

            var sumOfCurrentCartProductsCount = this.GetCart().Values.Sum(x => x.Count);

            return this.Ok(sumOfCurrentCartProductsCount);
        }

        [Route("api/cart")]
        [HttpPost]
        public ActionResult Post([FromBody]AllProductViewModel product)
        {
            if (!this.CartExists())
            {
                this.CreateCart();
                return this.RedirectToAction("/");
            }

            var cartProduct = mapper.Map<ProductCartModel>(product);

            this.AddToCart(cartProduct);

            var sumOfCurrentCartProductsCount = this.GetCart().Values.Sum(x => x.Count);

            return this.Ok(sumOfCurrentCartProductsCount + 1);
        }
    }
}
