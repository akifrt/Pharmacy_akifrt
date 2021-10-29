using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October_21
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set;}
        public static int id = 0;


        public Student(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            id++;
        }

        public override string ToString()
        {
            return $"Student Name: {this.Name}, Student surname: {this.Surname}, Student age: {this.Age}";
        }
    }
}
