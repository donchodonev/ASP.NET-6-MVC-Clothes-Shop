namespace ClothesShop.Services.Contracts
{
    using ClothesShop.Services.Models;

    public interface IGenderService
    {
        public Task<IEnumerable<GenderGroupServiceModel>> AllAsync();

        public Task<IEnumerable<TModel>> AllAsync<TModel>() where TModel : class;
    }
}
