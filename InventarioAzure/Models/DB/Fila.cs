using System;
using System.Collections.Generic;

namespace InventarioAzure.Models.DB
{
    public partial class Fila
    {
        public int IdFila { get; set; }
        public string? Nombre { get; set; }
        public int? IdEstante { get; set; }

        public virtual Estante? IdEstanteNavigation { get; set; }
    }
}
