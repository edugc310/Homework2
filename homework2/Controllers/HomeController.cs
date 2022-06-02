using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Homework2.Models;

namespace Homework2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string sortOrder)
    {

        ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id" : "";
        ViewData["NameSortParm"] = sortOrder == "name" ? "city" : "state";
        var contacts = new[]
        {
        new Contact{Id = 1, Name="dave", City="Seattle", State="WA", Phone="123"},
        new Contact{Id = 2, Name="mike", City="Spokane", State="WA", Phone="234"},
        new Contact{Id = 3, Name="lisa", City="San Jose", State="CA", Phone="345"},
        new Contact{Id = 4, Name="cathy", City="Dallas", State="TX", Phone="456"},
    };

        var contacts2 = from s in contacts
                        select s;
        if (sortOrder != null)
        {
            switch (sortOrder.ToLower())
            {
                case "id":
                    {
                        // modify contacts to be ordered by Id
                        contacts2 = contacts.OrderByDescending(s => s.Id);
                        break;
                    }
                case "name":
                    {
                        contacts2 = contacts.OrderByDescending(s => s.Name);
                        break;
                    }
                case "city":
                    {
                        contacts2 = contacts.OrderByDescending(s => s.City);
                        break;
                    }
                case "state":
                    {
                        contacts2 = contacts.OrderByDescending(s => s.State);
                        break;
                    }
                case "phone":
                    {
                        contacts2 = contacts.OrderByDescending(s => s.Phone);
                        break;
                    }
            }
        }

        return View(contacts2);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
