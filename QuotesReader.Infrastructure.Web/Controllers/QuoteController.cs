using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuotesReader.Infrastructure.Web.Models;

namespace QuotesReader.Infrastructure.Web.Controllers;

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
        var quote = _adapter.RequestQuote();
        
        return View(quote);
    }
}