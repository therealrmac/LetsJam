using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LetsJam.Data;
using LetsJam.Models;
using Microsoft.AspNetCore.Identity;
using LetsJam.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace LetsJam.Controllers
{
    public class StatusUpdatesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StatusUpdatesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: StatusUpdates
        public async Task<IActionResult> Index()
        {
            var messageVM = new MessageViewModel();

            var currentuser = await GetCurrentUserAsync();

            messageVM.updates = await _context.StatusUpdates.Include(m => m.message).Include(u => u.user).Where(x => x.user == currentuser).ToListAsync();

            return View(messageVM);
        }

        // GET: StatusUpdates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusUpdates = await _context.StatusUpdates
                .SingleOrDefaultAsync(m => m.updateId == id);
            if (statusUpdates == null)
            {
                return NotFound();
            }

            return View(statusUpdates);
        }

        // GET: StatusUpdates/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var currentUser = await GetCurrentUserAsync();
            var status = new StatusUpdates();
            status.user = currentUser;

            var message = await _context.StatusUpdates.Where(u => u.user == status.user).ToListAsync();


            return View(status);
        }

        // POST: StatusUpdates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create( StatusUpdates statusUpdates)
        {
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                statusUpdates.user = user;
                _context.Add(statusUpdates);
                await _context.SaveChangesAsync();
                return RedirectToAction("Manage");
            }
            return View(statusUpdates);
        }

        // GET: StatusUpdates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusUpdates = await _context.StatusUpdates.SingleOrDefaultAsync(m => m.updateId == id);
            if (statusUpdates == null)
            {
                return NotFound();
            }
            return View(statusUpdates);
        }

        // POST: StatusUpdates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("updateId,message,created")] StatusUpdates statusUpdates)
        {
            if (id != statusUpdates.updateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusUpdates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusUpdatesExists(statusUpdates.updateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(statusUpdates);
        }

        // GET: StatusUpdates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusUpdates = await _context.StatusUpdates
                .SingleOrDefaultAsync(m => m.updateId == id);
            if (statusUpdates == null)
            {
                return NotFound();
            }

            return View(statusUpdates);
        }

        // POST: StatusUpdates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusUpdates = await _context.StatusUpdates.SingleOrDefaultAsync(m => m.updateId == id);
            _context.StatusUpdates.Remove(statusUpdates);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StatusUpdatesExists(int id)
        {
            return _context.StatusUpdates.Any(e => e.updateId == id);
        }
    }
}
