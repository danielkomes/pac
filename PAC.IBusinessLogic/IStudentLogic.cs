namespace PAC.IBusinessLogic;
using PAC.Domain;

public interface IStudentLogic
{
    IEnumerable<Student> GetStudents();
    IEnumerable<Student> GetStudentsByAge(int age);
    Student GetStudentById(int id);
    void InsertStudents(Student? student);

}

