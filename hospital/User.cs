using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hospital
{
    class User :Human
    {
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                while (true)
                {
                    Console.Write("Enter Gmail: ");
                    value = Console.ReadLine();
                    if (Regex.IsMatch(value, pattern)) break;
                }
                email = value;
            }
        }
        private string number;

        public string Phone
        {
            get { return number; }
            set {
                while (value.Length < 9 || value.Length>10)
                {
                    Console.Write("Enter Phone: ");
                    value = Console.ReadLine();
                }
                number = value;
            }
        }
        public User() : base()
        {
            Email = ""; Phone = "";
        }
        //public User(string name, string surname, string gender, int age,string email,string number) :base(name,surname,gender,age)
        //{
        //    Email = email;
        //    Phone = number;
        //}
        public override string ToString()
        {
            return $"{Name}-{Surname}-{Gender}-{Age}-{Email}-{Phone}\n"; 
        }


    }
}
