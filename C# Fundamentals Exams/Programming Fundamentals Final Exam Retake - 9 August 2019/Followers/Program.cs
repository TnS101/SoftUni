using System;
using System.Collections.Generic;
using System.Linq;

namespace Followers___treta_zadacha__dict_
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameList = new List<string>();
            var countDict = new Dictionary<string, int>();
            while (true)
            {
                string[] commands = Console.ReadLine().Split(": ");
                
                if (commands[0]=="Log out")
                {
                    break;
                }
                else if (commands[0]=="New follower")
                {
                    string userName = commands[1];
                    if (!countDict.ContainsKey(userName)&&!nameList.Contains(userName))
                    {
                        countDict.Add(userName, 0);
                        nameList.Add(userName);
                    }
                }
                else if (commands[0] == "Like")
                {
                    string userName = commands[1];
                    int like = int.Parse(commands[2]);
                    if (!countDict.ContainsKey(userName)&&!nameList.Contains(userName))
                    {
                        countDict.Add(userName, like);
                        nameList.Add(userName);
                    }
                    else
                    {
                        countDict[userName] += like;
                    }

                }
                else if (commands[0] == "Comment")
                {
                    string userName = commands[1];
                    if (!countDict.ContainsKey(userName)&&!nameList.Contains(userName))
                    {
                        countDict.Add(userName, 1);
                        nameList.Add(userName);
                    }
                    else
                    {
                        countDict[userName] += 1;

                    }


                }
                else if (commands[0] == "Blocked")
                {
                    string userName = commands[1];
                    if (!countDict.ContainsKey(userName)&&!nameList.Contains(userName))
                    {
                        Console.WriteLine($"{userName} doesn't exist.");
                    }
                    else
                    {
                        countDict.Remove(userName);
                        nameList.Remove(userName);
                    }
                }
            }
            Console.WriteLine($"{nameList.Count} followers");

            foreach (var item in countDict.OrderBy(k=>k.Key).OrderByDescending(v=>v.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
