using System;
using hospital;

namespace MyApp 
{
    static class ConsoleUtility
    {
        const char _block = '■';
        const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        const string _twirl = "-\\|/";
        public static void WriteProgressBar(int percent, bool update = false)
        {
            if (update)
                Console.Write(_back);
            Console.Write("[");
            var p = (int)((percent / 10f) + .5f);
            for (var i = 0; i < 20; ++i)
            {
                if (i >= p)
                    Console.Write(' ');
                else
                    Console.Write(_block);
            }
            Console.Write("] {0,3:##0}%", percent/2);
        }
        public static void WriteProgress(int progress, bool update = false)
        {
            if (update)
                Console.Write("\b");
            Console.Write(_twirl[progress % _twirl.Length]);
        }
    }
    class Program
    {
        public static string? MyProperty { get; set; }
        public static string? Doctorname { get; set; }
        static void select(int number)
        {
            Console.ForegroundColor = ConsoleColor.White;
            switch (number)
            {
                case 0: Pediatriy pediatriy = new Pediatriy(); pediatriy.Start(); MyProperty = pediatriy.app.MyProperty; Doctorname = pediatriy.app.Doctorname;  break;
                case 1: Travmatologiya tra = new Travmatologiya(); tra.Start(); MyProperty = tra.app.MyProperty; Doctorname = tra.app.Doctorname; break;
                case 2: Stamotologiya stamatolgiya = new Stamotologiya(); stamatolgiya.Start(); MyProperty = stamatolgiya.app.MyProperty; Doctorname = stamatolgiya.app.Doctorname; break;
            }

            return;
        }
        static void Fun()
        {
            for (var i = 0; i <= 200; ++i)
            {
                ConsoleUtility.WriteProgressBar(i, true);
                Thread.Sleep(33);
            }
            Console.WriteLine();
            User user = new User();
            string[] strarr = new string[] {"Pediatriy", "Travmatologiya","Stamotologiya"};
            int number = 0;
            Console.WriteLine("Enter (LeftArrow && RightArrow && click Enter to select)");
            while (strarr != null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine($"{(char)16} {strarr[number]} {(char)17}");
                ConsoleKeyInfo selec = Console.ReadKey();
                Console.Clear();
                if (selec.Key == ConsoleKey.LeftArrow && number == 0) number = strarr.Length - 1;
                else if (selec.Key == ConsoleKey.RightArrow && number == strarr.Length - 1) number = 0;
                else if (selec.Key == ConsoleKey.RightArrow) number++;
                else if (selec.Key == ConsoleKey.LeftArrow) number--;
                else if (selec.Key == ConsoleKey.Enter) { select(number); break; }
                else { Console.WriteLine("Enter (LeftArrow && RightArrow && click Enter to select)"); continue; }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Tesekkurler  {user.Name} {user.Surname} saat: {MyProperty} {Doctorname} Hekimin qebulundasiz");
        }
        static void Main(string[] args)
        {
            Fun();

        }
    }
}