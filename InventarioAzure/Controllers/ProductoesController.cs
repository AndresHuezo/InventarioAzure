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
    public class ProductoesController : Controller
    {
        private readonly InventarioContext _context;

        public ProductoesController(InventarioContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            var inventarioContext = _context.Productos.Include(p => p.IdcategoriaNavigation);
            return View(await inventarioContext.ToListAsync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdcategoriaNavigation)
                .FirstOrDefaultAsync(m => m.Codproducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            
            ViewData["Idcategoria"] = new SelectList(_context.Categorias, "Idcategoria", "Nombre");
            //ViewDara["nombre"]= new SelectList(_context.Categorias,)
            
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codproducto,Nombre,Descripcion,Idcategoria,Stock,Precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcategoria"] = new SelectList(_context.Categorias, "Idcategoria", "Nombre", producto.Idcategoria);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Idcategoria"] = new SelectList(_context.Categorias, "Idcategoria", "Nombre", producto.Idcategoria);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Codproducto,Nombre,Descripcion,Idcategoria,Stock,Precio")] Producto producto)
        {
            if (id != producto.Codproducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Codproducto))
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
            ViewData["Idcategoria"] = new SelectList(_context.Categorias, "Idcategoria", "Nombre", producto.Idcategoria);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdcategoriaNavigation)
                .FirstOrDefaultAsync(m => m.Codproducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(string id)
        {
            return _context.Productos.Any(e => e.Codproducto == id);
        }
    }
}
