using QR.Db.Models;

namespace QR.Db
{
    public class ProductsInDbRepository : IProductsInDbRepository
    {
        private readonly DatabaseContext databaseContext;
        public ProductsInDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task Add(Product product)
        {
            databaseContext.Products.Add(product);
            await databaseContext.SaveChangesAsync();
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }
    }
}
