using System;
using System.Linq;


namespace Zad_3_4_5
{
    class Program
    {
        static void Main()
        {

//  3. ZADATAK
            int[] integers = { 1, 2, 2, 2, 3, 3, 4, 5 };
            string[] strings =
                integers.GroupBy(i => i).Select(i => "Broj " + i.Key + " ponavlja se " + i.Count() + " puta.").ToArray();

            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }
//  4. ZADATAK
            Console.WriteLine();
            Examples.Example1();
            Console.WriteLine();
            Examples.Example2();
            Console.WriteLine();
            
//  5. ZADATAK

            University[] universities = GetAllCroatianUniversities();
            Student[] allCroatianStudents = universities.SelectMany(i => i.Students).Distinct().ToArray();
            Console.WriteLine("All Croatian students:");
            foreach (var s in allCroatianStudents)
            {
                Console.WriteLine(s);
            }

            Student[] croatianStudentsOnMultipleUniversities =
                universities.SelectMany(i => i.Students)
                    .GroupBy(s => s)
                    .Where(group => group.Count() > 1)
                    .Select(group => group.Key)
                    .ToArray();
            Console.WriteLine();
            Console.WriteLine("Croatian students on multiple universities:");
            foreach (var s in croatianStudentsOnMultipleUniversities)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            Student[] studentsOnMaleOnlyUniversities =
                universities.Where(s => s.Students.All(g => g.Gender.Equals(Gender.Male)))
                    .SelectMany(i => i.Students)
                    .ToArray();

            Console.WriteLine("Croatian students on male-only univerities.");
            foreach (var s in studentsOnMaleOnlyUniversities)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }

        private static University[] GetAllCroatianUniversities()
        {
            University zagreb = new University("University of Zagreb",
                new[]
                {
                    new Student("Katja", "00361", Gender.Female),
                    new Student("Ivana", "00362", Gender.Female),
                    new Student("Lea", "00363", Gender.Female),
                    new Student("Natasa", "00364", Gender.Female),
                    new Student("Iva", "00365", Gender.Female),
                    new Student("Matej", "00366", Gender.Male),
                    new Student("Dino", "00367", Gender.Male),
                    new Student("Igor", "00368", Gender.Male),
                    new Student("Tin", "00369", Gender.Male),
                    new Student("Bojan", "00360", Gender.Male)
                }
            );

            University osijek = new University("University of Osijek",
                new []
                {
                    new Student("Tonka", "00461", Gender.Female),
                    new Student("Lea", "00363", Gender.Female),
                    new Student("Dunja", "00463", Gender.Female),
                    new Student("Petra", "00464", Gender.Female),
                    new Student("Sara", "00465", Gender.Female),
                    new Student("Mirko", "00466", Gender.Male),
                    new Student("Nikola", "00467", Gender.Male),
                    new Student("Dominik", "00468", Gender.Male),
                    new Student("Alen", "00469", Gender.Male),
                    new Student("Antun", "00460", Gender.Male)
                }
            );

            University split = new University("University of Split",
                new []
                {
                    new Student("Rebeka", "00561", Gender.Female),
                    new Student("Lana", "00562", Gender.Female),
                    new Student("Julija", "00563", Gender.Female),
                    new Student("Matea", "00564", Gender.Female),
                    new Student("Lucija", "00565", Gender.Female),
                    new Student("Tomislav", "00566", Gender.Male),
                    new Student("Stjepan", "00567", Gender.Male),
                    new Student("Zvonimir", "00568", Gender.Male),
                    new Student("Mirko", "00466", Gender.Male),
                    new Student("Marin", "00560", Gender.Male)
                }
            );

            University rijeka = new University("University of Rijeka",
                new []
                {
                    new Student("Zrinka", "00661"),
                    new Student("Ivona", "00662"),
                    new Student("Vanja", "00663"),
                    new Student("Valentina", "00664"),
                    new Student("Tea", "00665")
                }
            );

            University zadar = new University("University of Zadar",
                new []
                {
                    new Student("Darko", "00666", Gender.Male),
                    new Student("Aleks", "00667", Gender.Male),
                    new Student("Luka", "00668", Gender.Male),
                    new Student("Nadan", "00669", Gender.Male),
                    new Student("Ante", "00660", Gender.Male)
                }
            );
            return new [] { zagreb, osijek, rijeka, split, zadar };
        }
    }
}
