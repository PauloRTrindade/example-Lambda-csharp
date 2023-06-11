using Lambda.Entities;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter full file path: ");
        string Path = Console.ReadLine();

        List<Employee> list = new List<Employee>();

        using (StreamReader sr = File.OpenText(Path))
        {
            while (!sr.EndOfStream)
            {
                string[] fields = sr.ReadLine().Split(',');
                string name = fields[0];
                string email = fields[1];
                double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                list.Add(new Employee(name, email, salary));
            }
        }

        Console.Write("Enter salary: ");
        double Salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine();

        Console.WriteLine("Email of people whose salary is more than "
            + Salary.ToString("F2", CultureInfo.InvariantCulture)
            + ":");

        var emails = list.Where(e => e.Salary > Salary)
            .OrderBy(e => e.Email)
            .Select(e => e.Email);
        foreach (string email in emails)
        {
            Console.WriteLine(email);
        }
        Console.Write("Enter the initial letter of the names (employees) for sum: ");
        char ch = char.Parse(Console.ReadLine().ToUpper());

        Console.WriteLine();
        var sum = list.Where(e => e.Name[0] == ch).Sum(e => e.Salary);
        {
            Console.Write("Sum of salary of people whose name starts with '" + ch + "': "
                + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
        Console.WriteLine();
    }
}