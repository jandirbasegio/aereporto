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
    public class ClientesPreferenciaisController : Controller
    {
        private readonly AeroportoContext _context;

        public ClientesPreferenciaisController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: ClientesPreferenciais
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientesPreferenciais.ToListAsync());
        }

        // GET: ClientesPreferenciais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesPreferenciais = await _context.ClientesPreferenciais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientesPreferenciais == null)
            {
                return NotFound();
            }

            return View(clientesPreferenciais);
        }

        // GET: ClientesPreferenciais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientesPreferenciais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telefone,DataNascimento,Gestante,Idoso")] ClientesPreferenciais clientesPreferenciais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesPreferenciais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientesPreferenciais);
        }

        // GET: ClientesPreferenciais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesPreferenciais = await _context.ClientesPreferenciais.FindAsync(id);
            if (clientesPreferenciais == null)
            {
                return NotFound();
            }
            return View(clientesPreferenciais);
        }

        // POST: ClientesPreferenciais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Telefone,DataNascimento,Gestante,Idoso")] ClientesPreferenciais clientesPreferenciais)
        {
            if (id != clientesPreferenciais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesPreferenciais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesPreferenciaisExists(clientesPreferenciais.Id))
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
            return View(clientesPreferenciais);
        }

        // GET: ClientesPreferenciais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesPreferenciais = await _context.ClientesPreferenciais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientesPreferenciais == null)
            {
                return NotFound();
            }

            return View(clientesPreferenciais);
        }

        // POST: ClientesPreferenciais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientesPreferenciais = await _context.ClientesPreferenciais.FindAsync(id);
            if (clientesPreferenciais != null)
            {
                _context.ClientesPreferenciais.Remove(clientesPreferenciais);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesPreferenciaisExists(int id)
        {
            return _context.ClientesPreferenciais.Any(e => e.Id == id);
        }
    }
}
