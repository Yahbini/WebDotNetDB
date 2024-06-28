using WebDotNetDB.Models;

namespace WebDotNetDB.Service;

public interface CategoryService
{
    public List<Category> findAll();
    public Category findById(int id);
    public List<Category> findByKeyWord(string keyword);
    public bool Create(Category category);
    public bool Delete(int id);
    public bool Update(Category category);


}
