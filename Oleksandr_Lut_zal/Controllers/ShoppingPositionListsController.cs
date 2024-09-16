using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oleksandr_Lut_zal.Data;
using Oleksandr_Lut_zal.Models;

namespace Oleksandr_Lut_zal.Controllers
{
    public class ShoppingPositionListsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public ShoppingPositionListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingPositionLists
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var shoppingLists = await _context.ShoppingPositionList.Where(item => item.ownerId == userId).ToListAsync();
            return View(shoppingLists);
        }

        // GET: ShoppingPositionLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingPositionList = await _context.ShoppingPositionList
                .FirstOrDefaultAsync(m => m.id == id);
            if (shoppingPositionList == null)
            {
                return NotFound();
            }

            return View(shoppingPositionList);
        }

        // GET: ShoppingPositionLists/Create
        public IActionResult Create()
        {
            var model = new ShoppingPositionList
            {
                PlannedDate = DateTime.Now
            };
            return View(model);
        }

        // POST: ShoppingPositionLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,listTitle")] ShoppingPositionList shoppingPositionList)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            shoppingPositionList.ownerId = userId;

            _context.Add(shoppingPositionList);
            await _context.SaveChangesAsync();

            return View(shoppingPositionList);
        }

        // GET: ShoppingPositionLists/Edit/5
        [Authorize(Policy = "IsOwner")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var shoppingPositionList = await _context.ShoppingPositionList.FindAsync(id);
            var authResult = await _authorizationService.AuthorizeAsync(User, shoppingPositionList, "IsOwner");

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            if (shoppingPositionList == null)
            {
                return NotFound();
            }

            return View(shoppingPositionList);
        }

        // POST: ShoppingPositionLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,listTitle")] ShoppingPositionList shoppingPositionList)
        {
            if (id != shoppingPositionList.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingPositionList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingPositionListExists(shoppingPositionList.id))
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
            return View(shoppingPositionList);
        }

        // GET: ShoppingPositionLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingPositionList = await _context.ShoppingPositionList
                .FirstOrDefaultAsync(m => m.id == id);
            if (shoppingPositionList == null)
            {
                return NotFound();
            }

            return View(shoppingPositionList);
        }

        // POST: ShoppingPositionLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingPositionList = await _context.ShoppingPositionList.FindAsync(id);
            if (shoppingPositionList != null)
            {
                _context.ShoppingPositionList.Remove(shoppingPositionList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingPositionListExists(int id)
        {
            return _context.ShoppingPositionList.Any(e => e.id == id);
        }
    }
}
