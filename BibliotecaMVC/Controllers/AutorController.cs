using BibliotecaMVC.Datos;
using BibliotecaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class AutorController : Controller
    {
        public BibliotecaDatos _BD = new BibliotecaDatos();//el controlador se conecta a biblioteca datos
        public IActionResult Index()
        {
            return View(_BD.ListarAutores(0));
        }
        public IActionResult Create()
        {
            return View();//envia la lista al usuario
        }
        [HttpPost]
        public IActionResult Create(Autor autor)//recibimos un objeto autor
        {
            try// siempre que sea un create o un edit, debemos verificar que el modelo sea valido
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Error =_BD.CrearAutor(autor);//forma de decirle a la vista que tome 
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
        public IActionResult Details(int id)// solo metodo get, porque solo muestra informacion
        {
            return View(_BD.ListarAutores(id).FirstOrDefault());
        }
        public IActionResult Edit(int id)
        {
           return View (_BD.ListarAutores(id).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Edit(Autor autor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();// retornar que los datos no son los correctos
                }
               ViewBag.Error =_BD.EditarAutor(autor);// si no tuvo error debuelve una lista vacia
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
        public IActionResult Delete(int id)
        {
            return View(_BD.ListarAutores(id).FirstOrDefault());
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (_BD.ListarAutores(id).Any())
                {
                    ViewBag.Error = _BD.BorrarAutor(id);
                    if (ViewBag.Error != "")
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
