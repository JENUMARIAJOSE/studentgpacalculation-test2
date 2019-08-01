using System.Collections.Generic;

namespace test2
{
    class Student
    {
        string fname;
        string lname;
        int id;
        double gpa;
       
        
        public static List<Student> students = new List<Student>();
        public static List<Student> gpas = new List<Student>();




        public Student(string fName, string lName, int id)
        {
            this.fname = fName;
            this.lname = lName;
            this.id = id;
        }
        public Student(double gpa) {
            this.gpa = gpa;
        }

        public override string ToString()
        {
            var stud = "name: " + fname +" "+lname+ "\n" + "id:" + id +"\n" + "gpa:" + gpa.ToString();
            return stud;
        }
       

    }
}