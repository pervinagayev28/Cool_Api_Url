using System.Text;
using System.Text.Json;


public class Course
{
    public string course { get; set; }
    public override string ToString()
    {
        return $"\n\tCourse: {course}";
    }
}

public class Person
{
    public int id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string gen { get; set; }
    public List<Course> courses { get; set; }
    public override string ToString()
    {
        string coursesStr = string.Join(", ", courses.Select(c => c.ToString()));
        return $"ID: {id}\n, Name: {name}\n, Surname: {surname}\n, Gender: {gen}\n, Courses: {coursesStr}\n";
    }
}

public class Root
{
    public List<Person> people { get; set; }
    public override string ToString()
    {
        string peopleStr = string.Join(Environment.NewLine, people.Select(p => p.ToString()));
        return $"People:{Environment.NewLine}{peopleStr}";
    }
}
class Program
{
    static async Task Main(string[] args)
    {
        await foo();
    }
    static async Task foo()
    {
        using (HttpClient connection = new HttpClient())
        {
            var response = await connection.GetStringAsync("https://localhost:7067/RequestControllers/GetAllStudents\r\n");
            foreach (var student in JsonSerializer.Deserialize<List<Person>>(response))
            {
                Console.WriteLine(student);
            }

        }

    }
}