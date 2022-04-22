using System;
using System.Collections.Generic;

namespace InventarioAzure.Models.DB
{
    public partial class Usuario
    {
        public Usuario()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public int IdUsuario { get; set; }
        public string? Usuario1 { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }
        public string? Dui { get; set; }
        public int? Rol { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
