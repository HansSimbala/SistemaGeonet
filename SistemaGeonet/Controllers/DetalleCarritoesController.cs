using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGeonet.Data;
using SistemaGeonet.Models;

namespace SistemaGeonet.Controllers
{
    public class DetalleCarritoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleCarritoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetalleCarritoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetalleCarrito.Include(d => d.carrito).Include(d => d.equipo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetalleCarritoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCarrito = await _context.DetalleCarrito
                .Include(d => d.carrito)
                .Include(d => d.equipo)
                .SingleOrDefaultAsync(m => m.IdDetalleCarrito == id);
            if (detalleCarrito == null)
            {
                return NotFound();
            }

            return View(detalleCarrito);
        }

        // GET: DetalleCarritoes/Create
        public IActionResult Create()
        {
            ViewData["IdCarrito"] = new SelectList(_context.Carrito, "IdCarrito", "IdCarrito");
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "idEquipo", "idEquipo");
            return View();
        }

        // POST: DetalleCarritoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleCarrito,IdCarrito,IdEquipo,cantidad")] DetalleCarrito detalleCarrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCarrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCarrito"] = new SelectList(_context.Carrito, "IdCarrito", "IdCarrito", detalleCarrito.IdCarrito);
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "idEquipo", "idEquipo", detalleCarrito.IdEquipo);
            return View(detalleCarrito);
        }

        // GET: DetalleCarritoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCarrito = await _context.DetalleCarrito.SingleOrDefaultAsync(m => m.IdDetalleCarrito == id);
            if (detalleCarrito == null)
            {
                return NotFound();
            }
            ViewData["IdCarrito"] = new SelectList(_context.Carrito, "IdCarrito", "IdCarrito", detalleCarrito.IdCarrito);
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "idEquipo", "idEquipo", detalleCarrito.IdEquipo);
            return View(detalleCarrito);
        }

        // POST: DetalleCarritoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleCarrito,IdCarrito,IdEquipo,cantidad")] DetalleCarrito detalleCarrito)
        {
            if (id != detalleCarrito.IdDetalleCarrito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCarrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCarritoExists(detalleCarrito.IdDetalleCarrito))
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
            ViewData["IdCarrito"] = new SelectList(_context.Carrito, "IdCarrito", "IdCarrito", detalleCarrito.IdCarrito);
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "idEquipo", "idEquipo", detalleCarrito.IdEquipo);
            return View(detalleCarrito);
        }

        // GET: DetalleCarritoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCarrito = await _context.DetalleCarrito
                .Include(d => d.carrito)
                .Include(d => d.equipo)
                .SingleOrDefaultAsync(m => m.IdDetalleCarrito == id);
            if (detalleCarrito == null)
            {
                return NotFound();
            }

            return View(detalleCarrito);
        }

        // POST: DetalleCarritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleCarrito = await _context.DetalleCarrito.SingleOrDefaultAsync(m => m.IdDetalleCarrito == id);
            _context.DetalleCarrito.Remove(detalleCarrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCarritoExists(int id)
        {
            return _context.DetalleCarrito.Any(e => e.IdDetalleCarrito == id);
        }
    }
}
