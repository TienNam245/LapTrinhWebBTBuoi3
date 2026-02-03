using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {
        // Biến static để lưu danh sách sinh viên đăng ký
        private static List<Student> RegisteredStudents = new List<Student>();

        // Action GET: /Student/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Action POST: /Student/ShowKQ
        [HttpPost]
        public IActionResult ShowKQ(Student student)
        {
            // Thêm sinh viên vào danh sách
            RegisteredStudents.Add(student);

            // Đếm số lượng sinh viên cùng chuyên ngành
            int sameMajorCount = RegisteredStudents
                .Count(s => s.ChuyenNganh == student.ChuyenNganh) - 1; // Trừ chính sinh viên hiện tại

            // Truyền dữ liệu sang View ShowKQ
            ViewBag.MSSV = student.MSSV;
            ViewBag.HoTen = student.HoTen;
            ViewBag.ChuyenNganh = student.ChuyenNganh;
            ViewBag.SameMajorCount = sameMajorCount;

            return View();
        }
    }
}
