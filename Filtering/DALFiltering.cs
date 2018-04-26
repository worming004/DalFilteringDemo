using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Filtering
{
    public abstract class Filter<T>
    {
        protected DAL<T> dal;
        public string OrderBy;
        public int Take;

        protected IEnumerable<T> ApplyOrderTake(IEnumerable<T> source)
        {
            return source
                .OrderBy(val => val.GetType().GetProperty(this.OrderBy).GetValue(val, null))
                .Take(this.Take);
        }

        public IEnumerable<T> GetAll()
        {
            return dal.GetAll();
        }
    }

    // look a lot of Query Pattern : simple class that take DAL in constructor and apply itself all filtering rules.
    public class PolicyFilter : Filter<Policy>
    {
        public string NameContains;

        public PolicyFilter(PolicyDal dal)
        {
            this.dal = dal;
        }

        public IEnumerable<Policy> ApplyFilter()
        {
            // First we take all data that pass filtering
            var data = dal.GetAll()
                .Where(val => val.Name.Contains(this.NameContains));
            // then we order and take data with value setted in Filter<T>
            return this.ApplyOrderTake(data);
        }
    }
}
