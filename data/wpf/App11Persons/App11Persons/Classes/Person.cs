using System;
using System.Runtime.Versioning;

namespace App11Persons.Classes
{
    public class Person
    {
        private string fName,lName;
        private int age;
        public string FName
        {
            get => fName;
            set
            {
                if (value == fName || string.IsNullOrWhiteSpace(value))
                    return;
                fName = value;
            }
        }
        public string LName
        {
            get => lName;
            set
            {
                if (value == lName || string.IsNullOrWhiteSpace(value))
                    return;
                lName = value;
            }
        }
        public int Age
        {
            get => age;
            set
            {
                if (value == age || value < 0)
                    return;
                age = value;
            }
        }
        public Person() { FName = "noname"; LName = "noname"; Age = 0; }
        public Person(string fn, string ln, int a) : this()
        {
            FName = fn;
            LName = ln;
            Age = a;
        }
        public override string ToString()
        {
            return $"{LName} {FName}, {Age}";
        }
        public static bool operator ==(Person a, Person b)
        {
            return a.FName == b.FName &&
                a.LName == b.LName &&
                a.Age == b.Age;
        }
        public static bool operator !=(Person a, Person b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Person))
                return false;
            return this == obj as Person;
        }
        /*
        public override int GetHashCode()
        {
            return new Random().Next();
        }
        */
    }
}
