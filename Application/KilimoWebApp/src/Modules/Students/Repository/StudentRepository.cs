using KilimoWebApp.Common;
using KilimoWebApp.Modules.Students.Model;
using Microsoft.EntityFrameworkCore;

namespace KilimoWebApp.Modules.Students.Repository;

public class StudentRepository(KilimoContext kilimoContext) : IStudentRepository
{
    public void CreateStudentAsync(StudentEntity? studentEntity)
    {
        kilimoContext.Students.Add(studentEntity);
        kilimoContext.SaveChanges();
    }

    public List<StudentEntity?> GetAllStudents()
    {
        return kilimoContext.Students.AsNoTracking().ToList();
    }

    public StudentEntity? GetStudentById(string id)
    {
        return kilimoContext.Students.FirstOrDefault(student => student != null && student.RegistrationNumber.Equals(id));
    }

    public List<StudentEntity?> GetStudentByStream(Guid id)
    {
        return kilimoContext.Students.Where(student => student != null && student.StreamId.Equals(id)).ToList();
    }

    public void UpdateStudentById(StudentEntity studentEntity)
    {
        kilimoContext.Students.Update(studentEntity);
        kilimoContext.SaveChanges();
    }

    public void DeleteStudentById(string id)
    {
        var studentEntity = GetStudentById(id);
        kilimoContext.Students.Remove(studentEntity);
        kilimoContext.SaveChanges();
    }
}