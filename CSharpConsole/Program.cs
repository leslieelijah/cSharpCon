using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using CSharpConsole;

namespace CSharpConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
           setter();
        }

        public static void setter()
        {
            string data = @"C:/Users/Leslie.Mahasha/Documents/Visual Studio 2015/Projects/CSharpConsole/CSharpConsole/names.json";
            var json = File.ReadAllText(data).ToString();

            dynamic details = JsonConvert.DeserializeObject(json);
            using (StreamReader r = new StreamReader(data))
            {
                JsonSerializer serializer = new JsonSerializer();

                foreach(var detail in details)
                {
                    if (detail.age <= 21 || detail.surname == "Mahasha")
                    { 
                        Console.WriteLine("Youth: " + detail.title + " " + detail.firstName + " " + detail.surname + " (" + detail.age + ")\n" );
                    }
                    else if(detail.age >= 21 && detail.age <= 80 || detail.surname == "Mahasha")
                    {
                        Console.WriteLine("Parents: " + detail.title + " " + detail.firstName + " " + detail.surname + " (" + detail.age + ")\n");
                    }
                    else if(detail.age >= 80)
                    {
                        Console.WriteLine("Grandparents: " + detail.title + " " + detail.firstName + " " + detail.surname + " (" + detail.age + ")\n");
                    }
                    else
                    {
                        Console.WriteLine("We simply do not have your age available!");
                    }
                }  
            }
        }
    }
}
