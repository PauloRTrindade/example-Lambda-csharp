using Lambda.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        Employee employee = new Employee("Paulo", "paulo@gmail.com", 5000.00);

        Console.WriteLine(employee);
    }
}