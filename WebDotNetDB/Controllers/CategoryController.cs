using Microsoft.AspNetCore.Mvc;
using WebDotNetDB.Models;
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

    //[Route("~/")]
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



    [HttpGet]
    [Route("add")]
    public IActionResult Add()
    {
        var category = new Category();
        return View("Add", category);
    }

    [HttpPost]
    [Route("add")]
    public IActionResult Add(Category category)
    {
        if (ModelState.IsValid)
        {
            if (categoryService.Create(category))
            {
                // session flash
                TempData["Msg"] = "Success";
            }
            else
            {
                // session flash
                TempData["Msg"] = "Failed";
            }
            return RedirectToAction("index");
        }
        else
        {
            return View("Add");
        }

    }

    [Route("delete/{id}")]
    public IActionResult Delete(int id)
    {
        if (categoryService.Delete(id))
        {
            TempData["Msg"] = "Success";
        }
        else
        {
            TempData["Msg"] = "Failed";

        }
        return RedirectToAction("index");

    }

    [HttpGet]
    [Route("edit/{id}")]
    public IActionResult Edit(int id)
    {
        var category = categoryService.findById(id);
        return View("Edit", category);
    }

    [HttpPost]
    [Route("edit/{id}")]
    public IActionResult Edit(int id, Category category)
    {
        if (ModelState.IsValid)
        {
            if (categoryService.Update(category))
            {
                // session flash
                TempData["Msg"] = "Success";
            }
            else
            {
                // session flash
                TempData["Msg"] = "Failed";
            }
            return RedirectToAction("index");
        }
        else
        {
            return View("Edit");
        }
    }
}
