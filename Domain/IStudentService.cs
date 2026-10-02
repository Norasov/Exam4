namespace Domain;

public interface IStudentService
{
    void AddStudent(Student student);
    void DisplayStudents();
    void UpdateStudent(Student student);
    void DeleteStudent(int id);
    Student? SearchByName(string fullName);
    List<Student> SearchByGroup(string group);
}
