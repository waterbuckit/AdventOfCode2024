var lines = File.ReadAllLines("input.txt");

var safeCount = lines
    .Select(x => x.Split(' ').Select(int.Parse).ToList())
    .Count(IsSafe);

Console.WriteLine(safeCount);

bool IsSafe(List<int> levels)
{
    for (var i = 1; i < levels.Count; i++)
    {
        // range check
        if (Math.Abs(levels[i - 1] - levels[i]) is < 1 or > 3) return false;
    }

    // check it's equal if ordering 
    return levels.SequenceEqual(levels.OrderBy((x) => x)) || levels.SequenceEqual(levels.OrderByDescending((x) => x));
}