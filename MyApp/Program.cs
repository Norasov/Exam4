/* 1
Наследование - это принцип ООП(объектно-ориентированное -программирование) при котором один класс(дочерний) 
получает поля свойство и методы  другого класса(родительский) и с помощью символа ":" мы можем передать все 
поля свойства и методы базового класса дочернему классу.
Полиморфизм отличается лишь тем что мы можем переопределять методы базово класса в дочерних классах с помощью 
virtual и override  
*/

/* 2
Отличие виртуального метода от абстрактного в том что в базовом классе мы можем добавить какую-нибудь логику
а потом переопределять их в дочерних классах если нужно еще отличие в том что виртуальные методы не обязательно
реализовывать в дочерних классах а у абстрактных методов в базовом классе нет тела и дочерний класс обязан его
реализовывать.
*/

/* 3
Статический класс — это класс, который нельзя использовать для создания объектов, а его методы и свойства 
вызываются через название класса. 
*/

/* 4
Generics — это механизм, который позволяет создавать классы, методы и интерфейсы, работающие с разными типами 
данных, без необходимости писать отдельный код для каждого типа.
*/

/* 5
struct — это пользовательский тип данных в c#, похожий на class, но отличается тем что
struct является типом-значением (value type), а class — ссылочным типом (reference type).
*/

using Domain;

/* 
try
{
    MyQueue<int> numbers = new MyQueue<int>();
    numbers.Enqueue(1);
    numbers.Enqueue(2);
    numbers.Enqueue(3);
    numbers.Enqueue(4);
    int a = numbers.Dequeue();
    System.Console.WriteLine(a);
    System.Console.WriteLine(numbers.Peek());
    System.Console.WriteLine(numbers.Count);
    numbers.Clear();
    System.Console.WriteLine(numbers.Count);
}
catch (Exception e)
{
    System.Console.WriteLine(e.Message);
}
*/

using Infrastructure;

IStudentService studentService = new StudentService();

while (true)
{
    System.Console.WriteLine("1. Добавить студента");
    System.Console.WriteLine("2. Показать всех студентов");
    System.Console.WriteLine("3. Обновить студента");
    System.Console.WriteLine("4. Удалить студента");
    System.Console.WriteLine("5. Поиск по имени");
    System.Console.WriteLine("6. Поиск по группе");
    System.Console.WriteLine("exit. Выход");

    System.Console.Write("Выберите действие: ");

    try
    {
        string choice = Console.ReadLine()!;

        switch (choice)
        {
            case "1":
                System.Console.Write("Введите id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                System.Console.Write("Введите имя: ");
                string fullName = Console.ReadLine() ?? "";

                System.Console.Write("Введите возраст: ");
                int age = Convert.ToInt32(Console.ReadLine());

                System.Console.Write("Введите группу: ");
                string group = Console.ReadLine() ?? "";

                Student student = new Student
                {
                    Id = id,
                    FullName = fullName,
                    Age = age,
                    Group = group
                };

                studentService.AddStudent(student);
                break;

            case "2":
                studentService.DisplayStudents();
                break;

            case "3":
                System.Console.Write("Введите id: ");
                int id1 = Convert.ToInt32(Console.ReadLine());

                System.Console.Write("Введите имя: ");
                string fullName1 = Console.ReadLine() ?? "";

                System.Console.Write("Введите возраст: ");
                int age1 = Convert.ToInt32(Console.ReadLine());

                System.Console.Write("Введите группу: ");
                string group1 = Console.ReadLine() ?? "";

                Student updateStudent = new Student
                {
                    Id = id1,
                    FullName = fullName1,
                    Age = age1,
                    Group = group1
                };

                studentService.UpdateStudent(updateStudent);
                break;

            case "4":
                System.Console.Write("Введите Id студента: ");
                int id3 = Convert.ToInt32(Console.ReadLine());

                studentService.DeleteStudent(id3);
                break;

            case "5":
                System.Console.Write("Введите полное имя: ");
                string fullName2 = Console.ReadLine() ?? "";

                Student? s = studentService.SearchByName(fullName2);

                if (s != null)
                {
                    System.Console.WriteLine($"Id: {s.Id}");
                    System.Console.WriteLine($"FullName: {s.FullName}");
                    System.Console.WriteLine($"Age: {s.Age}");
                    System.Console.WriteLine($"Group: {s.Group}");
                }
                break;

            case "exit":
                return;
        }
    }
    catch (Exception e)
    {
        System.Console.WriteLine("Ошибка: " + e.Message);
    }
}

