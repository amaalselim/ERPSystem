namespace ERP.Web.Controllers;

public class HomeController(ILogger<HomeController> _logger) : Controller  //we didn't have to use Constructor Injection here, we could have used Property Injection or Method Injection as well.
{
    public IActionResult Index()
    {
        return View();
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
