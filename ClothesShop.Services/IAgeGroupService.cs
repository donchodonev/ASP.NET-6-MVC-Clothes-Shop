namespace ClothesShop.Services
{
    public interface IAgeGroupService
    {
        public Task<IEnumerable<TModel>> All<TModel>() where TModel : class;
    }
}
