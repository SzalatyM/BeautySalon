using BeautySalon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Controllers
{
    
    public class ServicesController : Controller
    {
        
        public IActionResult Services()
        {
            var services = new List<Service>()
    {
        new Service { Name = "Eyebrow Lamination" },
        new Service { Name = "Manicure" },
        new Service { Name = "Pedicure" },
        new Service { Name = "Massage" },
        new Service { Name = "Facial" }
    };
            return View(services);
        }
    }
}