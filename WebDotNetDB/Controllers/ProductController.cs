using Microsoft.AspNetCore.Mvc;
using WebDotNetDB.Helpers;
using WebDotNetDB.Models;
using WebDotNetDB.Service;

namespace WebDotNetDB.Controllers;
[Route("product")]

public class ProductController : Controller
{
    private ProductService productService;
    private CategoryService categoryService;
    private IWebHostEnvironment webHostEnvironment;

    public ProductController(ProductService _productService, CategoryService _categoryService, IWebHostEnvironment _webHostEnvironment)
    {
        productService = _productService;
        categoryService = _categoryService;
        webHostEnvironment = _webHostEnvironment;
    }

    [Route("~/")]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.products = productService.findAll();
        return View();
    }

    [HttpGet]
    [Route("add")]
    public IActionResult Add()
    {
        ViewBag.categories = categoryService.findAll();
        var product = new Product
        {
            Created = DateTime.Now
        };
        return View("Add", product);
    }

    [HttpPost]
    [Route("add")]
    public IActionResult Add(Product product, IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            var fileName = FileHelper.generateFileName(file.FileName);
            var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            product.Photo = fileName;
        }
        else
        {
            product.Photo = "no-image.jpg";
        }
        if (productService.Create(product))
        {
            TempData["Msg"] = "Success";
            return RedirectToAction("index");
        }
        else
        {
            TempData["Msg"] = "Failed";
            return RedirectToAction("add");
        }
    }

    [HttpGet]
    [Route("edit/{id}")]
    public IActionResult Edit(int id)
    {
        ViewBag.categories = categoryService.findAll();
        var product = productService.FindById(id);
        return View("Edit", product);
    }
}
