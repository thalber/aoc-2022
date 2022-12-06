using System.Runtime.CompilerServices;
using System.Security.Cryptography;

string[] lines = File.ReadAllLines(args[0]);
char[] items = EnumerateAllItems().ToArray();

int sum = 0;

foreach (var line in lines)
{
    if (line.Length % 2 is not 0) throw new InvalidDataException();
    int split = line.Length / 2;
    for (int i = 0; i < split; i++)
    {
        for (int j = split; j < line.Length; j++)
        {
            if (line[i] == line[j]) { sum += Prio(line[i]); goto fwomp; }

        }
    }
fwomp:
    continue;
}

Console.WriteLine(sum);
Console.ReadKey();

int Prio(char c)
{
    return c switch
    {
        >= 'A' and <= 'Z' => c - 'A' + 27,
        >= 'a' and <= 'z' => c - 'a' + 1,
        _ => throw new ArgumentException(),
    };
}
IEnumerable<char> EnumerateAllItems()
{
    for (char i = 'A'; i <= 'Z'; i++) yield return i;
    for (char i = 'a'; i <= 'z'; i++) yield return i;
}