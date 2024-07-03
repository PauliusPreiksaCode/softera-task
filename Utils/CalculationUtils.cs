using Games.Entities;

namespace Games.Utils
{
    internal class CalculationUtils
    {
        public static Dictionary<int, int> CalculateGameCategoryScores(List<Person> players)
        {
            Dictionary<int, int> categoryScores = new Dictionary<int, int>();
            players.ForEach(player => 
            {
                player.AllPoints = player.Points.Sum();

                if (categoryScores.ContainsKey(player.GameCategory))
                {
                    categoryScores[player.GameCategory] += player.AllPoints;
                }
                else
                {
                    categoryScores.Add(player.GameCategory, player.AllPoints);
                }
            });

            return categoryScores;
        }

        public static int FindMaxScoreCategory(Dictionary<int, int> categoryScores)
        {
            (int, int) maxScoreCategory = (0, 0);
            foreach (var item in categoryScores)
            {
                if(item.Value > maxScoreCategory.Item2)
                {
                    maxScoreCategory.Item1 = item.Key;
                    maxScoreCategory.Item2 = item.Value;
                }
            }

            return maxScoreCategory.Item1;
        }

        public static int FindMinScoreCategory(Dictionary<int, int> categoryScores)
        {
            (int, int) minScoreCategory = (0, Int32.MaxValue);
            foreach (var item in categoryScores)
            {
                if (item.Value < minScoreCategory.Item2)
                {
                    minScoreCategory.Item1 = item.Key;
                    minScoreCategory.Item2 = item.Value;
                }
            }

            return minScoreCategory.Item1;
        }
    }
}
