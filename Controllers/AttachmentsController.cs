﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SWD_Project.Models;

namespace SWD_Project.Controllers
{
    public class AttachmentsController : Controller
    {
        private readonly Swd392Context _context;

        public AttachmentsController(Swd392Context context)
        {
            _context = context;
        }

        // GET: Attachments
        public async Task<IActionResult> Index()
        {
            var swd392Context = _context.Attachments.Include(a => a.Knowledge);
            return View(await swd392Context.ToListAsync());
        }

        // GET: Attachments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attachments == null)
            {
                return NotFound();
            }

            var attachment = await _context.Attachments
                .Include(a => a.Knowledge)
                .FirstOrDefaultAsync(m => m.AttachmentId == id);
            if (attachment == null)
            {
                return NotFound();
            }

            return View(attachment);
        }

        // GET: Attachments/Create
        public IActionResult Create()
        {
            ViewData["KnowledgeId"] = new SelectList(_context.Knowledges, "KnowledgeId", "KnowledgeId");
            return View();
        }

        // POST: Attachments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttachmentId,KnowledgeId,FileName,Url,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attachment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KnowledgeId"] = new SelectList(_context.Knowledges, "KnowledgeId", "KnowledgeId", attachment.KnowledgeId);
            return View(attachment);
        }

        // GET: Attachments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attachments == null)
            {
                return NotFound();
            }

            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }
            ViewData["KnowledgeId"] = new SelectList(_context.Knowledges, "KnowledgeId", "KnowledgeId", attachment.KnowledgeId);
            return View(attachment);
        }

        // POST: Attachments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttachmentId,KnowledgeId,FileName,Url,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] Attachment attachment)
        {
            if (id != attachment.AttachmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attachment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttachmentExists(attachment.AttachmentId))
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
            ViewData["KnowledgeId"] = new SelectList(_context.Knowledges, "KnowledgeId", "KnowledgeId", attachment.KnowledgeId);
            return View(attachment);
        }

        // GET: Attachments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attachments == null)
            {
                return NotFound();
            }

            var attachment = await _context.Attachments
                .Include(a => a.Knowledge)
                .FirstOrDefaultAsync(m => m.AttachmentId == id);
            if (attachment == null)
            {
                return NotFound();
            }

            return View(attachment);
        }

        // POST: Attachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attachments == null)
            {
                return Problem("Entity set 'Swd392Context.Attachments'  is null.");
            }
            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment != null)
            {
                _context.Attachments.Remove(attachment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttachmentExists(int id)
        {
          return (_context.Attachments?.Any(e => e.AttachmentId == id)).GetValueOrDefault();
        }
    }
}
