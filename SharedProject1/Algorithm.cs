using SharedProject1.Models;

namespace SharedProject1
{
    public delegate void onTriggerTlMessage(string name);
    public class Algorithm
    {
        //Задано значение по умолчанию, для случая если нет другого файла для теста
        static string[]? FileReading(string filePath = "../../../sequence.txt")
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("FileError");
                return null;
            }
            string[] sequence = File.ReadAllLines(filePath);
            return sequence;
        }

        public static void ChatSimulate()
        {
            string[]? sequence = FileReading();
            int personCount = 0;
            if (sequence != null)
            {
                personCount = Array.FindAll(sequence, x => x.Contains(' ')).Length;
            }
            else
            {
                return;
            }
            string[] roles = { "User", "Junior", "Middle", "Senior", "TL" };
            int[] roleCounts = new int[roles.Length]; //используем для подсчёта кол-ва юзеров, джунов и тд.
            for (int i = 0; i < roles.Length; i++)
            {
                roleCounts[i] = Array.FindAll(sequence, x => x.Contains(roles[i])).Length;
            }
            User[] users = new User[roleCounts[0]];
            Junior[] juniors = new Junior[roleCounts[1]];
            Middle[] middles = new Middle[roleCounts[2]];
            Senior[] seniors = new Senior[roleCounts[3]];
            TeamLead[] leads = new TeamLead[roleCounts[4]];

            Array.Clear(roleCounts, 0, roleCounts.Length); //очищаем, а затем повторно используем для индексации массивов экземпляров классов
            string[] person = new string[2];

            for (int i = 0; i < personCount; i++) //создание экземпляра классов
            {
                person = sequence[i].Split(' ');
                switch (person[1])
                {
                    case "User":
                        users[roleCounts[0]] = new User(person[0]);
                        roleCounts[0]++;
                        break;
                    case "Junior":
                        juniors[roleCounts[1]] = new Junior(person[0]);
                        roleCounts[1]++;
                        break;
                    case "Middle":
                        middles[roleCounts[2]] = new Middle(person[0]);
                        roleCounts[2]++;
                        break;
                    case "Senior":
                        seniors[roleCounts[3]] = new Senior(person[0]);
                        roleCounts[3]++;
                        break;
                    case "TL":
                        leads[roleCounts[4]] = new TeamLead(person[0]);
                        roleCounts[4]++;
                        break;

                }
            }
            for (int i = 0; i < juniors.Length; i++)
            {
                for (int j = 0; j < seniors.Length; j++)
                {
                    juniors[i].TriggerJuniorMessage += seniors[j].RaiseFlag;
                }
            }

            for (int i = 0; i < middles.Length; i++)
            {
                for (int j = 0; j < seniors.Length; j++)
                {
                    middles[i].TriggerMiddleMessage += seniors[j].RaiseFlag;
                }
            }

            for (int i = 0; i < seniors.Length; i++)
            {
                for (int j = 0; j < middles.Length; j++)
                {
                    seniors[i].TriggerSeniorMessage += middles[j].RaiseFlag;
                }
            }

            for (int i = 0; i < juniors.Length; i++)
            {
                for (int j = 0; j < leads.Length; j++)
                {
                    juniors[i].TriggerJuniorMessage += leads[j].RaiseFlag;
                }
            }

            for (int i = 0; i < middles.Length; i++)
            {
                for (int j = 0; j < leads.Length; j++)
                {
                    middles[i].TriggerMiddleMessage += leads[j].RaiseFlag;
                }
            }
            onTriggerTlMessage? setName = null;
            for (int i = 0; i < leads.Length; i++)
            {
                setName += leads[i].SetTriggerName;
            }
            Array.Clear(roleCounts, 0, roleCounts.Length); //обнуляем индексаторы
            for (int i = 0; i < personCount; i++) //здесь происходит общение
            {
                person = sequence[i].Split(' ');
                switch (person[1])
                {
                    case "User":
                        users[roleCounts[0]].Talk();
                        roleCounts[0]++;
                        break;
                    case "Junior":
                        juniors[roleCounts[1]].Talk();
                        setName(person[0]);
                        roleCounts[1]++;
                        break;
                    case "Middle":
                        middles[roleCounts[2]].Talk();
                        setName(person[0]);
                        roleCounts[2]++;
                        break;
                    case "Senior":
                        seniors[roleCounts[3]].Talk();
                        roleCounts[3]++;
                        break;
                    case "TL":
                        leads[roleCounts[4]].Talk();
                        roleCounts[4]++;
                        break;
                }
            }
        }
    }
}
