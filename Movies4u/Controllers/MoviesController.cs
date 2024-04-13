﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies4u.Data;

namespace Movies4u.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
              return _context.Movies != null ? 
                          View(await _context.Movies.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
        }
        public async Task<IActionResult> ShowSearchForm()
        {
            return _context.Movies != null ?
                        View() :
                        Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
        }
        // GET: Jokes/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return _context.Movies != null ?
                        View("Index", await _context.Movies.Where(x => x.Name.Contains(SearchPhrase)).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
        }
        public async Task<IActionResult> ShowComedyFilms()
        {
            return _context.Movies != null ?
                        View(await _context.Movies.Where(m=>m.Description.Contains("Comedy")).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
        }
        public async Task<IActionResult> ShowDramaFilms()
        {
            return _context.Movies != null ?
                        View(await _context.Movies.Where(m => m.Description.Contains("Drama")).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
        }
        public async Task<IActionResult> ShowActionFilms()
        {
            return _context.Movies != null ?
                        View(await _context.Movies.Where(m => m.Description.Contains("Action")).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
        }
        public async Task<IActionResult> ShowHorrorFilms()
        {
            return _context.Movies != null ?
                        View(await _context.Movies.Where(m => m.Description.Contains("Horror")).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
        }
        public async Task<IActionResult> ShowAdventureFilms()
        {
            return _context.Movies != null ?
                        View(await _context.Movies.Where(x => x.Description.Contains("Adventure")).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
        }


        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rate,Description,Duration,Year,ImageURL")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rate,Description,Duration,Year,ImageURL")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
