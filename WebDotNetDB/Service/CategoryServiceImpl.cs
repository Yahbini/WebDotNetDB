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

    public bool Create(Category category)
    {
        try
        {
            dbContext.Categories.Add(category);
            return dbContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            dbContext.Categories.Remove(dbContext.Categories.Find(id));
            return dbContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
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

    public bool Update(Category category)
    {
        try
        {
            dbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
