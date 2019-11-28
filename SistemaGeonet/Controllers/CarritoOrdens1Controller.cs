using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGeonet.Data;
using SistemaGeonet.Models;

namespace SistemaGeonet.Controllers
{
    public class CarritoOrdens1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarritoOrdens1Controller(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CarritoOrdens1
        public async Task<IActionResult> Index(int? id)
        {
            var userId = _userManager.GetUserId(User);
            ViewData["idusuario"] = userId;

            List<DetalleCarrito> listDetalles = _context.Set<DetalleCarrito>().Include(s => s.equipo).ToList();
            List<DetalleCarrito> listCarrito = new List<DetalleCarrito>();
            for (int i = 0; i < listDetalles.Count; i++)
            {
                if (listDetalles[i].IdCarrito == id) {
                    listCarrito.Add(listDetalles[i]);
                }

            }
            ViewData["listaDetalleCarrito"] = listCarrito;
            return View(await _context.CarritoOrden.ToListAsync());
        }

        // GET: CarritoOrdens1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoOrden = await _context.CarritoOrden
                .SingleOrDefaultAsync(m => m.IdCarritoOrden == id);
            if (carritoOrden == null)
            {
                return NotFound();
            }

            return View(carritoOrden);
        }

        // GET: CarritoOrdens1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarritoOrdens1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarritoOrden,IdUsuario,precioTotal,estado")] CarritoOrden carritoOrden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carritoOrden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carritoOrden);
        }

        // GET: CarritoOrdens1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoOrden = await _context.CarritoOrden.SingleOrDefaultAsync(m => m.IdCarritoOrden == id);
            if (carritoOrden == null)
            {
                return NotFound();
            }
            return View(carritoOrden);
        }

        // POST: CarritoOrdens1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCarritoOrden,IdUsuario,precioTotal,estado")] CarritoOrden carritoOrden)
        {
            if (id != carritoOrden.IdCarritoOrden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carritoOrden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoOrdenExists(carritoOrden.IdCarritoOrden))
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
            return View(carritoOrden);
        }

        // GET: CarritoOrdens1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoOrden = await _context.CarritoOrden
                .SingleOrDefaultAsync(m => m.IdCarritoOrden == id);
            if (carritoOrden == null)
            {
                return NotFound();
            }

            return View(carritoOrden);
        }

        // POST: CarritoOrdens1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carritoOrden = await _context.CarritoOrden.SingleOrDefaultAsync(m => m.IdCarritoOrden == id);
            _context.CarritoOrden.Remove(carritoOrden);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoOrdenExists(int id)
        {
            return _context.CarritoOrden.Any(e => e.IdCarritoOrden == id);
        }
    }
}
