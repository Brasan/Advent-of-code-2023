string[] fileLines = File.ReadAllLines("input.txt");
int total = 0;
int[] digits = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
Dictionary<string, string> digitConversonTable = new()
{
    {"one", "o1e"}, {"two", "t2o"}, {"three", "t3e"},
    {"four", "4"}, {"five", "5e"}, {"six", "6"},
    {"seven", "7n"}, {"eight", "e8t"}, {"nine", "n9e"}
};

foreach (var line in fileLines)
{
    string convertedLine = digitConversonTable.Aggregate(line, (current, lookup)
        => current.Replace(lookup.Key, lookup.Value));
    total += GetDigits(convertedLine);
}

Console.WriteLine(total);
return;


int GetDigits(string line)
{
    int first = -1;
    int second = -1;
    foreach (char c in line)
    {
        if (char.IsNumber(c))
        {
            if (first == -1)
            {
                first = int.Parse(c.ToString());
                continue;
            }
            second = int.Parse(c.ToString());
        }
    }
    if (second == -1)
    {
        return first * 10 + first;
    }
    return first * 10 + second;
}