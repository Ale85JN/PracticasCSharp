using BibliotecaMVC.Datos;
using BibliotecaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class EditorialController : Controller
    {
        public EditorialDatos _ED = new EditorialDatos();
        public IActionResult Index()
        {
            return View(_ED.ListarEditoriales(0));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Editorial editorial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Error = _ED.CrearEditorial(editorial);
                if (ViewBag.Error != "")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch 
            {
                return View();
            }
        }
        //falta hacer el Edit
    }
}
