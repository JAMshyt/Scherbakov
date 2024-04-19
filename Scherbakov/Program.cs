using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scherbakov
{
    class Program
    {

        class Subject
        {
            public string Title;
            public int Semester;
            public string FormAttest;
        }

        class SubjectControl
        {
            public Subject[] Sort(Subject[] subjects)
            {
                return subjects.OrderBy(f => f.FormAttest).ThenBy(t => t.Title).ToArray();
            }

            public void WriteInfile(Subject[] subjects)
            {
                using (StreamWriter writer = new StreamWriter("..//..//..//result.txt",false))
                {
                    foreach (var i in subjects) 
                    {
                        writer.WriteLine(i.Title+" "+i.Semester+" "+i.FormAttest);
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            int count;
            for (; true;)
            {
                try
                {
                    Console.Write("Введите количеств предметов:");
                    count = Convert.ToInt32(Console.ReadLine());
                    if (count > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Количество должно быть больше нуля, попробуйте заново");
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка, только целое число, попробуйте снова");
                }
            }
            Console.WriteLine();
            Subject[] subjects = new Subject[count];

            for (int i = 0; i < count; i++)
            {
                subjects[i] = new Subject();
                Console.Write("Введите название " + (i + 1) + " предмета:");
                subjects[i].Title = Console.ReadLine();

                for (; true;)
                {
                    try
                    {
                        Console.Write("Введите семестр " + (i + 1) + " предмета:");
                        subjects[i].Semester = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("\nСеместр должен быть цифрой, попробуйте ещё\n");
                    }
                }

                Console.Write("Введите форму аттестации " + (i + 1) + " предмета:");
                subjects[i].FormAttest = Console.ReadLine();
                Console.WriteLine();
            }

            SubjectControl contoller = new SubjectControl();
            contoller.WriteInfile(contoller.Sort(subjects));


            foreach (var i in contoller.Sort(subjects))
            {
                Console.WriteLine(i.Title + " " + i.Semester + " " + i.FormAttest);
            }
        }
    }
}
