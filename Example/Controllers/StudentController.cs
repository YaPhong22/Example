using Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    public class StudentController : Controller
    {

        private static List<Student> listStudents = new List<Student>()
        {
            new Student { Id = 1, Name = "Đức Đạt", Age = 19, Gender = true, ImgUrl = "https://bestflashcard.com/images/vocabulary/english/sgk-tieng-anh-lop-4-unit-6/study.PNG", Des = "Mô tả thông tin sinh viên" },
            new Student { Id = 2, Name = "Thùy Trâm", Age = 25, Gender = false, ImgUrl = "https://cdn.vungoi.vn/vungoi/2021/1224/1640339805116_104.png", Des = "Mô tả thông tin sinh viên" },
            new Student { Id = 3, Name = "Nhã Phương", Age = 23, Gender = false, ImgUrl = "https://cdn.vungoi.vn/vungoi/2021/1224/1640339805116_104.png", Des = "Mô tả thông tin sinh viên" },
            new Student { Id = 4, Name = "Thanh Viễn", Age = 20, Gender = true, ImgUrl = "https://bestflashcard.com/images/vocabulary/english/sgk-tieng-anh-lop-4-unit-6/study.PNG", Des = "Mô tả thông tin sinh viên" },
            new Student { Id = 5, Name = "Hoàng Việt", Age = 19, Gender = true, ImgUrl = "https://bestflashcard.com/images/vocabulary/english/sgk-tieng-anh-lop-4-unit-6/study.PNG", Des = "Mô tả thông tin sinh viên" }
        };

        public IActionResult ListAll()
        {
            return View(listStudents);
        }

       
        public IActionResult ListOnlyStudent(int id)
        {
    
            var student = listStudents.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }


            return View(student);
        }

 
        public IActionResult EditStudent(int id)
        {

            var student = listStudents.FirstOrDefault(s => s.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }


        [HttpPost]
        public IActionResult EditStudent(Student sv)
        {
            Student oldstudent = listStudents.FirstOrDefault(x => x.Id == sv.Id);

            if(oldstudent == null)
            {
                return NotFound();
            }

            oldstudent.Name = sv.Name;
            oldstudent.Age = sv.Age;
            oldstudent.Gender = sv.Gender;
            oldstudent.ImgUrl = sv.ImgUrl;

            return RedirectToAction("ListAll");
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Student sv)
        {
            if (ModelState.IsValid)
            {

                sv.Id = listStudents.Any() ? listStudents.Max(s => s.Id) + 1 : 1;

                listStudents.Add(sv);

                return RedirectToAction("ListAll");
            }
            return View(sv); 
        }


        public IActionResult DelStudent(int id)
        {
            var student = listStudents.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                listStudents.Remove(student);
            }
            return RedirectToAction("ListAll");
        }
    }
}