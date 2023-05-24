using QR.Db.Models;

namespace QR.Db
{
    public interface IProductsInDbRepository
    {
        Task Add(Product product);
        List<Product> GetAll();
    }
}