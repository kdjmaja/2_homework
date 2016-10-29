namespace Zad_3_4_5
{
    public class University
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }
        public University(string name, Student[] students)
        {
            Name = name;
            Students = students;
        }
    }
    
}
