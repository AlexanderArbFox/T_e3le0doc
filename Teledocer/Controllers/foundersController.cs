using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teledocer.Models;

namespace Teledocer.Controllers
{
    public class foundersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public foundersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: founders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.founder.Include(f => f.Clients);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: founders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.founder
                .Include(f => f.Clients)
                .FirstOrDefaultAsync(m => m.Inn_uch == id);
            if (founder == null)
            {
                return NotFound();
            }

            return View(founder);
        }

        // GET: founders/Create
        public IActionResult Create()
        {
            ViewData["Id_founder"] = new SelectList(_context.Clients, "Id_clients", "Name_corp");
            return View();
        }

        // POST: founders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_founder,Inn_uch,Fio,Date_add,Date_reload")] founder founder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(founder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_founder"] = new SelectList(_context.Clients, "Id_clients", "Name_corp", founder.Id_founder);
            return View(founder);
        }

        // GET: founders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.founder.FindAsync(id);
            if (founder == null)
            {
                return NotFound();
            }
            ViewData["Id_founder"] = new SelectList(_context.Clients, "Id_clients", "Name_corp", founder.Id_founder);
            return View(founder);
        }

        // POST: founders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id_founder,Inn_uch,Fio,Date_add,Date_reload")] founder founder)
        {
            if (id != founder.Inn_uch)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(founder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!founderExists(founder.Inn_uch))
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
            ViewData["Id_founder"] = new SelectList(_context.Clients, "Id_clients", "Name_corp", founder.Id_founder);
            return View(founder);
        }

        // GET: founders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.founder
                .Include(f => f.Clients)
                .FirstOrDefaultAsync(m => m.Inn_uch == id);
            if (founder == null)
            {
                return NotFound();
            }

            return View(founder);
        }

        // POST: founders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var founder = await _context.founder.FindAsync(id);
            _context.founder.Remove(founder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool founderExists(long id)
        {
            return _context.founder.Any(e => e.Inn_uch == id);
        }
    }
}
