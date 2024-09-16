using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oleksandr_Lut_zal.Data;
using Oleksandr_Lut_zal.Models;

namespace Oleksandr_Lut_zal.Controllers
{
    public class ShopingPositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopingPositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShopingPositions
        public async Task<IActionResult> Index()
        {
            var shoppingLists = await _context.ShopingPositions.ToListAsync();
            return View(shoppingLists);
        }

        // GET: ShopingPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopingPosition = await _context.ShopingPositions
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopingPosition == null)
            {
                return NotFound();
            }

            return View(shopingPosition);
        }

        // GET: ShopingPositions/Create
        public IActionResult Create()
        {
            var shoppingLists = _context.ShoppingPositionList.ToList();
            ViewBag.ShoopingLists = new SelectList(shoppingLists, "id", "listTitle");
            return View();
        }

        // POST: ShopingPositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,description,isDrawOut,ShoopingListId")] ShopingPosition shopingPosition)
        {

            _context.Add(shopingPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            return View(shopingPosition);
        }

        // GET: ShopingPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopingPosition = await _context.ShopingPositions.FindAsync(id);
            if (shopingPosition == null)
            {
                return NotFound();
            }
            return View(shopingPosition);
        }

        // POST: ShopingPositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,description,isDrawOut")] ShopingPosition shopingPosition)
        {
            if (id != shopingPosition.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopingPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopingPositionExists(shopingPosition.id))
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
            return View(shopingPosition);
        }

        // GET: ShopingPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopingPosition = await _context.ShopingPositions
                .FirstOrDefaultAsync(m => m.id == id);
            if (shopingPosition == null)
            {
                return NotFound();
            }

            return View(shopingPosition);
        }

        // POST: ShopingPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopingPosition = await _context.ShopingPositions.FindAsync(id);
            if (shopingPosition != null)
            {
                _context.ShopingPositions.Remove(shopingPosition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopingPositionExists(int id)
        {
            return _context.ShopingPositions.Any(e => e.id == id);
        }
    }
}
