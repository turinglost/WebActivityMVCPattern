﻿#nullable disable
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
    public class ActivityModelsController : Controller
    {
        private readonly WebActivityMVCPatternContext _context;

        public ActivityModelsController(WebActivityMVCPatternContext context)
        {
            _context = context;
        }

        // GET: ActivityModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityModel.ToListAsync());
        }

        // GET: ActivityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityModel == null)
            {
                return NotFound();
            }

            return View(activityModel);
        }

        // GET: ActivityModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActivityStarted,ActivityDurationMinutes,ActivityType,ActivityComments")] ActivityModel activityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityModel);
        }

        // GET: ActivityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityModel.FindAsync(id);
            if (activityModel == null)
            {
                return NotFound();
            }
            return View(activityModel);
        }

        // POST: ActivityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActivityStarted,ActivityDurationMinutes,ActivityType,ActivityComments")] ActivityModel activityModel)
        {
            if (id != activityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityModelExists(activityModel.Id))
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
            return View(activityModel);
        }

        // GET: ActivityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityModel == null)
            {
                return NotFound();
            }

            return View(activityModel);
        }

        // POST: ActivityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityModel = await _context.ActivityModel.FindAsync(id);
            _context.ActivityModel.Remove(activityModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityModelExists(int id)
        {
            return _context.ActivityModel.Any(e => e.Id == id);
        }
    }
}
