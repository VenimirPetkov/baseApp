using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baseCleanerApp
{
    class Student
    {
        private string name;
        private string email;
        private string phone;
        public Student(string email)
        {
            this.email = email;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public void getInfo()
        {
            Console.WriteLine($"name: {name}, email: {email}, phone: {phone}");
        }

        public override string ToString()
        {
            return $"{Name},{Email},{Phone}";
        }
    }
}
