using System;
using System.Collections.Generic;

namespace InventarioAzure.Models.DB
{
    public partial class Inventario
    {
        public int Idregistro { get; set; }
        public int? Entradastock { get; set; }
        public int? Salidastock { get; set; }
        public int? IdUsuario { get; set; }
        public string? Codproducto { get; set; }
        public string? Observaciones { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdSucursal { get; set; }
        public int? IdEstante { get; set; }
        public int? IdFila { get; set; }

        public virtual Producto? CodproductoNavigation { get; set; }
        public virtual Estante? IdEstanteNavigation { get; set; }
        public virtual Fila? IdFilaNavigation { get; set; }
        public virtual Proveedor? IdProveedorNavigation { get; set; }
        public virtual Sucursal? IdSucursalNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
