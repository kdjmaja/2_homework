using System;
using System.Collections.Generic;
using System.Linq;


namespace Zad_3_4_5
{
    public class Student
    {
        public readonly string Name;
        public readonly string Jmbag;
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
            Gender = Gender.Female;
        }
        public Student(string name, string jmbag, Gender gender)
        {
            Name = name;
            Jmbag = jmbag;
            Gender = gender;
        }


        public override bool Equals(object obj)
        {
            if (obj == null || Jmbag==null)
            {
                return false;
            }
            return Jmbag.Equals(((Student)obj).Jmbag);
        }

        public override int GetHashCode()
        {
            return Jmbag != null ? StringComparer.CurrentCulture.GetHashCode(Jmbag) : 0;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            if (ReferenceEquals(null, student1) || ReferenceEquals(null, student2))
            {
                return false;
            }
            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1==student2);
        }

        public override string ToString()
        {
            return "[" + string.Join(",", Name, Jmbag, Gender) + "]";
        }
    }
    public enum Gender
    {
        Male, Female
    }

    public class Examples
    {
        public static void Example1()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            bool anyIvanExists = list.Any(s => s == ivan);
            Console.WriteLine(anyIvanExists);
        }

        public static void Example2()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            // 2 :(
            var distinctStudents = list.Distinct().Count();
            Console.WriteLine(distinctStudents);
        }
    }

}
