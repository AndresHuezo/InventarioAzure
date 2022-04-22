using System;
using System.Collections.Generic;

namespace InventarioAzure.Models.DB
{
    public partial class Estante
    {
        public Estante()
        {
            Filas = new HashSet<Fila>();
            Inventarios = new HashSet<Inventario>();
        }

        public int IdEstante { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Fila> Filas { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
