using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;

public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary,
DateTime HireDate)> employees)
{
    var desiredEmployees = employees.Where(e =>
        (e.Age >= 25 && e.Age <= 40) && 
        (e.Department == "IT" || e.Department == "Finance") && 
        (e.Salary >= 5000 && e.Salary <= 9000) && 
        (e.HireDate > new DateTime(2017, 1, 1))).ToList();
    if (desiredEmployees.Count == 0)
    {
        Console.WriteLine("Aradiginiz kriterlere uygun calisan bulunamadi.");
        return "{\"Names\":[],\"TotalSalary\":0,\"AverageSalary\":0,\"MinSalary\":0,\"MaxSalary\":0,\"Count\":0}";
    }
    var totalSalary = desiredEmployees.Sum(e => e.Salary);
    var averageSalary = Math.Round(desiredEmployees.Average(e => e.Salary), 2);
    var minSalary = desiredEmployees.Min(e => e.Salary);
    var maxSalary = desiredEmployees.Max(e => e.Salary);
    var count = desiredEmployees.Count();
    var sortedNames = desiredEmployees.OrderByDescending(e => e.Name.Length).ThenBy(e => e.Name).Select(e => e.Name).ToList();
    var output = new
    {
        Names = sortedNames,
        TotalSalary = totalSalary,
        AverageSalary = averageSalary,
        MinSalary = minSalary,
        MaxSalary = maxSalary,
        Count = count
    };

        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };


        return JsonSerializer.Serialize(output, options);


}

