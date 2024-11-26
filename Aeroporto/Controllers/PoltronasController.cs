using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aeroporto.Models;

namespace Aeroporto.Controllers
{
    public class AssentoController : Controller
    {
        private readonly AeroportoContext _context;

        public AssentoController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: Assento
        public async Task<IActionResult> Index()
        {
            var AeroportoContext = _context.Assento.Include(p => p.Aeronave);
            return View(await AeroportoContext.ToListAsync());
        }

        // GET: Assento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poltrona = await _context.Assento
                .Include(p => p.Aeronave)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poltrona == null)
            {
                return NotFound();
            }

            return View(poltrona);
        }

        // GET: Assento/Create
        public IActionResult Create()
        {
            ViewData["AeronaveId"] = new SelectList(_context.Aeronaves, "Id", "Id");
            return View();
        }

        // POST: Assento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AeronaveId,Numero,Localizacao,Disponibilidade")] Poltrona poltrona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poltrona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AeronaveId"] = new SelectList(_context.Aeronaves, "Id", "Id", poltrona.AeronaveId);
            return View(poltrona);
        }

        // GET: Assento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poltrona = await _context.Assento.FindAsync(id);
            if (poltrona == null)
            {
                return NotFound();
            }
            ViewData["AeronaveId"] = new SelectList(_context.Aeronaves, "Id", "Id", poltrona.AeronaveId);
            return View(poltrona);
        }

        // POST: Assento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AeronaveId,Numero,Localizacao,Disponibilidade")] Poltrona poltrona)
        {
            if (id != poltrona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poltrona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoltronaExists(poltrona.Id))
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
            ViewData["AeronaveId"] = new SelectList(_context.Aeronaves, "Id", "Id", poltrona.AeronaveId);
            return View(poltrona);
        }

        // GET: Assento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poltrona = await _context.Assento
                .Include(p => p.Aeronave)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poltrona == null)
            {
                return NotFound();
            }

            return View(poltrona);
        }

        // POST: Assento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poltrona = await _context.Assento.FindAsync(id);
            if (poltrona != null)
            {
                _context.Assento.Remove(poltrona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoltronaExists(int id)
        {
            return _context.Assento.Any(e => e.Id == id);
        }
    }
}
