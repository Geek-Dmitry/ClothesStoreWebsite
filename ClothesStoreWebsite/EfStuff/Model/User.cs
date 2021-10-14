using System.Collections.Generic;

namespace СlothesStoreWebsite.EfStuff.Model
{
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Image { get; set; }
        public List<Product> WishProducts { get; set; }
    }
}
