namespace ClothesShop.Services
{
    using ClothesShop.Services.Models;

    public interface IGenderService
    {
        public Task<IEnumerable<GenderGroupServiceModel>> All();

        public Task<IEnumerable<TModel>> All<TModel>() where TModel : class;
    }
}
