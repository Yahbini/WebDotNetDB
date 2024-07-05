using Microsoft.AspNetCore.Mvc;
using WebDotNetDB.Models;
using WebDotNetDB.Service;

namespace WebDotNetDB.Controllers;
[Route("account")]
public class AccountController : Controller
{
    private AccountService accountService;

    public AccountController(AccountService accountService)
    {
        this.accountService = accountService;
    }

    [HttpGet]
    //[Route("~/")]
    [Route("")]
    [Route("login")]
    public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(string username, string password)
    {
        if (accountService.Login(username, password))
        {
            HttpContext.Session.SetString("username", username);
            return RedirectToAction("welcome");
        }
        else
        {
            TempData["Msg"] = "Failed";
            return RedirectToAction("login");
        }
    }

    [HttpGet]
    [Route("register")]
    public IActionResult Register()
    {
        var account = new Account();
        account.Dob = DateTime.Now;
        return View("Register", account);
    }

    [HttpPost]
    [Route("register")]
    public IActionResult Register(Account account)
    {
        account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
        account.Status = true;
        account.SecurityCode = Guid.NewGuid().ToString().ToString().Replace("-", "");
        if (accountService.Create(account))
        {
            return RedirectToAction("Login");
        }
        else
        {
            TempData["Msg"] = "Failed";
            return RedirectToAction("register");
        }
    }

    [Route("welcome")]
    public IActionResult Welcome()
    {
        return View("Welcome");
    }

    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("username");
        return RedirectToAction("login");
    }

    [HttpGet]
    [Route("profile")]
    public IActionResult Profile()
    {
        var username = HttpContext.Session.GetString("username");
        var account = accountService.FindByUsername(username);
        return View("Profile", account);
    }

    [HttpPost]
    [Route("profile")]
    public IActionResult Profile(Account account)
    {
        var username = HttpContext.Session.GetString("username");
        var curentAccount = accountService.FindByUsername(username);
        if (!string.IsNullOrEmpty(account.Password))
        {
            curentAccount.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
        }
        curentAccount.FullName = account.FullName;
        curentAccount.Dob = account.Dob;
        if (accountService.Update(curentAccount))
        {
            return RedirectToAction("login");
        }
        else
        {
            TempData["Msg"] = "Failed";
            return RedirectToAction("profile");
        }
    }
}
