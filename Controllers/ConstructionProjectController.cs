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
    public class ConstructionProjectController : Controller
    {
        private readonly ConstructionDbContext _context;

        public ConstructionProjectController(ConstructionDbContext context)
        {
            _context = context;
        }

        // GET: ConstructionProject
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConstructionProjects.ToListAsync());
        }

        // GET: ConstructionProject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructionProject = await _context.ConstructionProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (constructionProject == null)
            {
                return NotFound();
            }

            return View(constructionProject);
        }

        // GET: ConstructionProject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConstructionProject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,ProjectDetails,ProjectLocation,ProjectStatus,ProjectDateCompletion")] ConstructionProject constructionProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(constructionProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(constructionProject);
        }

        // GET: ConstructionProject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructionProject = await _context.ConstructionProjects.FindAsync(id);
            if (constructionProject == null)
            {
                return NotFound();
            }
            return View(constructionProject);
        }

        // POST: ConstructionProject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,ProjectDetails,ProjectLocation,ProjectStatus,ProjectDateCompletion")] ConstructionProject constructionProject)
        {
            if (id != constructionProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(constructionProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConstructionProjectExists(constructionProject.Id))
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
            return View(constructionProject);
        }

        // GET: ConstructionProject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructionProject = await _context.ConstructionProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (constructionProject == null)
            {
                return NotFound();
            }

            return View(constructionProject);
        }

        // POST: ConstructionProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var constructionProject = await _context.ConstructionProjects.FindAsync(id);
            if (constructionProject != null)
            {
                _context.ConstructionProjects.Remove(constructionProject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConstructionProjectExists(int id)
        {
            return _context.ConstructionProjects.Any(e => e.Id == id);
        }
    }
}
