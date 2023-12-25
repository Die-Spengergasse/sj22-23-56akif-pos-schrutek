using Spg.Linq.Demo.MyDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Linq.Demo
{
    //public delegate bool MyFilterDelegate(Student s);

    public class MyList<T> : List<T> where T : Student
    {
        public IEnumerable<T> Filter(Func<Student, bool> myFilterDelegate)
        {
            List<T> resultList = new List<T>();
            foreach (T item in this)
            {
                if (myFilterDelegate(item))
                {
                    resultList.Add(item);
                }
            }
            return resultList;
        }
    }
}
