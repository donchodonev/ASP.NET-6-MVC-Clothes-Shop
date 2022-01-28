namespace ClothesShop.Controllers.Models.Product
{
    using ClothesShop.Services.Contracts;
    using ClothesShop.Services.Models.Product;

    public class ProductGroupCollectionViewModel
    {
        public ProductGroupCollectionViewModel()
        {
            Groups = new List<ProductGroupServiceModel>();
        }
        public List<ProductGroupServiceModel> Groups { get; set; }

        public async Task GetGroupsAsync(IGenderService genders, IAgeGroupService ageGroups)
        {
            Groups.AddRange(await genders.AllAsync<ProductGroupServiceModel>());
            Groups.AddRange(await ageGroups.AllAsync<ProductGroupServiceModel>());
        }
    }
}
