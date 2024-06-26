using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebDotNetDB.Controllers;
[Route("homepage")]

public class HomeController : Controller
{
    private IConfiguration configuration;

    public HomeController(IConfiguration _configuration)
    {
        configuration = _configuration;
    }
    [Route("")]
    [Route("index")]
    //[Route("~/")]
    public IActionResult Index()
    {
        string config1 = configuration["Config1"].ToString();
        Debug.WriteLine("Config1: " + config1);
        string config2 = configuration["Config2:Config2_1"].ToString();
        Debug.WriteLine("Config2_1: " + config2);
        string config3 = configuration["Config2:Config2_2:Config_2_2_1"].ToString();
        Debug.WriteLine("Config2_2_1: " + config3);
        return View();
    }
}
