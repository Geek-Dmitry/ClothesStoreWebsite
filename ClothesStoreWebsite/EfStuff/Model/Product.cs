namespace СlothesStoreWebsite.EfStuff.Model
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
        public int QuantityInStock { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public User WishProductFor { get; set; }
    }
}
