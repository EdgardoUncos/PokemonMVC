using dominio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PokemonApp.Models
{
    public class PokemonVM
    {
        // Constructor
        public PokemonVM() 
        { 
            Pokemon = new Pokemon();
            Pokemon.Tipo = new Elemento();
            Pokemon.Debilidad = new Elemento();
        }

        public PokemonVM(string tipo, string debilidad)
        {
            Pokemon = new Pokemon();
            Pokemon.Tipo = new Elemento();
            Pokemon.Debilidad = new Elemento();
            Pokemon.Tipo.Id = int.Parse(tipo);
            Pokemon.Debilidad.Id = int.Parse(debilidad);

        }
        private SelectList _PokemonTipoSelectList { get; set; }

        private SelectList _PokemonDebilidadSelectList { get; set; }
        public Pokemon Pokemon { get; set; }
        public SelectList PokemonTipoSelectList
        {
            get 
            { 
                if (_PokemonTipoSelectList != null)
                    return _PokemonTipoSelectList;

                if (Pokemon.Tipo.Id > 0)
                    return new SelectList(ObtenerElementos(), "Id", "Descripcion", Pokemon.Tipo.Id.ToString());
                else
                    return new SelectList(ObtenerElementos(), "Id", "Descripcion");
            }
            set
            {
                _PokemonTipoSelectList = value;
            }

        }
        public SelectList PokemonDebilidadSelectList
        {
            get
            {
                if (_PokemonDebilidadSelectList != null)
                    return _PokemonDebilidadSelectList;

                if (Pokemon.Debilidad.Id > 0)
                    return new SelectList(ObtenerElementos(), "Id", "Descripcion", Pokemon.Debilidad.Id.ToString());
                else
                    return new SelectList(ObtenerElementos(), "Id", "Descripcion");
            }
            set
            {
                _PokemonDebilidadSelectList = value;
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
