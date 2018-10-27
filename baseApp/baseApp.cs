using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace baseApp
{
    class baseApp
    {
        static void Main(string[] args)
        {
            string path = @"E:\AcademyBase\BASE\1.csv";
            StreamReader reader = new StreamReader(path);
            int id = 0;
            List<int> ID = new List<int>();
            List<string> name = new List<string>();
            List<string> email = new List<string>();
            List<string> phone = new List<string>();
            bool havePhone = false;
            while (!reader.EndOfStream)
            {
                string[] splits = reader.ReadLine().Split(',');
                ID.Add(id);
                name.Add(splits[0]);
                email.Add(splits[1]);
                phone.Add(splits[2]);

                if (splits.Length > 2)
                {
                    phone.Add(splits[2]);
                    havePhone = true;
                }
                id++;
            }
            for (int i = 0; i < id - 1; i++)
            {
                if (havePhone)
                {
                    Console.WriteLine($"ID : {ID[i]} , name : {name[i]} , email : {email[i]}, phone : {phone[i]}");
                }
                else
                {
                    Console.WriteLine($"ID : {ID[i]} , name : {name[i]} , email : {email[i]}");
                }
            }
        }
    }
}
