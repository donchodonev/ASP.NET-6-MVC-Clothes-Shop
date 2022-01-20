namespace ClothesShop.Controllers.Api
{
    using AutoMapper;

    using ClothesShop.Controllers.Models;

    using Microsoft.AspNetCore.Mvc;

    using static Infrastructure.ControllerBaseExtensions;

    [ApiController]
    [Route("api/cart")]
    public class CartApiController : ControllerBase
    {
        private readonly IMapper mapper;

        public CartApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }

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

        [HttpPost]
        public ActionResult Post([FromBody]AllProductViewModel product)
        {
            if (!this.CartExists())
            {
                this.CreateCart();
                return this.Ok();
            }

            var cartProduct = mapper.Map<ProductCartModel>(product);

            this.AddToCart(cartProduct);

            return this.Ok(product);
        }
    }
}
