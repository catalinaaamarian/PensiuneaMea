using Microsoft.AspNetCore.Mvc;
namespace PensiuneaMea.Models
{
   

    public class RezervareController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rezerva(ModelulTauDeRezervare model)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Confirmare");
            }

            return View("Index", model);
        }
    }
}
