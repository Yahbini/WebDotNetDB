using Microsoft.EntityFrameworkCore;
using WebDotNetDB.Models;

namespace WebDotNetDB.Service;

public class CategoryServiceImpl : CategoryService
{
    private DatabaseContext dbContext;

    public CategoryServiceImpl(DatabaseContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public List<Category> findAll()
    {
        return dbContext.Categories.ToList();
    }

    public Category findById(int id)
    {
        return dbContext.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
    }

    public List<Category> findByKeyWord(string keyword)
    {
        return dbContext.Categories.Where(c => c.Name.Contains(keyword)).ToList();
    }
}
