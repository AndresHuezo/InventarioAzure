using System;
using System.Collections.Generic;

namespace InventarioAzure.Models.DB
{
    public partial class Producto
    {
        public Producto()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public string Codproducto { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Idcategoria { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }

        public virtual Categoria? IdcategoriaNavigation { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
