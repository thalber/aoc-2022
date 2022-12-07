using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

string[] lines = File.ReadAllLines(args[0]);
char[] items = EnumerateAllItems().ToArray();

int sum = 0;

for (int i = 0; i < lines.Length - 2; i += 3)
{
    //char? shared = null;
    string e1 = lines[i], e2 = lines[i + 1], e3 = lines[i + 2];
    foreach (char c in e1)
    {
        if (e2.IndexOf(c) is not -1 && e3.IndexOf(c) is not -1)
        {
            sum += Prio(c);
            goto done;
        }
    }
done:;
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