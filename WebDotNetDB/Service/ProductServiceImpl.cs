using WebDotNetDB.Models;

namespace WebDotNetDB.Service;

public class ProductServiceImpl : ProductService
{
    private DatabaseContext dbContext;
    public ProductServiceImpl(DatabaseContext _databaseContext)
    {
        dbContext = _databaseContext;
    }

    public bool Create(Product product)
    {
        try
        {
            dbContext.Products.Add(product);
            return dbContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public List<Product> findAll()
    {
        return dbContext.Products.ToList();
    }

    public Product FindById(int id)
    {
        return dbContext.Products.Find(id);
    }
}
