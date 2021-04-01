using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Student
    {
        public static int last_id = 0;
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public Student(string name, int age)
        {
            this.id = last_id++;
            this.name = name;
            this.age = age;
        }
    }
}