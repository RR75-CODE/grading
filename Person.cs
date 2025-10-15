using System;

namespace grading
{
    public abstract class Person
    {
        public string Name {get; protected set;}
        public int Age {get; protected set;}
        public DateTime DateOfBirth {get; protected set;}
        public string Gender {get; protected set;}

        protected Person(string name, int age, DateTime dob, string gender)
        {
            Name = name;
            Age = age;
            DateOfBirth = dob;
            Gender = gender;
        }

        public abstract void DisplayInfo();
    }
}
