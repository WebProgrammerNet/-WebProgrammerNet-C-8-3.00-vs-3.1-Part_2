using System;

namespace InterFaceBody
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Adam", "Smith", null);
            var fulName = person.FullName;
            string a = person.FirstName;
            string? b = person.MiddleName;
            string c = person.LastName;


            Human human = new Human() { Name = "Jonn" };
            //human.SayHello();


            IHuman cast = (IHuman)human;
            cast.SayHello();

            IHuman human1 = new Human() { Name = "Weight" };
            human1.SayHello();

            ((IHuman)new Human { Name = "Milla" }).SayHello();

            ((ICopyHuman)new Human { Name = "Azad" }).SayHello();
          
        }

    }
    public interface IHuman
    {
        string Name { get; set; }

        public void SayHello() // Will not Compile
        {
            Console.WriteLine($"Good My name is {Name}");
        }

    }

    public interface ICopyHuman : IHuman
    {
        //public void SayHello() // Will not Compile
        //{
        //    Console.WriteLine($"Good My name is {Name}");
        //}

    }
    public class Human : ICopyHuman
    {
        public string Name { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }

        public Person(string first, string last, string middle)
            => (FirstName, LastName, MiddleName) = (first, last, middle);

        public string FullName => $"{FirstName} {MiddleName?[0]} {LastName}";
    }
}
