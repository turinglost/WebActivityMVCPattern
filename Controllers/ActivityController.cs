using Microsoft.AspNetCore.Mvc;
using WebActivityMVCPattern.Models;

namespace WebActivityMVCPattern.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
