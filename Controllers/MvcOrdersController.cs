using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PPizza.Data;
using PPizza.Models;

namespace PPizza.Controllers
{
    public class MvcOrdersController : Controller
    {
        private readonly MvcOrderContext _context;

        public MvcOrdersController(MvcOrderContext context)
        {
            _context = context;
        }

        // GET: MvcOrders
         
       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order.ToListAsync());
        }
        public async Task<IActionResult> ThanksOrder()
        {
            return View(await _context.Order.ToListAsync());
        }

        // GET: MvcOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcOrder = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mvcOrder == null)
            {
                return NotFound();
            }

            return View(mvcOrder);
        }

        // GET: MvcOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MvcOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,address,pizza")] MvcOrder mvcOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mvcOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ThanksOrder));
            }
            return View(mvcOrder);
        }

        // GET: MvcOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcOrder = await _context.Order.FindAsync(id);
            if (mvcOrder == null)
            {
                return NotFound();
            }
            return View(mvcOrder);
        }

        // POST: MvcOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,address,pizza")] MvcOrder mvcOrder)
        {
            if (id != mvcOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mvcOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MvcOrderExists(mvcOrder.Id))
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
            return View(mvcOrder);
        }

        // GET: MvcOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcOrder = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mvcOrder == null)
            {
                return NotFound();
            }

            return View(mvcOrder);
        }

        // POST: MvcOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mvcOrder = await _context.Order.FindAsync(id);
            _context.Order.Remove(mvcOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MvcOrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
