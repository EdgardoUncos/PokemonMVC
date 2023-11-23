using Microsoft.AspNetCore.Mvc;
using negocio;
using dominio;
using PokemonApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

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
        public IActionResult PokemonsLista(string buscar ="")
       {
            listaPokemon = _negocio.listar();

            if(!string.IsNullOrEmpty(buscar))
                listaPokemon = listaPokemon.FindAll(x => x.Nombre.ToUpper().Contains(buscar.ToUpper()));

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

        [HttpGet]
        public IActionResult FormularioPokemon2()
        {
            Pokemon pokemon = new Pokemon();
            ElementoNegocio negocio = new ElementoNegocio();
            ViewBag.listaElementos = negocio.listar();

            return View(pokemon);
        }

        [HttpPost]
        public IActionResult FormularioPokemon2(Pokemon pokemon)
        {
            int TipoSeleccionado = int.Parse(Request.Form["Tipo"].ToString());
            int DevilidadSeleccionada = int.Parse(Request.Form["Debilidad"].ToString());
            

            // Guardar en base de datos
            _negocio.agregarConSP(pokemon);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DetallePokemon(string id) 
        {
            if (id == null)
                return RedirectToAction("Index");
            Pokemon seleccionado = (_negocio.listar(id))[0];
                               
            return View(seleccionado);
        }

        [HttpGet]
        public IActionResult ModificarPokemon(string id)
        {
            if (id == null) return RedirectToAction("Index");

            Pokemon seleccionado = _negocio.listar(id)[0];
            PokemonVM pokemonVM = new PokemonVM(seleccionado.Tipo.Id.ToString(), seleccionado.Debilidad.Id.ToString());
            pokemonVM.Pokemon = seleccionado;
            object captura = pokemonVM.PokemonTipoSelectList.SelectedValue;
            return View(pokemonVM);
        }

        [HttpPost]
        public IActionResult ModificarPokemon(PokemonVM modificado)
        {
            int TipoSeleccionado = int.Parse(Request.Form["Tipo"].ToString());
            int Debilidad = int.Parse(Request.Form["Debilidad"].ToString());

            // Modificar el Pokemon
            modificado.Pokemon.Tipo.Id = TipoSeleccionado;
            modificado.Pokemon.Debilidad.Id = Debilidad;
            _negocio.modificar(modificado.Pokemon);

            return RedirectToAction("Index");
        }

        public IActionResult InactivarPokemon(int id)
        {
            Pokemon seleccionado = _negocio.listar(id.ToString())[0];
            _negocio.eliminarLogico(id, !seleccionado.Activo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ModificarPokemon2(string id)
        {
            if (id == null) return RedirectToAction("Index");

            Pokemon pokemon = _negocio.listar(id)[0];
            ElementoNegocio negocio = new ElementoNegocio();
            ViewBag.listaElementos = negocio.listar();
            ViewBag.listaElementos2 = negocio.listar();

            return View(pokemon);
        }

        [HttpPost]
        public IActionResult ModificarPokemon2(Pokemon modificado)
        {
            int TipoSeleccionado = int.Parse(Request.Form["Tipo"].ToString());
            int DevilidadSeleccionada = int.Parse(Request.Form["Debilidad"].ToString());


            // Guardar en base de datos
            _negocio.agregarConSP(modificado);

            return RedirectToAction("Index");
        }

        //Seccion Prueba PokemonLista con vistas Parciales
        [HttpGet]
        public IActionResult PokemonsLista2(string buscar = "")
        {
            
            listaPokemon = _negocio.listar();

            if (!string.IsNullOrEmpty(buscar))
                listaPokemon = listaPokemon.FindAll(x => x.Nombre.ToUpper().Contains(buscar.ToUpper()));

            return View(listaPokemon);
        }

        public IActionResult VistaTablaPokemon(string buscar = "")
        {
            listaPokemon = _negocio.listar();

            if (!string.IsNullOrEmpty(buscar))
                listaPokemon = listaPokemon.FindAll(x => x.Nombre.ToUpper().Contains(buscar.ToUpper()));
            return PartialView("_TablaPokemonLista", listaPokemon);
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
