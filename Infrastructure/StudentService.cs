using Domain;

namespace Infrastructure;

public class StudentService : IStudentService
{
    private List<Student> students = [];
    public void AddStudent(Student student)
    {
        if (students.Any(s => s.Id == student.Id))
        {
            System.Console.WriteLine("Студент  с таким id уже есть");
        }
        else if (student.Age <= 18)
        {
            System.Console.WriteLine("Студент должен быть старше 18");
        }
        else
        {
            students.Add(student);
        }
    }

    public void DeleteStudent(int id)
    {
        Student? student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            System.Console.WriteLine("Студент не найден!");
        }
        else
        {
            students.Remove(student);
        }
    }

    public void DisplayStudents()
    {
        if (students.Count == 0)
        {
            System.Console.WriteLine("Список пуст");
        }
        else
        {

            foreach (var item in students)
            {
                System.Console.WriteLine($@"Id: {item.Id}
FullName: {item.FullName}
Age: {item.Age}
Group: {item.Group}");
            }
        }
    }

    public List<Student> SearchByGroup(string group)
    {
        List<Student> r = [];

        foreach (Student item in students)
        {
            if (item.Group == group)
            {
                r.Add(item);
            }
        }

        if (r.Count == 0)
        {
            System.Console.WriteLine("Студенты не найдены!");
        }

        return r;
    }

    public Student? SearchByName(string fullName)
    {
        Student? s = students.Find(x => x.FullName == fullName);
        if (s == null) System.Console.WriteLine("Студент не найден");
        return s;
    }

    public void UpdateStudent(Student student)
    {
        Student? s = students.Find(x => x.Id == student.Id);
        if (s == null)
        {
            System.Console.WriteLine("Студент не найден или он младше 18 лет");
        }
        else if (student.Age <= 18)
        {
            System.Console.WriteLine("Студент должен быть старше 18 лет");
        }
        else
        {
            s.FullName = student.FullName;
            s.Age = student.Age;
            s.Group = student.Group;
        }
    }
}
