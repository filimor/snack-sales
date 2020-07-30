using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnackSales.Context;
using SnackSales.Models;

namespace SnackSales.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SnacksController : Controller
    {
        private readonly AppDbContext _context;

        public SnacksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Snacks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Snacks.Include(s => s.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Snacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // GET: Admin/Snacks/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: Admin/Snacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,ShortDescription,LongDescription,Price,ImageUrl,ThumbnailUrl,Favorite,InStock,CategoryId")]
            Snack snack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", snack.CategoryId);
            return View(snack);
        }

        // GET: Admin/Snacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks.FindAsync(id);
            if (snack == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", snack.CategoryId);
            return View(snack);
        }

        // POST: Admin/Snacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Name,ShortDescription,LongDescription,Price,ImageUrl,ThumbnailUrl,Favorite,InStock,CategoryId")]
            Snack snack)
        {
            if (id != snack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnackExists(snack.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", snack.CategoryId);
            return View(snack);
        }

        // GET: Admin/Snacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // POST: Admin/Snacks/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snack = await _context.Snacks.FindAsync(id);
            _context.Snacks.Remove(snack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnackExists(int id)
        {
            return _context.Snacks.Any(e => e.Id == id);
        }
    }
}