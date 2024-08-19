using KilimoWebApp.Common;
using KilimoWebApp.Modules.Students.Model;

namespace KilimoWebApp.Modules.Students.Service;

public interface IStudentService
{
    ResponseBody CreateStudentAsync(StudentDto studentDto);
    ResponseBody GetAllStudents();
    ResponseBody GetStudentById(string id);
    ResponseBody GetStudentByStream(string name);
    ResponseBody DeleteStudentById(string id);
    ResponseBody UpdateStudentById(StudentDto studentDto);
}