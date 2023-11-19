using Microsoft.AspNetCore.Mvc;
using negocio;
using dominio;

namespace PokemonApp.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonNegocio _negocio;
        public List<Pokemon> listaPokemon;
        public PokemonController(PokemonNegocio negocio)
        {
            _negocio = negocio;
        }
        [HttpGet]
        public IActionResult Index()
        {
            listaPokemon = _negocio.listar();   
            return View(listaPokemon);
        }

        [HttpGet]
        public IActionResult PokemonsLista()
        {
            listaPokemon = _negocio.listar();
            return View(listaPokemon);
        }

        [HttpGet]
        public IActionResult PokemonsLista2()
        {
            listaPokemon = _negocio.listar();
            return View(listaPokemon);
        }

        [HttpGet]
        public IActionResult FormularioPokemon()
        {
            return View();
        }


    }
}
