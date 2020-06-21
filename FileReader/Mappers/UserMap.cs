using System;
using CsvHelper.Configuration;

namespace FileReader.Mappers
{
    public sealed class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Map(x => x.Name).Name("Name");
            Map(x => x.Salary).Name("Salary");
            Map(x => x.Rate).Name("Rate");
        }
    }
}
