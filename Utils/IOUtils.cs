using Games.Entities;
using System.Text;

namespace Games.Utils
{
    public static class IOUtils
    {
        public static List<Person> ReadDataFromFile(string path)
        {
            List<Person> players = new List<Person>();

            string[] Lines = File.ReadAllLines(path, Encoding.UTF8);
            int playerCount = int.Parse(Lines[0]);

            if (playerCount < 5 || playerCount > 20)
                throw new Exception("Invalid player count");

            for(int i = 1; i < Lines.Length; i++)
            {
                string[] Values = Lines[i].Split(' '); 
                int gameCategory = int.Parse(Values[0]);

                if (gameCategory < 1 || gameCategory > 10)
                    throw new Exception("Invalid game category");

                int[] points = new int[5];

                for(int j = 0; j < 5;j++)
                {
                    points[j] = int.Parse(Values[j+1]);
                }

                Person person = new Person
                {
                    GameCategory = gameCategory,
                    Points = points
                };

                players.Add(person);
            }

            return players;
        }

        public static void PrintResults(Dictionary<int, int> gameCategoryPoints, int minScoreCategory, int maxScoreCategory, string filepath)
        {
            string[] Lines = new string[12];
            for(int i = 0; i < Lines.Length; i++)
            {
                int points = gameCategoryPoints.ContainsKey(i + 1) ? gameCategoryPoints[i + 1] : 0;

                Lines[i] = string.Format($"{i + 1} {points}");
            }
            Lines[10] = $"Maximum score category: {maxScoreCategory}";
            Lines[11] = $"Minimum score category: {minScoreCategory}";

            File.WriteAllLines(filepath, Lines, Encoding.UTF8);
        }

        public static void PrintError(string message, string filepath)
        {
            File.WriteAllText(filepath, message, Encoding.UTF8);
        }
    }
}
