using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBookWebApp.Data;
using MyBookWebApp.Models;

namespace MyBookWebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly MyBookWebAppContext _context;

        public BooksController(MyBookWebAppContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books
                .AsNoTracking()
                .Include(book => book.Language)
                .Include(book => book.Author)
                .ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.AsNoTracking()
                .Include(book => book.Language)
                .Include(book => book.Author)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.Languages = new SelectList(_context.Languages.AsNoTracking(), "ID", nameof(Language.Name));
            ViewBag.Authors = new SelectList(_context.Authors.AsNoTracking(), "ID", nameof(Author.Name));
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,AuthorID,LanguageID")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Languages = new SelectList(_context.Languages.AsNoTracking(), "ID", nameof(Language.Name), book.LanguageID);
            ViewBag.Authors = new SelectList(_context.Authors.AsNoTracking(), "ID", nameof(Author.Name), book.AuthorID);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.ID == id);

            if (book == null)
            {
                return NotFound();
            }

            ViewBag.Languages = new SelectList(_context.Languages.AsNoTracking(), "ID", nameof(Language.Name), book.LanguageID);
            ViewBag.Authors = new SelectList(_context.Authors.AsNoTracking(), "ID", nameof(Author.Name), book.AuthorID);

            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,AuthorID,LanguageID")] Book book)
        {
            if (book.ID != id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.ID))
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

            ViewBag.Languages = new SelectList(_context.Languages.AsNoTracking(), "ID", nameof(Language.Name), book.LanguageID);
            ViewBag.Authors = new SelectList(_context.Authors.AsNoTracking(), "ID", nameof(Author.Name), book.AuthorID);

            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.AsNoTracking().FirstAsync(item => item.ID == id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ID == id);
        }
    }
}
