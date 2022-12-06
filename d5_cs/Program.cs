using TXR = System.Text.RegularExpressions;

string[] lines = File.ReadAllLines(args[0]);
bool t2 = prompt.ask("d5cs: task 2?");

string[] initstack = lines.TakeWhile(l => l.Length > 1).ToArray();

//Console.WriteLine(initstack.Aggregate((x, y) => $"{x}\n{y}"));

List<Stack<char>> stacks = new();

Stack<char> buff = new();

for (int col = 1; col < initstack[0].Length; col += 4)
{
    Stack<char> res = new();
    for (int row = initstack.Length - 1; row >= 0; row--)
    {
        if (initstack[row][col] is not ' ')
        {
            res.Push(initstack[row][col]);
            Console.Write(initstack[row][col]);
        }
        else break;
    }
    Console.WriteLine();
    stacks.Add(res);
}

for (int i = initstack.Length; i < lines.Length; i++)
{
    var spl = TXR.Regex.Match(lines[i], "move (\\d+) from (\\d+) to (\\d+)");
    if (!spl.Success)
    {
        Console.WriteLine($"invalid string {i} {lines[i]}");
        continue;
    }
    int 
        amount = int.Parse(spl.Groups[1].Value), 
        from = int.Parse(spl.Groups[2].Value) - 1, 
        to = int.Parse(spl.Groups[3].Value) - 1;
    if (t2)
    {
        buff.Clear();
        for (int c = 0; c < amount; c++)
        {
            buff.Push(stacks[from].Pop());
        }
        while (buff.TryPop(out char ch))
        {
            stacks[to].Push(ch);
        }
    }
    else
    {
        for (int c = 0; c < amount; c++)
        {
            stacks[to].Push(stacks[from].Pop());
        }
    }
}

Console.WriteLine("------");
foreach (var st in stacks)
{
    Console.Write(st.Peek());
}
Console.WriteLine();
Console.ReadKey();
