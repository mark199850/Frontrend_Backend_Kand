using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentProjectTest.Models;
using StudentProjectTest.Services;

namespace StudentProjectTest.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentService studentService;

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<Student> GetAllStudent()
        {
            return studentService.GetAllStudent();
        }

        [HttpGet]
        [Route("Email/{email}")]

        public Student GetAllStudent(string email)
        {
            return studentService.GetStudentDataByEmail(email);
        }

        [HttpGet]
        [Route("{id}")]
        public IEnumerable<Grade> GetStudentGrades(int id)
        {
            return studentService.GetStudentGradesById(id);
        }

    }
}
