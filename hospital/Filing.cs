using Newtonsoft.Json;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using System.Collections;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace hospital
{
    class App
    {
        public string? MyProperty { get; set; }
        public string? Doctorname { get; set; }
        private void Copyfile2(string filename,int len)
        {
            int n = 0;
        //   File.Delete("copyfile.bin");
             using FileStream fss = new FileStream(filename + ".bin", FileMode.OpenOrCreate, FileAccess.Write);
             using BinaryWriter bw = new BinaryWriter(fss);
             using FileStream fs = new FileStream("copyfile.bin", FileMode.Open, FileAccess.Read);
            using BinaryReader br = new BinaryReader(fs);
            for (int i = 0; i < fs.Length;)
            {
                if (n==len) break;
                string[] text = new string[8];
                text[0] = br.ReadString();
                bw.Write(text[0]);
                text[1] = br.ReadString();
                bw.Write(text[1]);
                text[2] = br.ReadString();
                bw.Write(text[2]);
                int number = br.ReadInt32();
                bw.Write(number);
                for (int j = 3; j < 8; j++)
                {
                    text[j] = br.ReadString();
                    bw.Write(text[j]);
                }
                i += Arraycount(text); i += number.ToString().Length + 2;
                n++;
            }
        }
        private void CopyFile(string[] arr, string filename,int num,int num1)
        {
            //   File.Delete("copyfile.bin");
            using FileStream fss = new FileStream("copyfile.bin", FileMode.OpenOrCreate, FileAccess.Write);
            using BinaryWriter bw = new BinaryWriter(fss);
            int n = 0;
            using FileStream fs = new FileStream(filename + ".bin", FileMode.Open, FileAccess.Read);
            using BinaryReader br = new BinaryReader(fs);
            string? name = "";
            for (int i = 0; i < fs.Length;)
            {
                if (n == 3) break;
                string[] text = new string[8];
                text[0] = br.ReadString();
                bw.Write(text[0]);
                text[1] = br.ReadString();
                bw.Write(text[1]);
                text[2] = br.ReadString();
                bw.Write(text[2]);
                int number = br.ReadInt32();
                bw.Write(number);
                text[3] = br.ReadString();
                bw.Write(text[3]);
                for (int j = 4; j < 7; j++)
                {
                    text[j] = br.ReadString();
                    if (num == j - 4&&num1==n)
                    {
                        bw.Write(text[j] + "Reserve");
                        MyProperty = text[j];
                    }
                    else bw.Write(text[j]);
                }
                text[7] = br.ReadString();
                bw.Write(text[7]);
                i += Arraycount(text); i += number.ToString().Length + 2;
                n++;
            }
            fs.Close();

        }
        private void WorkingTime(string[] arr,string time,int number,string filename,int num1)
        {
            Console.Clear();
            if (arr[number + 5] != time)
            {
                CopyFile(arr,filename,number,num1);
                return;
            }
            else Console.WriteLine("No body"); ;
        }

        private void DoctorTime(string[] arr,string filename,int num)
        {
            int number = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{arr[0]} {arr[1]}");
                string[] array = new string[] {arr[4],arr[5],arr[6],"Exit"};
                for (int i = 0; i < array.Length; i ++)
                {
                    if (i == number) { array[i] += " <-"; Console.ForegroundColor = ConsoleColor.DarkRed; }
                    else Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{i+1}) {array[i]}");
                }
                ConsoleKeyInfo selec = Console.ReadKey();
                Console.Clear();
                if (selec.Key == ConsoleKey.UpArrow && number == 0) number = array.Length - 1;
                else if (selec.Key == ConsoleKey.DownArrow && number == array.Length - 1) number = 0;
                else if (selec.Key == ConsoleKey.UpArrow) number --;
                else if (selec.Key == ConsoleKey.DownArrow) number ++;
                else if (selec.Key == ConsoleKey.Enter) {
                    if (number == 3)return; 
                    else if (array[number].IndexOf("Reserve") == -1)WorkingTime(arr, array[number], number, filename, num);
                    else continue;
                    break; }
                else { Console.WriteLine("Enter (UpArrow && DownArrow && click Enter to select)"); continue; }

            } while (true);
  
        }
        private void Inspection(int num,string filename) {
            using FileStream fs = new FileStream(filename + ".bin", FileMode.Open, FileAccess.Read);
            using BinaryReader br = new BinaryReader(fs);
            if (num != 0 && num % 2 <= 0)num =num/2;
            for (int i = 0; i <= num; i++)
            {
                string[] text = new string[8];
                text[0] = br.ReadString();
                text[1] = br.ReadString();
                text[2] = br.ReadString();
                int number = br.ReadInt32();
                for (int j = 3; j < text.Length; j++) text[j] = br.ReadString();
                if (i==num&&num==0)
                {
                    DoctorTime(text,filename,num);
                    Doctorname = text[0];
                    break;
                }
                else if (i == num)
                {
                    DoctorTime(text,filename,num);
                    Doctorname = text[0];
                    /// Console.WriteLine($"{text[0]} {text[1]}");
                    break;
                }
                else continue;

            }
        }
        private void StandartRead(List<string> arr,int n,string filname)
        {
            int number = 0;
            do
            {
       
                string[] array = arr.ToArray();
                
                for (int i = 0, j=1,c=1; i < array.Length; i+=2,j+=2,c++)
                {
                    if (i == number) { array[j] += ' '; array[j] += (char)17; Console.ForegroundColor = ConsoleColor.Blue; }
                    else Console.ForegroundColor = ConsoleColor.DarkRed;
                    //Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{c}) {array[i]} {array[j]}");
                }
                ConsoleKeyInfo selec = Console.ReadKey();
                Console.Clear();
                if (selec.Key == ConsoleKey.UpArrow && number == 0) number = array.Length - 2;
                else if (selec.Key == ConsoleKey.DownArrow && number == array.Length - 2) number = 0;
                else if (selec.Key == ConsoleKey.UpArrow) number-=2;
                else if (selec.Key == ConsoleKey.DownArrow) number+=2;
                else if (selec.Key == ConsoleKey.Enter) {Inspection(number, filname); return; }
                else { Console.WriteLine("Enter (UpArrow && DownArrow && click Enter to select)"); continue; }

            } while (true);
        }
        private void Readarray(object[] arr, int number)
        {
            foreach (var item in arr)Console.Write($"{item} ");
            Console.WriteLine(number);
        }
        private int Arraycount(string[] text)
        {
            int count = 0;
            for (int j = 0; j < text.Length; j++) count += text[j].Length + 1;
            return count;
        }
        public bool ResetTime(string filename)
        {
            using FileStream fs = new FileStream(filename + ".bin", FileMode.Open, FileAccess.Read);
            using BinaryReader br = new BinaryReader(fs);
           string[] text = new string[8];
           for (int i = 0; i < 3; i++) { text[i] = br.ReadString(); }
           int number = br.ReadInt32();
            for (int j = 3; j < text.Length; j++) text[j] = br.ReadString();
            if (text[7]!= DateTime.Now.ToString("MM/dd/yyyy"))return true;
            return false;
        }

        public void oxu(string filename,int len)
        {
          
            int n = 0;
            List<string>list = new List<string>();
            {
                using FileStream fs = new FileStream(filename + ".bin", FileMode.Open, FileAccess.Read);
                using BinaryReader br = new BinaryReader(fs);
                int az = 0;
                for (int i = 0; i < fs.Length;)
                {

                    if (n == len) break;
                    string[] text = new string[8];
                    text[0] = br.ReadString();
                    text[1] = br.ReadString();
                    text[2] = br.ReadString();
                    int number = br.ReadInt32();
                    for (int j = 3; j < text.Length; j++) text[j] = br.ReadString();
                    list.Add(text[0]); list.Add(text[1]);
                   // Readarray(text, number);
                    i += Arraycount(text); i += number.ToString().Length + 2;
                    az += i;
                    n++;
                }
            }
            StandartRead(list, n,filename);
            Copyfile2(filename,len) ;
        }

        public void Yaz(Doctor[]? doctors,string filename)
        {
            using FileStream fs = new FileStream(filename + ".bin", FileMode.Create, FileAccess.Write);
            using BinaryWriter br = new BinaryWriter(fs);
            foreach (var item in doctors)
            {
                br.Write(item.Name);
                br.Write(item.Surname);
                br.Write(item.Gender);
                br.Write(item.Age);
                br.Write(item.Work);
                foreach (var item2 in item.Time ) br.Write(item2);
                br.Write(item.date);
                
            }
        }
        public void ReadUser(string filename)
        {
            using FileStream fs = new FileStream(filename + ".bin", FileMode.Open, FileAccess.Read);
            using BinaryReader br = new BinaryReader(fs);
            Console.WriteLine(fs.Length);
            for (int i = 0; i < fs.Length;)
            {
                string[] text = new string[5];
                text[0] = br.ReadString();text[1] = br.ReadString();
                text[2] = br.ReadString();
                int number = br.ReadInt32();
                text[3] = br.ReadString();
                text[4] = br.ReadString();
                //if (text[0] == "Nihad") Readarray(text,number);
                //Readarray(text,number);
                i += Arraycount(text); i += number.ToString().Length + 2;
            }
        }
        public void WriteUser(User[]? user, string filename)
        {
            using FileStream fs = new FileStream(filename + ".bin", FileMode.Append, FileAccess.Write);
            using BinaryWriter br = new BinaryWriter(fs);
            foreach (var item in user)
            {
                br.Write(item.Name);br.Write(item.Surname);
                br.Write(item.Gender);br.Write(item.Age);
                br.Write(item.Email);br.Write(item.Phone);
            }
        }

    }
}

