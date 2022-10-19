using GProject2.Areas.Identity.Data;
using GProject2.Data;
using GProject2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GProject2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly CoachDBContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CoachDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Games()
        {
            return View();
        }

        public async Task<IActionResult> lolAsync()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> ApexAsync()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> R6Async()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> FifaAsync()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> PubgAsync()
        {
            return View(await _context.Coach.ToListAsync()); ;
        }
        public async Task<IActionResult> ValorantAsync()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> FortniteAsync()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> ClashAsync()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> OverwatchAsync()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> DotaAsync()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> HearthAsync()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> ThedivisionAsync()
        {
            return View(await _context.Coach.ToListAsync());
        }
        public async Task<IActionResult> CoachPageAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coach
                .FirstOrDefaultAsync(m => m.CoachId == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }
        ApplicationUser reterive = new ApplicationUser();
        public IActionResult Coach()
        {
            
            return View(reterive);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
