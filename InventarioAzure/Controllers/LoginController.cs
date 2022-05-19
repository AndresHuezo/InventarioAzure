using InventarioAzure.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAzure.Controllers
{
    public class LoginController : Controller
    {
        private readonly InventarioContext _context;

        public LoginController(InventarioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GetUsuarios(string usuario, string pass)
        {
            var usuarios = _context.Usuarios.Where(s => s.Usuario1 == usuario && s.Password == pass);
            if (usuarios.Any())
            {
                if (usuarios.Where(s => s.Usuario1 == usuario && s.Password == pass).Any())
                {
                    return Redirect("../Home/");
                }
                else
                {
                    ViewData["Message"] = "Usario no registrado";
                    return View();
                }
            }
            else
            {
                ViewData["Message"] = "Usario Incorrecto";
                return View();

            }
        }
    }
}
