using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using FileReader.Mappers;

namespace FileReader.Services
{
    public class UserService
    {
        public List<User> ReadCSVFile(string location)
        {
            try
            {
                using (var reader = new StreamReader(location, Encoding.Default))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<UserMap>();
                    var records = csv.GetRecords<User>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public double calculateAverageSalary(List<User> users)
        {
            if (users != null)
            {
                return 0;
            }
            double averageSalary = users.Average(user => user.Salary);
            return averageSalary;
        }
    }
}
