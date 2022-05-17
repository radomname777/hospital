using System;
namespace hospital
{
    //[Serializable]
     class  Human
    {
        private string name;

        public string Name
        {
            get { return name; }
            set {
                while (value.Length<3)
                {
                    Console.Write("Enter name: ");
                    value = Console.ReadLine();
                }
                name = value; }
        }
        private string surname;

        public string Surname
        {
            get { return surname; }
            set
            {
                while (value.Length < 5)
                {
                    Console.Write("Enter surname: ");
                    value = Console.ReadLine();
                }
                surname = value;
            }
        }

        public string Gender { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set {
                while (value <= 0|| value > 100)
                {
                    Console.Write("Enter age: ");
                    value = Convert.ToInt32(Console.ReadLine());
                }
                age = value;
            }
        }

        public Human()
        {
            Name = ""; Surname="";
            Gender = ""; Age = 0;
        }
        public Human(string name,string surname,string gender,int age)
        {
            Name = name; 
            Surname = surname;
            Gender = gender;
            Age = age;
        }
    }
}
