using Microsoft.AspNetCore.Mvc;
using WebApiLab1.Models;

namespace WebApiLab1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Ayan", Age = 20 },
            new Student { Id = 2, Name = "Dana", Age = 21 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
            return Ok(student);
        }
    }
}
