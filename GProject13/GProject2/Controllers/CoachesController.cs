using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GProject2.Data;
using GProject2.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace GProject2.Controllers
{
    [Authorize]
    public class CoachesController : Controller
    {
        private readonly CoachDBContext _context;

        public CoachesController(CoachDBContext context)
        {
            _context = context;
        }

        // GET: Coaches
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coach.ToListAsync());
        }

        // GET: Coaches/Details/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Details(int? id)
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
       

        // GET: Coaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoachId,Email,UserName,DiscordName,About,Social,PaypalAcc,Achivment,Game,Password,Image,Price,ShortDescription,Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,IsCoachConfirmed")] Coach coach, IFormFile Image)
        {

            if (Image != null)
            {
                using (var stream = new MemoryStream())
                {
                    await Image.CopyToAsync(stream);
                    coach.Image = stream.ToArray();
                }
                _context.Add(coach);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(confirmmsg));
            }
            return View(coach);
        }

        public IActionResult confirmmsg()
        {
            return View();
        }

        // GET: Coaches/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coach.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }
            return View(coach);
        }

        // POST: Coaches/Edit/5
        [Authorize(Roles = "Admin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoachId,Email,UserName,DiscordName,About,Social,PaypalAcc,Achivment,Game,Password,Image,Price,ShortDescription,Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,IsCoachConfirmed")] Coach coach, IFormFile Image)
        {
            if (id != coach.CoachId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    if (Image != null)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await Image.CopyToAsync(stream);
                            coach.Image = stream.ToArray();
                        }
                        _context.Update(coach);
                        await _context.SaveChangesAsync();                       
                    }
                    
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachExists(coach.CoachId))
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
            
            return View(coach);
        }
        [Authorize(Roles = "Admin")]

        // GET: Coaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
        [Authorize(Roles = "Admin")]

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coach = await _context.Coach.FindAsync(id);
            _context.Coach.Remove(coach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoachExists(int id)
        {
            return _context.Coach.Any(e => e.CoachId == id);
        }
    }
}
