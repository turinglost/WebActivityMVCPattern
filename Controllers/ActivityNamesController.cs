#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebActivityMVCPattern.Data;
using WebActivityMVCPattern.Models;

namespace WebActivityMVCPattern.Controllers
{
    public class ActivityNamesController : Controller
    {
        private readonly WebActivityMVCPatternContext _context;

        public ActivityNamesController(WebActivityMVCPatternContext context)
        {
            _context = context;
        }

        // GET: ActivityNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityName.ToListAsync());
        }

        // GET: ActivityNames/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityName = await _context.ActivityName
                .FirstOrDefaultAsync(m => m.Name == id);
            if (activityName == null)
            {
                return NotFound();
            }

            return View(activityName);
        }

        // GET: ActivityNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivityNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] ActivityName activityName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityName);
        }

        // GET: ActivityNames/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityName = await _context.ActivityName.FindAsync(id);
            if (activityName == null)
            {
                return NotFound();
            }
            return View(activityName);
        }

        // POST: ActivityNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name")] ActivityName activityName)
        {
            if (id != activityName.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityNameExists(activityName.Name))
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
            return View(activityName);
        }

        // GET: ActivityNames/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityName = await _context.ActivityName
                .FirstOrDefaultAsync(m => m.Name == id);
            if (activityName == null)
            {
                return NotFound();
            }

            return View(activityName);
        }

        // POST: ActivityNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var activityName = await _context.ActivityName.FindAsync(id);
            _context.ActivityName.Remove(activityName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityNameExists(string id)
        {
            return _context.ActivityName.Any(e => e.Name == id);
        }
    }
}
