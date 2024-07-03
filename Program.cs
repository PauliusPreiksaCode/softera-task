
using Games.Entities;
using Games.Utils;

const string dataFilepath = "../../../Data/Game1.txt";
const string resultFilepath = "../../../Data/Game1result.txt";
string rootFolderPath = Directory.GetCurrentDirectory();

try
{
    List<Person> players = IOUtils.ReadDataFromFile(Path.Combine(rootFolderPath, dataFilepath));
    Dictionary<int, int> gameCategoryScores = CalculationUtils.CalculateGameCategoryScores(players);
    int minScoreCategory = CalculationUtils.FindMinScoreCategory(gameCategoryScores);
    int maxScoreCategory = CalculationUtils.FindMaxScoreCategory(gameCategoryScores);
    IOUtils.PrintResults(gameCategoryScores, minScoreCategory, maxScoreCategory, Path.Combine(rootFolderPath, resultFilepath));
}
catch (Exception ex)
{
    string errorMessage = ex.Message switch
    {
        "Invalid player count" => "Game not counted, not enough players",
        "Invalid game category" => "Game not counted, wrong category",
        _ => "An unexpected error occurred"
    };

    IOUtils.PrintError(errorMessage, Path.Combine(rootFolderPath, resultFilepath));
}




