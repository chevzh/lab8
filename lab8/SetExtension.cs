using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public static class SetExtension
    {
        //public static Set<T> ToSet<T>(this IEnumerable<T> source)
        //{
        //    return new Set<T>(source);
        //}

        public static Set<string> AddPoint(this Set<string> set)
        {
            Set<string> resultSet = new Set<string>();
            
            foreach (var item in set)
            {
                if(item.ElementAt(item.Length-1) != '.')
                {
                    resultSet.Add(item.AddPoint());
                }
                else
                {
                    resultSet.Add(item);
                }
                               
            }
            return resultSet;
        }

        //public static Set<int> DeleteZeroElements(this Set<int> set)
        //{
        //    Set<int> resultSet = new Set<int>();
        //    foreach (var item in set)
        //    {
        //        if (item != 0)
        //            resultSet.Add(item);
        //    }

        //    return resultSet;
        //}


        public static string AddPoint(this string str)
        {
            string resultString = str + ".";
            return resultString;
        }

    }
}
