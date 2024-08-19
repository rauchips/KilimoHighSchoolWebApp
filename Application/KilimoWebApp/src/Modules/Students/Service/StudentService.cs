using KilimoWebApp.Common;
using KilimoWebApp.Modules.Streams.Repository;
using KilimoWebApp.Modules.Students.Model;
using KilimoWebApp.Modules.Students.Repository;

namespace KilimoWebApp.Modules.Students.Service;

public class StudentService(IStudentRepository studentRepository, IStreamRepository streamRepository) : IStudentService
{
    public ResponseBody CreateStudentAsync(StudentDto studentDto)
    {
        var student = studentRepository.GetStudentById(studentDto.RegistrationId);

        if (student != null)
        {
            return new ResponseBody(400, "Student already exists.", null);
        }

        var stream = streamRepository.GetStreamByName(studentDto.StreamName);

        var studentEntity = new StudentEntity()
        {
            FirstName = studentDto.FirstName,
            MiddleName = studentDto.MiddleName,
            LastName = studentDto.LastName,
            Age = studentDto.Age,
            RegistrationNumber = studentDto.RegistrationId,
            StreamId = stream.Id
        };

        studentRepository.CreateStudentAsync(studentEntity);

        return new ResponseBody(200, "New student record has been created.", studentEntity);
    }

    public ResponseBody GetAllStudents()
    {
        var students = studentRepository.GetAllStudents();

        if (students is null)
        {
            return new ResponseBody(400, "No student record was found.", null);
        }

        return new ResponseBody(200, "List of students found.", students);
    }

    public ResponseBody GetStudentById(string id)
    {
        var student = studentRepository.GetStudentById(id);

        if (student is null)
        {
            return new ResponseBody(400, "No student record was found", null);
        }

        return new ResponseBody(200, "Student record found.", student);
    }

    public ResponseBody GetStudentByStream(string name)
    {
        var stream = streamRepository.GetStreamByName(name);

        if (stream is null)
        {
            return new ResponseBody(400, "Invalid stream was used.", null);
        }

        var students = studentRepository.GetStudentByStream(stream.Id);

        if (students is null)
        {
            return new ResponseBody(400, "No student record was found.", null);
        }

        return new ResponseBody(200, "List of students found.", students);
    }

    public ResponseBody DeleteStudentById(string id)
    {
        var checkStudentExists = studentRepository.GetStudentById(id);

        if (checkStudentExists is null)
        {
            return new ResponseBody(400, "No student record was found.", null);
        }

        studentRepository.DeleteStudentById(id);

        return new ResponseBody(200, "Student record has been deleted successfully.", checkStudentExists);
    }

    public ResponseBody UpdateStudentById(StudentDto studentDto)
    {
        var checkStudentExists = studentRepository.GetStudentById(studentDto.RegistrationId);

        if (checkStudentExists is null)
        {
            return new ResponseBody(400, "No student record was found.", null);
        }

        var stream = streamRepository.GetStreamByName(studentDto.StreamName);

        if (stream is null)
        {
            return new ResponseBody(400, "Invalid stream was used.", null);
        }

        checkStudentExists.FirstName = studentDto.FirstName;
        checkStudentExists.MiddleName = studentDto.MiddleName;
        checkStudentExists.LastName = studentDto.LastName;
        checkStudentExists.Age = studentDto.Age;
        checkStudentExists.RegistrationNumber = studentDto.RegistrationId;
        checkStudentExists.StreamId = stream.Id;

        studentRepository.UpdateStudentById(checkStudentExists);

        return new ResponseBody(200, "Student record has been updated successfully.", checkStudentExists);
    }
}