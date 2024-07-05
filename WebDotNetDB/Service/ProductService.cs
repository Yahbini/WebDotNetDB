using WebDotNetDB.Models;

namespace WebDotNetDB.Service;

public interface ProductService
{
    public List<Product> findAll();
    public bool Create(Product product);
    public Product FindById(int id);


}
