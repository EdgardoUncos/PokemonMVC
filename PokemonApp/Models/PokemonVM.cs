using dominio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PokemonApp.Models
{
    public class PokemonVM
    {
        public PokemonVM() 
        { 
            Pokemon = new Pokemon();
            Pokemon.Tipo = new Elemento();
            Pokemon.Debilidad = new Elemento();
        }
        private SelectList _PokemonTipoSelectList { get; set; }
        public Pokemon Pokemon { get; set; }
        public SelectList PokemonTipoSelectList
        {
            get 
            { 
                if (_PokemonTipoSelectList != null)
                    return _PokemonTipoSelectList;

                return new SelectList(ObtenerElementos(), "Id", "Descripcion");
            }
            set
            {
                _PokemonTipoSelectList = value;
            }

        }

        private List<Elemento> ObtenerElementos()
        {
            var elementos = new List<Elemento>();
            elementos.Add(new Elemento() { Id = 1, Descripcion = "Planta" });
            elementos.Add(new Elemento() { Id = 2, Descripcion = "Fuego" });
            elementos.Add(new Elemento() { Id = 3, Descripcion = "Agua" });
            
            return elementos;
        }

    }
}
