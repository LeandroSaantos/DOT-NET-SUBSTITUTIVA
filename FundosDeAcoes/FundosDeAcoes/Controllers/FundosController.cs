using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FundosDeAcoes.Data;
using FundosDeAcoes.Models;

namespace FundosDeAcoes.Controllers
{
    public class FundosController : Controller
    {
        private readonly DataContext _context;

        public FundosController(DataContext context)
        {
            _context = context;
        }

        // GET: Fundos
        public async Task<IActionResult> Index()
        {
            return View(await _context.fundos.ToListAsync());
        }

        // GET: Fundos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundos = await _context.fundos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fundos == null)
            {
                return NotFound();
            }

            return View(fundos);
        }

        // GET: Fundos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fundos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Qtd,Preco")] Fundos fundos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fundos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fundos);
        }

        // GET: Fundos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundos = await _context.fundos.FindAsync(id);
            if (fundos == null)
            {
                return NotFound();
            }
            return View(fundos);
        }

        // POST: Fundos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Qtd,Preco")] Fundos fundos)
        {
            if (id != fundos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fundos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundosExists(fundos.Id))
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
            return View(fundos);
        }

        // GET: Fundos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundos = await _context.fundos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fundos == null)
            {
                return NotFound();
            }

            return View(fundos);
        }

        // POST: Fundos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fundos = await _context.fundos.FindAsync(id);
            _context.fundos.Remove(fundos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundosExists(int id)
        {
            return _context.fundos.Any(e => e.Id == id);
        }
    }
}
