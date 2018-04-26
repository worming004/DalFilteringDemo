using System;

namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            var polFilter = new PolicyFilter(new PolicyDal())
            {
                NameContains = "ab",
                OrderBy = "Name", // we will ordering based on the property Name of all PolicyFound
                Take = 50
            };

            foreach (var row in polFilter.ApplyFilter())
            {
                Console.WriteLine(row.Name);
            }
            Console.ReadLine();
        }
    }
}
