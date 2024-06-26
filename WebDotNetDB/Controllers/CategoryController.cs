using Microsoft.AspNetCore.Mvc;
using WebDotNetDB.Service;

namespace WebDotNetDB.Controllers;
[Route("category")]
public class CategoryController : Controller
{
    private CategoryService categoryService;

    public CategoryController(CategoryService _categoryService)
    {
        categoryService = _categoryService;
    }

    [Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        ViewBag.categories = categoryService.findAll();
        return View();
    }

    [Route("details/{id}")]
    public IActionResult Details(int id)
    {
        ViewBag.category = categoryService.findById(id);
        return View();
    }

    [HttpGet]
    [Route("searchByKeyWord")]
    public IActionResult searchByKeyWord(string keyword)
    {
        ViewBag.categories = categoryService.findByKeyWord(keyword);
        ViewBag.keyword = keyword;
        return View("Index");
    }
}
