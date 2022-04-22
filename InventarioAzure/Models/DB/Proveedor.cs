using System;
using System.Collections.Generic;

namespace InventarioAzure.Models.DB
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public int IdProveedor { get; set; }
        public string? Empresa { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
