// read file
var fileString = File.ReadAllText("input.txt");
var lines = fileString.Split('\n');

var (list1, list2) = lines.Aggregate((new List<int>(), new List<int>()), (tuple, s) =>
{
    var split = s.Split("   ");
    
    tuple.Item1.Add(int.Parse(split[0]));
    tuple.Item2.Add(int.Parse(split[1]));
    
    return tuple;
});

// sort lists 
var sortedList1 = list1.OrderBy(x => x).ToList();
var sortedList2 = list2.OrderBy(x => x).ToList();

// calculate the sum of absolute differences
var sum = sortedList1
    .Zip(sortedList2, (a, b) => Math.Abs(a - b))
    .Sum();
    
Console.WriteLine(sum);