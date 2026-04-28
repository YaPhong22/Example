using Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult ListAll()
        {
            List<Student> ListStudents = new List<Student>()
            {
                new Student { Id = 1, Name = "Đức Đạt", Age = 19, Gender = true, ImgUrl = "", Des = "" },
                new Student { Id = 2, Name = "Thùy Trâm", Age = 25, Gender = false, ImgUrl = "", Des = "" },
                new Student { Id = 3, Name = "Nhã Phương", Age = 23, Gender = false, ImgUrl = "", Des = "" },
                new Student { Id = 4, Name = "Thanh Viên", Age = 20, Gender = true, ImgUrl = "", Des = "" },
                new Student { Id = 5, Name = "Hoàng Việt", Age = 19, Gender = true, ImgUrl = "", Des = "" }
            };

            return View(ListStudents);
        }

        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "Welcome to student page",
                ContentType = "text/plain"
            };
        }

        public string ListOnlyOne()
        {
            return "Liệt kê 1 sinh viên có id cụ thể";
        }

        public string EditStudent()
        {
            return "Chỉnh sửa thông tin 1 sinh viên có id cụ thể";
        }

        public string AddStudent()
        {
            return "Thêm thông tin 1 sinh viên";
        }

        public string DelStudent()
        {
            return "Xóa thông tin 1 sinh viên";
        }

        public IActionResult ListOnlyStudent([FromQuery] int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("Student ID is not provided");
            }

            return Content($"Thong tin sinh vien {id}");
        }
    }
}
