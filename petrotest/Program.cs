using System;
using SharedProject1.Models;
using System.IO;
using System.Text;
using System.Reflection.Metadata;

namespace petrotest
{
    public class Program
    {
        //Задано значение по умолчанию, для случая если нет другого файла для теста
        static string[] FileReading(string filePath = "../../../sequence.txt")
        {
            if(!File.Exists(filePath))
            {
                Console.WriteLine("FileError");
                return null;
            }
            string[] sequence = File.ReadAllLines(filePath);
            return sequence;
        }

        static void Main(string[] args)
        {
            string[] sequence = FileReading();
            int personCount = Array.FindAll(sequence, x => x.Contains(' ')).Length;
            Console.WriteLine($"PersonCount: {personCount}");
            string[] roles = { "User", "Junior" };
            int[] roleCounts = new int[roles.Length]; //используем для подсчёта кол-ва юзеров, джунов и тд.
            for (int i = 0; i < roles.Length; i++)
            {
                roleCounts[i] = Array.FindAll(sequence, x => x.Contains(roles[i])).Length;
                Console.WriteLine($"ROLE COUNTS {roleCounts[i]}");
            }
            User[] users = new User[roleCounts[0]];
            Junior[] juniors = new Junior[roleCounts[1]];
           
            Array.Clear(roleCounts,0, roleCounts.Length); //очищаем, а затем повторно используем для индексации массивов экземпляров классов
            string[] person = new string[2];
 
            for(int i = 0; i < personCount; i++)
            {
                person = sequence[i].Split(' ');
                switch (person[1])
                {
                    case "User":
                        users[roleCounts[0]] = new User(person[0]);
                        users[roleCounts[0]].Talk();
                        roleCounts[0]++;
                        break;
                    case "Junior":
                        juniors[roleCounts[1]] = new Junior(person[0]);
                        juniors[roleCounts[1]].Talk();
                        roleCounts[1]++;
                        break;
                }
            }
        }
    }
}