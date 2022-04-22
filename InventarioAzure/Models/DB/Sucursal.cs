using System;
using System.Collections.Generic;

namespace InventarioAzure.Models.DB
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public int IdSucursal { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Encargado { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
