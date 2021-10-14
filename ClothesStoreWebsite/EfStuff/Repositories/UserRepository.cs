using System.Collections.Generic;
using System.Linq;
using СlothesStoreWebsite.EfStuff;
using СlothesStoreWebsite.EfStuff.Model;

namespace ClothesStoreWebsite.EfStuff.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ClothesStoreWebsiteDbContext clothesStoreWebsiteDbContex) : base(clothesStoreWebsiteDbContex)
        {
        }

        public User GetByEmail(string email) 
        {
            return _clothesStoreWebsiteDbContex
                .Users
                .SingleOrDefault(x => x.Email == email);
        }
    }
}
