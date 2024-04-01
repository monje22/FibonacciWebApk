using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using serie_fibonacci.Data;
using serie_fibonacci.Models;

namespace serie_fibonacci.Controllers
{
    public class FibonaccisController : Controller
    {
        private readonly serie_fibonacciContext _context;

        public FibonaccisController(serie_fibonacciContext context)
        {
            _context = context;
        }

        // GET: Fibonaccis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fibonacci.ToListAsync());
        }

        // GET: Fibonaccis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fibonacci = await _context.Fibonacci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fibonacci == null)
            {
                return NotFound();
            }

            return View(fibonacci);
        }

        // GET: Fibonaccis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fibonaccis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,FirstNum,SecondNum,TotalNum")] Fibonacci fibonacci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fibonacci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fibonacci);
        }

        // GET: Fibonaccis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fibonacci = await _context.Fibonacci.FindAsync(id);
            if (fibonacci == null)
            {
                return NotFound();
            }
            return View(fibonacci);
        }

        // POST: Fibonaccis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,FirstNum,SecondNum,TotalNum")] Fibonacci fibonacci)
        {
            if (id != fibonacci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fibonacci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FibonacciExists(fibonacci.Id))
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
            return View(fibonacci);
        }

        // GET: Fibonaccis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fibonacci = await _context.Fibonacci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fibonacci == null)
            {
                return NotFound();
            }

            return View(fibonacci);
        }

        // POST: Fibonaccis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fibonacci = await _context.Fibonacci.FindAsync(id);
            if (fibonacci != null)
            {
                _context.Fibonacci.Remove(fibonacci);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FibonacciExists(int id)
        {
            return _context.Fibonacci.Any(e => e.Id == id);
        }
    }
}
