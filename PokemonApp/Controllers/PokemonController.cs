using Microsoft.AspNetCore.Mvc;
using negocio;
using dominio;

namespace PokemonApp.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonNegocio _negocio;

        public PokemonController(PokemonNegocio negocio)
        {
            _negocio = negocio;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Pokemon> listaPokemon = _negocio.listar();   
            return View(listaPokemon);
        }
    }
}
