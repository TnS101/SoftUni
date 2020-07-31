using System;
using System.IO;

namespace Stream_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Files" + Path.PathSeparator + "Text.txt";
            string OutPutFile = "OutPutFile.txt";
            using (var reader =new StreamReader(filePath))
            {
                int counter = 0;

                string line = reader.ReadLine();

                using (var writer=new StreamWriter(Path.Combine(filePath,OutPutFile)))
                {
                    while (line!=null)
                    {

                        line = $"{++counter}. {line}";
                            Console.WriteLine(line);
                            writer.WriteLine(line);
                        line = reader.ReadLine();
                        
                    }
                }

                while (line!=null)
                {
                    if (counter%2!=0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                    line = reader.ReadLine();
                }

                
            }
        }
    }
}
