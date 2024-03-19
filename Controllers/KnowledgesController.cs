using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SWD_Project.Models;

namespace SWD_Project.Controllers
{
    public class KnowledgesController : Controller
    {
        private readonly Swd392Context _context;

        public KnowledgesController(Swd392Context context)
        {
            _context = context;
        }

        // GET: Knowledges
        public async Task<IActionResult> Index()
        {
            var swd392Context = _context.Knowledges.Include(k => k.Team);
            return View(await swd392Context.ToListAsync());
        }

        // GET: Knowledges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Knowledges == null)
            {
                return NotFound();
            }

            var knowledge = await _context.Knowledges
                .Include(k => k.Team)
                .FirstOrDefaultAsync(m => m.KnowledgeId == id);
            if (knowledge == null)
            {
                return NotFound();
            }

            return View(knowledge);
        }

        // GET: Knowledges/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId");
            return View();
        }

        // POST: Knowledges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KnowledgeId,Title,Content,Status,TeamId,TimeLearning,Visibility,CreateBy,UpdateBy,CreatedDate,UpdatedDate")] Knowledge knowledge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knowledge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", knowledge.TeamId);
            return View(knowledge);
        }

        // GET: Knowledges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Knowledges == null)
            {
                return NotFound();
            }

            var knowledge = await _context.Knowledges.FindAsync(id);
            if (knowledge == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", knowledge.TeamId);
            return View(knowledge);
        }

        // POST: Knowledges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KnowledgeId,Title,Content,Status,TeamId,TimeLearning,Visibility,CreateBy,UpdateBy,CreatedDate,UpdatedDate")] Knowledge knowledge)
        {
            if (id != knowledge.KnowledgeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knowledge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnowledgeExists(knowledge.KnowledgeId))
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
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", knowledge.TeamId);
            return View(knowledge);
        }

        // GET: Knowledges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Knowledges == null)
            {
                return NotFound();
            }

            var knowledge = await _context.Knowledges
                .Include(k => k.Team)
                .FirstOrDefaultAsync(m => m.KnowledgeId == id);
            if (knowledge == null)
            {
                return NotFound();
            }

            return View(knowledge);
        }

        // POST: Knowledges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Knowledges == null)
            {
                return Problem("Entity set 'Swd392Context.Knowledges'  is null.");
            }
            var knowledge = await _context.Knowledges.FindAsync(id);
            if (knowledge != null)
            {
                _context.Knowledges.Remove(knowledge);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnowledgeExists(int id)
        {
          return (_context.Knowledges?.Any(e => e.KnowledgeId == id)).GetValueOrDefault();
        }
    }
}
