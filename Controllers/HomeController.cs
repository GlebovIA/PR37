using Microsoft.AspNetCore.Mvc;

namespace PR37.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public RedirectResult Index()
        {
            return Redirect("/Items/List");
        }
    }
}
