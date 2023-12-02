using System.Text.RegularExpressions;

const int MAX_RED = 12;
const int MAX_GREEN = 13;
const int MAX_BLUE = 14;

var idSum = 0;
var minSetPowerSum = 0;
var gameId = 0;

string[] fileLines = File.ReadAllLines("input.txt");

foreach (string game in fileLines)
{
    gameId++;

    var gameFailed = false;
    var highestRed = 0;
    var highestGreen = 0;
    var highestBlue = 0;

    string cleanedGame = Regex.Replace(game, @"(Game \d+: )", "");

    foreach (string cubeReveal in cleanedGame.Split(';'))
    {
        foreach (string singleCubeReveal in cubeReveal.Split(','))
        {
            if (string.IsNullOrWhiteSpace(singleCubeReveal)) continue;

            if (singleCubeReveal.Contains("red"))
            {
                int currentRed = int.Parse(Regex.Match(singleCubeReveal, @"(\d+)").Groups[1].Value);
                if (currentRed > MAX_RED) gameFailed = true;
                if (currentRed > highestRed) highestRed = currentRed;
            }
            else if (singleCubeReveal.Contains("green"))
            {
                int currentGreen = int.Parse(Regex.Match(singleCubeReveal, @"(\d+)").Groups[1].Value);
                if (currentGreen > MAX_GREEN) gameFailed = true;
                if (currentGreen > highestGreen) highestGreen = currentGreen;
            }
            else if (singleCubeReveal.Contains("blue"))
            {
                int currentBlue = int.Parse(Regex.Match(singleCubeReveal, @"(\d+)").Groups[1].Value);
                if (currentBlue > MAX_BLUE) gameFailed = true;
                if (currentBlue > highestBlue) highestBlue = currentBlue;
            }
        }
    }
    minSetPowerSum += highestBlue * highestGreen * highestRed;
    if (gameFailed) continue;

    idSum += gameId;
}

Console.WriteLine($"Total id sum is {idSum}");
Console.WriteLine($"Sum of all set powers is {minSetPowerSum}");