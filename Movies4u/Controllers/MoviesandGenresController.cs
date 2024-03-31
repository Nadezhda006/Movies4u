using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies4u.Data;

namespace Movies4u.Controllers
{
    public class MoviesandGenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesandGenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoviesandGenres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MoviesandGenres.Include(m => m.Genre).Include(m => m.Movies);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MoviesandGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MoviesandGenres == null)
            {
                return NotFound();
            }

            var moviesandGenres = await _context.MoviesandGenres
                .Include(m => m.Genre)
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviesandGenres == null)
            {
                return NotFound();
            }

            return View(moviesandGenres);
        }

        // GET: MoviesandGenres/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id");
            ViewData["MoviesId"] = new SelectList(_context.Movies, "Id", "Id");
            return View();
        }

        // POST: MoviesandGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MoviesId,GenreId")] MoviesandGenres moviesandGenres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviesandGenres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", moviesandGenres.GenreId);
            ViewData["MoviesId"] = new SelectList(_context.Movies, "Id", "Id", moviesandGenres.MoviesId);
            return View(moviesandGenres);
        }

        // GET: MoviesandGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MoviesandGenres == null)
            {
                return NotFound();
            }

            var moviesandGenres = await _context.MoviesandGenres.FindAsync(id);
            if (moviesandGenres == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", moviesandGenres.GenreId);
            ViewData["MoviesId"] = new SelectList(_context.Movies, "Id", "Id", moviesandGenres.MoviesId);
            return View(moviesandGenres);
        }

        // POST: MoviesandGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MoviesId,GenreId")] MoviesandGenres moviesandGenres)
        {
            if (id != moviesandGenres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviesandGenres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesandGenresExists(moviesandGenres.Id))
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
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", moviesandGenres.GenreId);
            ViewData["MoviesId"] = new SelectList(_context.Movies, "Id", "Id", moviesandGenres.MoviesId);
            return View(moviesandGenres);
        }

        // GET: MoviesandGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MoviesandGenres == null)
            {
                return NotFound();
            }

            var moviesandGenres = await _context.MoviesandGenres
                .Include(m => m.Genre)
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviesandGenres == null)
            {
                return NotFound();
            }

            return View(moviesandGenres);
        }

        // POST: MoviesandGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MoviesandGenres == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MoviesandGenres'  is null.");
            }
            var moviesandGenres = await _context.MoviesandGenres.FindAsync(id);
            if (moviesandGenres != null)
            {
                _context.MoviesandGenres.Remove(moviesandGenres);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesandGenresExists(int id)
        {
          return (_context.MoviesandGenres?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
