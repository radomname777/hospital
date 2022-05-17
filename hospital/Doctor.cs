using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace hospital
{
     class Doctor : Human
    {
        public string? Work { get; set; }
        public string[] Time { get; set; } = new string[] { "09:00-11:00", "12:00-14:00", "15:00-17:00" };
        public string? date { get; set; }
        public Doctor(string name,string surname,string gender ,int age,string work) : base(name, surname, gender, age)
        {
            date = DateTime.Now.ToString("MM/dd/yyyy");
            Work = work;
        }
        public Doctor() {}

        public override string ToString()
        {
            return $"{Name}-{Surname}-{Gender}-{Age}-{Work}\n";
        }

    }


}
