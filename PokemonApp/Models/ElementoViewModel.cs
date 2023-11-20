using Microsoft.AspNetCore.Mvc.Rendering;
using dominio;

namespace PokemonApp.Models
{
    public class ElementoViewModel: Elemento
    {
        public IEnumerable<SelectListItem> Tipo { get; set; }

        
    }
}
