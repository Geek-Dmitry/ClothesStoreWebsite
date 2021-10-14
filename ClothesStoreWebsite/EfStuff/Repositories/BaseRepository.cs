using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using СlothesStoreWebsite.EfStuff;
using СlothesStoreWebsite.EfStuff.Model;

namespace ClothesStoreWebsite.EfStuff.Repositories
{
    public abstract class BaseRepository<ModelType> where ModelType : BaseModel
    {

        protected ClothesStoreWebsiteDbContext _clothesStoreWebsiteDbContex;
        protected DbSet<ModelType> _dbSet;

        public BaseRepository(ClothesStoreWebsiteDbContext clothesStoreWebsiteDbContext)
        {
            _clothesStoreWebsiteDbContex = clothesStoreWebsiteDbContext;
            _dbSet = _clothesStoreWebsiteDbContex.Set<ModelType>();
        }

        public List<ModelType> GetAll()
        {
            return _dbSet.ToList();
        }

        public ModelType Get(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public void Save(ModelType model)
        {
            _dbSet.Add(model);
            _clothesStoreWebsiteDbContex.SaveChanges();
        }

        public void Remove(ModelType model)
        {
            _dbSet.Remove(model);
        }
    }
}
