using System;
using System.Collections.Generic;

namespace InventarioAzure.Models.DB
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public int Idcategoria { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
