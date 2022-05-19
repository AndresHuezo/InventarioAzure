using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventarioAzure.Models.DB
{
    public partial class InventarioContext : DbContext
    {
        public InventarioContext()
        {
        }

        public InventarioContext(DbContextOptions<InventarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Estante> Estantes { get; set; } = null!;
        public virtual DbSet<Fila> Filas { get; set; } = null!;
        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Inventario;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PK__Categori__140587C709433E1F");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estante>(entity =>
            {
                entity.HasKey(e => e.IdEstante)
                    .HasName("PK__Estante__A83CC9D941EE2D53");

                entity.ToTable("Estante");

                entity.Property(e => e.IdEstante).HasColumnName("idEstante");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Fila>(entity =>
            {
                entity.HasKey(e => e.IdFila)
                    .HasName("PK__Fila__775AFF8EFE22543F");

                entity.ToTable("Fila");

                entity.Property(e => e.IdFila).HasColumnName("idFila");

                entity.Property(e => e.IdEstante).HasColumnName("idEstante");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdEstanteNavigation)
                    .WithMany(p => p.Filas)
                    .HasForeignKey(d => d.IdEstante)
                    .HasConstraintName("FK_fila_estante");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.Idregistro)
                    .HasName("PK__Inventar__917BB52907A49C4C");

                entity.ToTable("Inventario");

                entity.Property(e => e.Idregistro).HasColumnName("idregistro");

                entity.Property(e => e.Codproducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codproducto");

                entity.Property(e => e.Entradastock).HasColumnName("entradastock");

                entity.Property(e => e.IdEstante).HasColumnName("idEstante");

                entity.Property(e => e.IdFila).HasColumnName("idFila");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.Salidastock).HasColumnName("salidastock");

                entity.HasOne(d => d.CodproductoNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Codproducto)
                    .HasConstraintName("FK_inventario_productos");

                entity.HasOne(d => d.IdEstanteNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdEstante)
                    .HasConstraintName("FK_inventario_estante");

                entity.HasOne(d => d.IdFilaNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdFila)
                    .HasConstraintName("FK_Inventario_Fila");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_inventario_proveedor");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK_inventario_sucursal");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_inventario_usuarios");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Codproducto)
                    .HasName("PK__Producto__7FC39CF5CC4C94A0");

                entity.Property(e => e.Codproducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codproducto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_productos_categorias");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__A3FA8E6B6FF0FAEE");

                entity.ToTable("Proveedor");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.Direccion)
                    .HasColumnType("text")
                    .HasColumnName("direccion");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("empresa");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK__Sucursal__F707694C13B2BC2C");

                entity.ToTable("Sucursal");

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.Direccion)
                    .HasColumnType("text")
                    .HasColumnName("direccion");

                entity.Property(e => e.Encargado)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("encargado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A631F4F3B7");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Dui)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
