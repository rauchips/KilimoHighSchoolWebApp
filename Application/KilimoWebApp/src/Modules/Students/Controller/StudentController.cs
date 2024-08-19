using KilimoWebApp.Common;
using KilimoWebApp.Modules.Students.Model;
using KilimoWebApp.Modules.Students.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KilimoWebApp.Modules.Students;

[ApiController]
[Route("api/student")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    [HttpPost("register")]
    public ActionResult<ResponseBody> RegisterUser(StudentDto studentDto)
    {
        var student =  studentService.CreateStudentAsync(studentDto);

        return Ok(student);
    }

    [HttpGet("all")]
    public ActionResult<ResponseBody> GetAllStudents()
    {
        var students = studentService.GetAllStudents();

        if (students.status.Equals(200))
        {
            return Ok(students);
        }
        else
        {
            return BadRequest(students);
        }
    }

    [HttpGet("all/stream")]
    public ActionResult<ResponseBody> GetAllStudentByStream(string id)
    {
        var student = studentService.GetStudentByStream(id);

        if (student.status.Equals(200))
        {
            return Ok(student);
        }
        else
        {
            return BadRequest(student);
        }
    }

    [HttpGet("one")]
    public ActionResult<ResponseBody> GetOneStudent(string id)
    {
        var student = studentService.GetStudentById(id);

        if (student.status.Equals(200))
        {
            return Ok(student);
        }
        else
        {
            return BadRequest(student);
        }
    }

    [HttpDelete("delete")]
    public ActionResult<ResponseBody> DeleteStudent(string id)
    {
        var student = studentService.DeleteStudentById(id);

        if (student.status.Equals(200))
        {
            return Ok(student);
        }
        else
        {
            return BadRequest(student);
        }
    }

    [HttpPut("update")]
    public ActionResult<ResponseBody> UpdateStudent(StudentDto studentDto)
    {
        var student = studentService.UpdateStudentById(studentDto);

        if (student.status.Equals(200))
        {
            return Ok(student);
        }
        else
        {
            return BadRequest(student);
        }

    }
}