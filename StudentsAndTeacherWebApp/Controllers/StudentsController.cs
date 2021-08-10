using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentsAndTeacherWebApp.Models.Model;

namespace StudentsAndTeacherWebApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UniversityDbContext _context;

        public StudentsController(UniversityDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var universityDbContext = _context.Student.Include(s => s.Teacher);
            return View(await universityDbContext.ToListAsync());
            //return View(await _context.Student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            //ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Id");
            ViewData["Teachers"] = new SelectList(_context.Set<Teacher>(), "Id", "Name");
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,TeacherId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Teachers"] = new SelectList(_context.Set<Teacher>(), "Id", "Name", student.Teacher);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Id", student.TeacherId);
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,TeacherId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Id", student.TeacherId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
