using static System.Char;

var input = File.ReadAllText("input.txt");

var expectingChar = 'm';
var expectingLeftDigit = false;
var inDigit = false;
var expectingRightDigit = false;
var left = 0;
var right = 0;

var count = input.ToCharArray().Aggregate(0, (current, c) =>
{
    if (c == expectingChar)
    {
        switch (expectingChar)
        {
            case 'm':
                expectingChar = 'u';
                break;
            case 'u':
                expectingChar = 'l';
                break;
            case 'l':
                expectingChar = '(';
                break;
            case '(':
                expectingLeftDigit = true;
                break;
            case ',':
                expectingLeftDigit = false;
                inDigit = false;
                expectingRightDigit = true;
                break;
            case ')':
                var val = left * right;
                Console.WriteLine($"Multiplying {left} and {right}");
                expectingLeftDigit = false;
                expectingRightDigit = false;
                inDigit = false;
                left = 0;
                right = 0;
                expectingChar = 'm';
                return current + val;
        }
    } else if ((expectingLeftDigit || expectingRightDigit) && IsNumber(c))
    {
        var val =int.Parse(c.ToString());
        if (expectingLeftDigit)
        {
            expectingChar = ',';

            if (inDigit)
            {
                left = (left * 10) + val;
            }
            else
            {
                left = val;
            }
            
            inDigit = true;
        } else if (expectingRightDigit)
        {
            expectingChar = ')';
            
            if (inDigit)
            {
                right = (right * 10) + val;
            }
            else
            {
                right = val;
            } 
            inDigit = true;
        }
    }
    else
    {
        
        expectingLeftDigit = false;
        expectingRightDigit = false;
        inDigit = false;
        left = 0;
        right = 0;
        expectingChar = 'm';
    }

    return current;
});

Console.WriteLine(count);