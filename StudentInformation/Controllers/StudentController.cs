using Microsoft.AspNetCore.Mvc;
using StudentInformation.Models;

namespace StudentInformation.Controllers
{
    public class StudentController : Controller
    {
        // static List to store Student temporarily
        private static List<Student> students = new List<Student>();
        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Pets/Edit/5
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        // POST: /Pets/Edit/id
        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(s => s.Id == id);
                if (existingStudent == null)
                    return NotFound();

                // Update pet details
                existingStudent.FirstName = student.FirstName;
                existingStudent.MiddleName = student.MiddleName;
                existingStudent.LastName = student.LastName;
                existingStudent.ContactNumber = student.ContactNumber;
                existingStudent.Address = student.Address;

                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Pets/Delete/id

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        // POST: /Pets/Delete/id

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            var pet = students.FirstOrDefault(s => s.Id == id);
            if (pet != null)
            {
                students.Remove(pet);
            }
            return RedirectToAction("Index");
        }
    }
}
