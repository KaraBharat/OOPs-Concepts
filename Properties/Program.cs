using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    public class Person
    {
        public DateTime DateOfBirth { get; private set; }

        public Person(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        public int Age
        {
            get
            {
                var timeStamp = DateTime.Now - DateOfBirth;
                var years = timeStamp.Days / 365;

                return years;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person(new DateTime(1992, 9, 7));
            Console.WriteLine(person.Age);
        }
    }
}
