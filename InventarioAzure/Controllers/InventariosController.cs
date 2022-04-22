#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioAzure.Models.DB;

namespace InventarioAzure.Controllers
{
    public class InventariosController : Controller
    {
        private readonly InventarioContext _context;

        public InventariosController(InventarioContext context)
        {
            _context = context;
        }

        // GET: Inventarios
        public async Task<IActionResult> Index()
        {
            var inventarioContext = _context.Inventarios.Include(i => i.CodproductoNavigation).Include(i => i.IdEstanteNavigation).Include(i => i.IdProveedorNavigation).Include(i => i.IdSucursalNavigation).Include(i => i.IdUsuarioNavigation);
            return View(await inventarioContext.ToListAsync());
        }

        // GET: Inventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios
                .Include(i => i.CodproductoNavigation)
                .Include(i => i.IdEstanteNavigation)
                .Include(i => i.IdProveedorNavigation)
                .Include(i => i.IdSucursalNavigation)
                .Include(i => i.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Idregistro == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: Inventarios/Create
        public IActionResult Create()
        {
            ViewData["Codproducto"] = new SelectList(_context.Productos, "Codproducto", "Codproducto");
            ViewData["IdEstante"] = new SelectList(_context.Estantes, "IdEstante", "IdEstante");
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor");
            ViewData["IdSucursal"] = new SelectList(_context.Sucursals, "IdSucursal", "IdSucursal");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idregistro,Entradastock,Salidastock,IdUsuario,Codproducto,Observaciones,IdProveedor,IdSucursal,IdEstante,IdFila")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codproducto"] = new SelectList(_context.Productos, "Codproducto", "Codproducto", inventario.Codproducto);
            ViewData["IdEstante"] = new SelectList(_context.Estantes, "IdEstante", "IdEstante", inventario.IdEstante);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", inventario.IdProveedor);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursals, "IdSucursal", "IdSucursal", inventario.IdSucursal);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inventario.IdUsuario);
            return View(inventario);
        }

        // GET: Inventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            ViewData["Codproducto"] = new SelectList(_context.Productos, "Codproducto", "Codproducto", inventario.Codproducto);
            ViewData["IdEstante"] = new SelectList(_context.Estantes, "IdEstante", "IdEstante", inventario.IdEstante);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", inventario.IdProveedor);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursals, "IdSucursal", "IdSucursal", inventario.IdSucursal);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inventario.IdUsuario);
            return View(inventario);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idregistro,Entradastock,Salidastock,IdUsuario,Codproducto,Observaciones,IdProveedor,IdSucursal,IdEstante,IdFila")] Inventario inventario)
        {
            if (id != inventario.Idregistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.Idregistro))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codproducto"] = new SelectList(_context.Productos, "Codproducto", "Codproducto", inventario.Codproducto);
            ViewData["IdEstante"] = new SelectList(_context.Estantes, "IdEstante", "IdEstante", inventario.IdEstante);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", inventario.IdProveedor);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursals, "IdSucursal", "IdSucursal", inventario.IdSucursal);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inventario.IdUsuario);
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios
                .Include(i => i.CodproductoNavigation)
                .Include(i => i.IdEstanteNavigation)
                .Include(i => i.IdProveedorNavigation)
                .Include(i => i.IdSucursalNavigation)
                .Include(i => i.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Idregistro == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);
            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioExists(int id)
        {
            return _context.Inventarios.Any(e => e.Idregistro == id);
        }
    }
}
