using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCTestApp.Data;

namespace MVCTestApp.Controllers
{
    public class ConstructionStaffsController : Controller
    {
        private readonly ConstructionDbContext _context;

        public ConstructionStaffsController(ConstructionDbContext context)
        {
            _context = context;
        }

        // GET: ConstructionStaffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConstructionStaffs.ToListAsync());
        }

        // GET: ConstructionStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructionStaff = await _context.ConstructionStaffs
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (constructionStaff == null)
            {
                return NotFound();
            }

            return View(constructionStaff);
        }

        // GET: ConstructionStaffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConstructionStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,FirstName,LastName,JobTitle,EmploymentStatus,DateOfHire")] ConstructionStaff constructionStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(constructionStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(constructionStaff);
        }

        // GET: ConstructionStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructionStaff = await _context.ConstructionStaffs.FindAsync(id);
            if (constructionStaff == null)
            {
                return NotFound();
            }
            return View(constructionStaff);
        }

        // POST: ConstructionStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,FirstName,LastName,JobTitle,EmploymentStatus,DateOfHire")] ConstructionStaff constructionStaff)
        {
            if (id != constructionStaff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(constructionStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConstructionStaffExists(constructionStaff.StaffId))
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
            return View(constructionStaff);
        }

        // GET: ConstructionStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructionStaff = await _context.ConstructionStaffs
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (constructionStaff == null)
            {
                return NotFound();
            }

            return View(constructionStaff);
        }

        // POST: ConstructionStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var constructionStaff = await _context.ConstructionStaffs.FindAsync(id);
            if (constructionStaff != null)
            {
                _context.ConstructionStaffs.Remove(constructionStaff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConstructionStaffExists(int id)
        {
            return _context.ConstructionStaffs.Any(e => e.StaffId == id);
        }
    }
}
