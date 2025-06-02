using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInformation.Models;

namespace StudentInformation.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDB _context;

        public StudentController(StudentDB context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _context.Student.ToListAsync();
            return View(students);
        }

        public IActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                
                _context.Student.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Pets/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        // POST: /Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Student.Any(s => s.Id == id))
                        return NotFound();
                    else
                        throw;
                }
            }
            return View(student);
        }

        // GET: /Student/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
                return NotFound();

            return View(student); // Shows confirmation page
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
