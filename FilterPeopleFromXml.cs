using System;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Xml;
public static string FilterPeopleFromXml(string xmlData)
{
    XDocument myXml = XDocument.Parse(xmlData);

    var desiredPersons = myXml.Descendants("Person").Where(p =>
    {
 
            try
            {
                return (int)p.Element("Age") > 30 &&
                       (string)p.Element("Department") == "IT" &&
                       (decimal)p.Element("Salary") > 5000 &&
                       DateTime.Parse((string)p.Element("HireDate")) < new DateTime(2019, 1, 1);
            }
            catch
            {
                return false; 
            }
        }).ToList();

        if (desiredPersons.Count == 0)
        {
            Console.WriteLine("Aradiginiz kriterlere uygun kisi bulunamadi.");
            return "{\"Names\":[],\"TotalSalary\":0,\"AverageSalary\":0,\"MaxSalary\":0,\"Count\":0}";
        }
        var names = desiredPersons.Select(p => p.Element("Name").Value).OrderBy(name => name).ToList();
        var totalSalary = desiredPersons.Sum(p => int.Parse(p.Element("Salary").Value));
        var averageSalary = desiredPersons.Average(p => int.Parse(p.Element("Salary").Value));
        var maxSalary = desiredPersons.Max(p => int.Parse(p.Element("Salary").Value));
        var count = desiredPersons.Count;

        var output = new
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MaxSalary = maxSalary,
            Count = count
        };
        return JsonSerializer.Serialize(output);

    }
