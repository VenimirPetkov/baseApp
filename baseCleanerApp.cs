using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baseCleanerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string readPath = @"E:\AcademyBase\BASE\1.csv";
            string writePath = @"E:\AcademyBase\BASE\out.csv";
            StreamReader reader = new StreamReader(readPath);
            StreamWriter writer = new StreamWriter(writePath);
            int id = 0;
            List<int> ID = new List<int>();
            List<string> name = new List<string>();
            List<string> email = new List<string>();
            List<string> phone = new List<string>();
            List<string> line = new List<string>();
            List<string> clenedEmails = new List<string>();
            List<string> cleanedData = new List<string>();
            List<string> final = new List<string>();
            while (!reader.EndOfStream)
            {
                string[] splits = reader.ReadLine().Split(',');
                ID.Add(id);
                name.Add(splits[0]);
                email.Add(splits[1]);
                phone.Add(splits[2]);
                id++;
            }
            for (int i = 0; i < id - 1; i++)
            {
                line.Add($"{name[i]},{email[i]},{phone[i]}");
            }
            line.Sort();
            email.Sort();
            clenedEmails = RemoveDuplicatesIterative(email);
            for (int m = 0; m < clenedEmails.Count(); m++)
            {
                string em = clenedEmails[m];
                Student stud = new Student(em);
                students.Add(stud);
            }
            students = addInfo(students, line);
            students.ForEach(e => e.getInfo());
            students.ForEach(s => writer.WriteLine(s.ToString()));
        }

        public static List<Student> addInfo(List<Student> stud, List<string> list)
        {
            for (int i = 0; i < stud.Count(); i++)
            {
                string studName = stud[i].Name;
                string studEmail = stud[i].Email;
                string studPhone = stud[i].Phone;
                for (int m = 0; m < list.Count(); m++)
                {
                    string[] split = list[m].Split(',');
                    if (split[1] == studEmail)
                    {
                        if (string.IsNullOrEmpty(studName) == true && split[0].Length > 0)
                        {
                            stud[i].Name = split[0];
                        }
                        if (string.IsNullOrEmpty(studPhone) == true && split[2].Length > 0)
                        {
                            stud[i].Phone = split[2];
                        }
                    }
                }
            }
            return stud;
        }

        public static List<string> RemoveDuplicatesIterative(List<string> items)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                // Assume not duplicate.
                bool duplicate = false;
                for (int z = 0; z < i; z++)
                {
                    if (items[z].Trim() == items[i].Trim())
                    {
                        // This is a duplicate.
                        duplicate = true;
                        break;
                    }
                }
                // If not duplicate, add to result.
                if (!duplicate)
                {
                    result.Add(items[i].Trim());
                }
            }
            return result;
        }
    }
}
