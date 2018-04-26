using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering
{
    // Entity
    public class Policy
    {
        public static int LastId = 0;
        public int Id { get; set; }
        public string Name { get; set; }

        public Policy()
        {
            Id = LastId++;
            Name = Guid.NewGuid().ToString();
        }
    }

    // generic DAL
    public abstract class DAL<T>
    {
        protected IEnumerable<T> data;


        public IEnumerable<T> GetAll()
        {
            return this.data;
        }
    }

    // Specific Dal
    public class PolicyDal : DAL<Policy>
    {
        public PolicyDal()
        {
            var collection = new List<Policy>();
            this.data = collection;
            for (int i = 0; i < 12000; i++)
            {
                var pol = new Policy
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString()
                };
                collection.Add(pol);
            }
        }
    }
}
