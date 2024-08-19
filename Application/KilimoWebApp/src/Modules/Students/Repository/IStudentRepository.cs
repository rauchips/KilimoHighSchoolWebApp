using KilimoWebApp.Modules.Students.Model;

namespace KilimoWebApp.Modules.Students.Repository;

public interface IStudentRepository
{
    void CreateStudentAsync(StudentEntity? studentEntity);
    List<StudentEntity?> GetAllStudents();
    StudentEntity? GetStudentById(string id);
    List<StudentEntity?> GetStudentByStream(Guid id);
    void UpdateStudentById(StudentEntity studentEntity);
    void DeleteStudentById(string id);
}