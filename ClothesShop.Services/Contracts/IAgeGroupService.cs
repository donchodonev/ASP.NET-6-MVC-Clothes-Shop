namespace ClothesShop.Services.Contracts
{
    public interface IAgeGroupService
    {
        public Task<IEnumerable<TModel>> AllAsync<TModel>() where TModel : class;
    }
}
