using System;
using System.Linq;
using System.Collections.Generic;
namespace Funct_programm_ex__11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split().ToArray();

            string filters = Console.ReadLine();

            var list = new List<string>();

            while (filters!="print")
            {
                string[] filterInfo = filters.Split(";");

                string action = filterInfo[0];

                if (action=="Add filter")
                {
                    list.Add($"{filterInfo[1]};{filterInfo[2]}");
                }

                filters = Console.ReadLine();

                Func<string,int, bool> lengthFilter = (name,length) => name.Length ==length;
                Func<string, string, bool> startsWithFilter = (name, param) => name.StartsWith(param);
                Func<string, string, bool> endsWithFilter = (name, param) => name.EndsWith(param);
                Func<string, string, bool> containsFilter = (name, param) => name.Contains(param);

                foreach (var item in list)
                {
                    string[] currentFilterInfo = item.Split(";");

                    string action1 = currentFilterInfo[0];

                    string param = currentFilterInfo[1];

                    if (action1 == "Starts with")
                    {
                        names.Where(x => !startsWithFilter(x, param));
                    }
                    else if (action1=="Ends with")
                    {
                        names.Where(x => !endsWithFilter(x, param));
                    }
                    else if (action1 == "Length")
                    {
                        int length = int.Parse(param);
                        names.Where(x => !lengthFilter(x, length));
                    }
                    else if (action1 == "Contains")
                    {
                        names.Where(x => !containsFilter(x, param));
                    }
                }
                Console.WriteLine(string.Join(" ",list));
            }
            
        }
    }
}
