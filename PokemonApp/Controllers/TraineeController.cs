using Microsoft.AspNetCore.Mvc;
using dominio;
using negocio;

namespace PokemonApp.Controllers
{
    public class TraineeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            Trainee user = new Trainee();
            user.Pass = string.Empty;
            return View(user);
        }

        [HttpPost]
        public IActionResult Login(Trainee trainee)
        {
            TraineeNegocio negocio = new TraineeNegocio();

            if (negocio.Login(trainee))
            {
                ViewBag.User = trainee;

                return View("MiPerfil", trainee);
                //return RedirectToAction("MiPerfil");
            }
            else
            {
                ViewBag.Error = "Usuario o Pass incorrectos";
                return View("Error");
            }

        }

        [HttpGet]
        public IActionResult MiPerfil()
        {
            if(ViewBag.User != null)
            {
                Trainee User = (Trainee)ViewBag.User;
                return View(User);
            }
            else
            {
                ViewBag.Error = "Error debe loguearse para ingresa a mi Perfil";
                return View("Error");
            }
        }
    }
}
