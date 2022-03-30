using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentProjectTest.Models;

namespace StudentProjectTest.Services
{
    public class StudentService
    {
        private readonly school3Context context;
        public StudentService(school3Context context)
        {
            this.context = context;
        }
        public IEnumerable<Student>GetAllStudent()

        {
            return context.Students.Include(Student => Student.Subjects).Include(Student => Student.Grades).ToList();
        }

        public Student GetStudentDataByEmail(string email)
        {
            return context.Students.Include(s => s.Subjects).Include(Student => Student.Grades).First(s => s.Email == email);
        }

        public IEnumerable<Grade> GetStudentGradesById(int id)
        {
            return context.Grades.Where(x => x.StudentId == id ).ToList();
        }
    }
}
