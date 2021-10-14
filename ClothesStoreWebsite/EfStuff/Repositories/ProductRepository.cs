using System.Collections.Generic;
using System.Linq;
using СlothesStoreWebsite.EfStuff;
using СlothesStoreWebsite.EfStuff.Model;

namespace ClothesStoreWebsite.EfStuff.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(ClothesStoreWebsiteDbContext clothesStoreWebsiteDbContext) : base(clothesStoreWebsiteDbContext)
        {
        }
    }
}
