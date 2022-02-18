using Microsoft.AspNetCore.Mvc;
using WebActivityMVCPattern.Data;
using WebActivityMVCPattern.Models;

namespace WebActivityMVCPattern.Controllers
{
    public class ActivityHomeController : Controller
    {
        private readonly WebActivityMVCPatternContext _context;

        public ActivityHomeController(WebActivityMVCPatternContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ActivityTrackerModel model = new ActivityTrackerModel();
            model.LastActivity = _context.ActivityModel.OrderByDescending(m => m.ActivityStarted)
                .First<ActivityModel>();
            model.ActivityCount = _context.ActivityModel.Count();
            model.ActivityTypes = _context.ActivityName.Select(n => n.Name.Trim()).ToList<string>();

            return View(model);
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
        public async Task<IActionResult> Create([Bind("CurrentActivity")] ActivityTrackerModel activityModel)
        {
            activityModel.CurrentActivity.ActivityComments = string.Empty;
            _context.Add(activityModel.CurrentActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            return View(activityModel);
        }
    }
}
