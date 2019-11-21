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
    public class DetalleCarritoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;

        public DetalleCarritoesController(ApplicationDbContext context, UserManager<ApplicationUser> userManage)
        {
            _context = context;
            _userManager = userManage;
        }

        // GET: DetalleCarritoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetalleCarrito.Include(d => d.equipo);
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
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "idEquipo", "idEquipo");
            return View();
        }

        // POST: DetalleCarritoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleCarrito,hasOrden,IdCarrito,IdEquipo,cantidad")] DetalleCarrito detalleCarrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCarrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "idEquipo", "idEquipo", detalleCarrito.IdEquipo);
            return View(detalleCarrito);
        }

        // POST: DetalleCarritoes/Agregar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<String> Agregar(int hasOrden, int IdCarrito, int IdEquipo, int cantidad, DetalleCarrito detalleCarrito)
        {
            var userId = _userManager.GetUserId(User);
            var tCarrito = await _context.Carrito.SingleOrDefaultAsync(m => m.IdUsuario == userId);
            var idCarrito = tCarrito.IdCarrito;
            detalleCarrito = new DetalleCarrito {
                hasOrden = hasOrden,
                IdCarrito = idCarrito,
                IdEquipo = IdEquipo,
                cantidad = cantidad
            };
            _context.Add(detalleCarrito);
            await _context.SaveChangesAsync();           
            return "success";
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
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "idEquipo", "idEquipo", detalleCarrito.IdEquipo);
            return View(detalleCarrito);
        }


        // POST: DetalleCarritoes/EditarCarrito/
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<string> EditarCarrito(int IdCarrito, int IdCarritoOrden)
        {
            List<DetalleCarrito> list = new List<DetalleCarrito>();
            var applicationDbContext = _context.DetalleCarrito.Include(d => d.equipo);
            List<DetalleCarrito> listDetalles = await applicationDbContext.ToListAsync();
            bool a = false;
            a = listDetalles[0].IdCarrito == 2;

            for (int i = 0; i < listDetalles.Count; i++)
            {
                if (listDetalles[i].IdCarrito==IdCarrito)
                {
                    list.Add(listDetalles[i]);
                }
            }

            for (int j = 0; j < list.Count; j++)
            {
                list[j].IdCarrito = IdCarritoOrden;
                list[j].hasOrden = 1;
                _context.Update(list[j]);
                await _context.SaveChangesAsync();
            }
            return "success";
        }

        // POST: DetalleCarritoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleCarrito,hasOrden,IdCarrito,IdEquipo,cantidad")] DetalleCarrito detalleCarrito)
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
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "idEquipo", "idEquipo", detalleCarrito.IdEquipo);
            return View(detalleCarrito);
        }

        [HttpPost]
        public async Task<String> Editar(int IdDetalleCarrito, int cantidad)
        {
            var detalleCarrito = await _context.DetalleCarrito.SingleOrDefaultAsync(m => m.IdDetalleCarrito == IdDetalleCarrito);
            detalleCarrito.cantidad = cantidad;
            _context.Update(detalleCarrito);
            await _context.SaveChangesAsync();
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "idEquipo", "idEquipo", detalleCarrito.IdEquipo);
            return "Edited";
        }

        // GET: DetalleCarritoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCarrito = await _context.DetalleCarrito
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

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var detalleCarrito = await _context.DetalleCarrito.SingleOrDefaultAsync(m => m.IdDetalleCarrito == id);
            _context.DetalleCarrito.Remove(detalleCarrito);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Carritoes");
        }

        private bool DetalleCarritoExists(int id)
        {
            return _context.DetalleCarrito.Any(e => e.IdDetalleCarrito == id);
        }
    }
}
