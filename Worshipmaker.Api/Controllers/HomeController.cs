using Microsoft.AspNetCore.Mvc;

namespace Worshipmaker.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Worshipmaker API";
        }
    }
}