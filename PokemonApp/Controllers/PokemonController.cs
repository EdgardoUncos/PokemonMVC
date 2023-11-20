using Microsoft.AspNetCore.Mvc;
using negocio;
using dominio;
using PokemonApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PokemonApp.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonNegocio _negocio;
        public List<dominio.Pokemon> listaPokemon;
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
            PokemonVM pokemon = new PokemonVM();
            
            return View(pokemon);
        }

        [HttpPost]
        public IActionResult FormularioPokemon(PokemonVM pokemonVm)
        {
            int TipoSeleccionado = int.Parse(Request.Form["Tipo"].ToString());
            int DevilidadSeleccionada = int.Parse(Request.Form["Debilidad"].ToString());
            PokemonVM pokemon = new PokemonVM();

            // Cargar Pokemon con info del formulario
            Pokemon nuevo = pokemonVm.Pokemon;
            nuevo.Tipo.Id = TipoSeleccionado;
            nuevo.Debilidad.Id = DevilidadSeleccionada;

            // Guardar en base de datos
            _negocio.agregarConSP(nuevo);

            return RedirectToAction("Index");
        }

        //public IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<PokemonApp.Models.Elemento> elements)
        //{
        //    var selectList = new List<SelectListItem>();

        //    foreach (var element in elements)
        //    {
        //        selectList.Add(new SelectListItem
        //        {
        //            Value = element.Id.ToString(),
        //            Text = element.Descripcion
        //        });
        //    }
        //    return selectList;
        //}
        


    }
}
