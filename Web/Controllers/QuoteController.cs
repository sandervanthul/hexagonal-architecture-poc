using System.Diagnostics;
using Domain.UseCases.GiveQuote;
using Infrastructure.Common.Presenters;
using Infrastructure.Console;
using Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class QuoteController : Controller
{
    private readonly ILogger<QuoteController> _logger;
    private readonly WebAdapter _adapter;

    public QuoteController(ILogger<QuoteController> logger, WebAdapter adapter)
    {
        _logger = logger;
        _adapter = adapter;
    }

    public IActionResult Index()
    {
        var quote = _adapter.GiveMeAQuote();
        
        return View(quote);
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