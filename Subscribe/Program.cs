using System;
#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
//Subscribers Tullanti
namespace Subscribe
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var subscribes = Service.GetSubcribersAsync();
            var names = GetNames(subscribes);

            await foreach (var item in names)
            {
                Console.WriteLine($"{item} Has subscribed to the service");
            }
        }

        static async IAsyncEnumerable<string> GetNames(IAsyncEnumerable<Person> people)
        {
            await foreach (var p in people)
            {
                yield return GetName(p);
            }
        }

        static string GetName(Person p)
        {
            // if(p.MiddleName != null) return $"{p.FirstName} {p.MiddleName} {p.LastName}";
            return (p.MiddleName != null) ? $"{p.FirstName} {p.MiddleName[0]} {p.LastName}"
                  : $"{p.FirstName} {p.LastName}";
        }
    }

    public class Person
    {
        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
            MiddleName = null;
        }
        public Person(string first, string middle, string last)
        {
            FirstName = first;
            LastName = last;
            MiddleName = middle;
        }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public class Service
    {
        public static IEnumerable<Person> GetSubcribers()
        {
            Person[] people = {
                new Person("Nana","Scot","Hunter"),
                new Person("Arif","Hunter"),
                new Person("Malik","Scot","Jon"),
                new Person("Sahib","Henry","Lazzen"),
                new Person("Lala","Hill"),
                new Person("Benny","Hill"),
            };
            foreach (var p in people[1..^1]) yield return p;
        }

        public static async IAsyncEnumerable<Person> GetSubcribersAsync()
        {
            Person[] people = {
                new Person("Nana","Scot","Hunter"),
                new Person("Arif","Hunter"),
                new Person("Malik","Scot","Jon"),
                new Person("Sahib","Henry","Lazzen"),
                new Person("Lala","Hill"),
                new Person("Benny","Hill"),
            };
            foreach (var p in people[1..^1]) yield return p;
        }
    }
    public class PersonTest
    {
        public Person[] people { get; set; }
        public PersonTest()
        {
            people = new Person[]  {
                new Person ("Nana","Scot","Hunter"),
                new Person ("Arif","Hunter"),
                new Person ("Malik","Scot","Jon"),
                new Person ("Sahib","Henry","Lazzen"),
                new Person ("Lala","Hill"),
                new Person ("Benny","Hill"),
            };
        }

        public string RecursivePatternSample(Person[] people)
        {

            foreach (var p in people)
            {
                switch (p.FirstName, p.MiddleName, p.LastName)
                {
                    case (string f, string m, string l):
                        return $"{f} {m} {l}";

                    case (string f, null, string l):
                        return $"{f} {l}";
                    case (string f, string m, null):
                        return $"{f} {m}";
                    case (string f, null, null):
                        return f;

                    case (null, string m, string l):
                        return $"Ms/Mr {m} {l}";
                    case (null, null, string l):
                        return $"Ms/Mr {l}";
                    case (null, string m, null):
                        return $"Ms/Mr {m}";
                    case (null, null, null):
                        return "Someone";
                        //default: return "Ok";   
                }

            }

            return "";
        }
    }
}

//https://www.youtube.com/watch?v=VdC0aoa7ung //pazz1