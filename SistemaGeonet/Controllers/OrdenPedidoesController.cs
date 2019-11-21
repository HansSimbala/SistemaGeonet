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
    public class OrdenPedidoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenPedidoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdenPedidoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrdenPedido.Include(o => o.carritoOrden).Include(o => o.metodoPago);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrdenPedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenPedido = await _context.OrdenPedido
                .Include(o => o.carritoOrden)
                .Include(o => o.metodoPago)
                .SingleOrDefaultAsync(m => m.IdOrdenPedido == id);
            if (ordenPedido == null)
            {
                return NotFound();
            }

            return View(ordenPedido);
        }

        // GET: OrdenPedidoes/Create
        public IActionResult Create()
        {
            ViewData["IdCarritoOrden"] = new SelectList(_context.Set<CarritoOrden>(), "IdCarritoOrden", "IdCarritoOrden");
            ViewData["IdMetodoPago"] = new SelectList(_context.Set<MetodoPago>(), "IdMetodoPago", "IdMetodoPago");
            return View();
        }

        // POST: OrdenPedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrdenPedido,IdCarritoOrden,fechapedido,direccion,telefono,email,IdMetodoPago,IdPago")] OrdenPedido ordenPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCarritoOrden"] = new SelectList(_context.Set<CarritoOrden>(), "IdCarritoOrden", "IdCarritoOrden", ordenPedido.IdCarritoOrden);
            ViewData["IdMetodoPago"] = new SelectList(_context.Set<MetodoPago>(), "IdMetodoPago", "IdMetodoPago", ordenPedido.IdMetodoPago);
            return View(ordenPedido);
        }

        // POST: OrdenPedidoes/Agregar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<string> Agregar(int IdCarritoOrden, DateTime fechapedido, string direccion, string telefono, string email, int IdMetodoPago, int IdPago, OrdenPedido ordenPedido)
        {
            ordenPedido = new OrdenPedido {
                IdCarritoOrden = IdCarritoOrden,
                fechapedido = fechapedido,
                direccion=direccion,
                telefono = telefono,
                email = email,
                IdMetodoPago = IdMetodoPago, 
                IdPago = IdPago
            };
            _context.Add(ordenPedido);
            await _context.SaveChangesAsync();
            return "Success";
        }

        // GET: OrdenPedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenPedido = await _context.OrdenPedido.SingleOrDefaultAsync(m => m.IdOrdenPedido == id);
            if (ordenPedido == null)
            {
                return NotFound();
            }
            ViewData["IdCarritoOrden"] = new SelectList(_context.Set<CarritoOrden>(), "IdCarritoOrden", "IdCarritoOrden", ordenPedido.IdCarritoOrden);
            ViewData["IdMetodoPago"] = new SelectList(_context.Set<MetodoPago>(), "IdMetodoPago", "IdMetodoPago", ordenPedido.IdMetodoPago);
            return View(ordenPedido);
        }

        // POST: OrdenPedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrdenPedido,IdCarritoOrden,fechapedido,direccion,telefono,email,IdMetodoPago,IdPago")] OrdenPedido ordenPedido)
        {
            if (id != ordenPedido.IdOrdenPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenPedidoExists(ordenPedido.IdOrdenPedido))
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
            ViewData["IdCarritoOrden"] = new SelectList(_context.Set<CarritoOrden>(), "IdCarritoOrden", "IdCarritoOrden", ordenPedido.IdCarritoOrden);
            ViewData["IdMetodoPago"] = new SelectList(_context.Set<MetodoPago>(), "IdMetodoPago", "IdMetodoPago", ordenPedido.IdMetodoPago);
            return View(ordenPedido);
        }

        // GET: OrdenPedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenPedido = await _context.OrdenPedido
                .Include(o => o.carritoOrden)
                .Include(o => o.metodoPago)
                .SingleOrDefaultAsync(m => m.IdOrdenPedido == id);
            if (ordenPedido == null)
            {
                return NotFound();
            }

            return View(ordenPedido);
        }

        // POST: OrdenPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenPedido = await _context.OrdenPedido.SingleOrDefaultAsync(m => m.IdOrdenPedido == id);
            _context.OrdenPedido.Remove(ordenPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenPedidoExists(int id)
        {
            return _context.OrdenPedido.Any(e => e.IdOrdenPedido == id);
        }
    }
}
