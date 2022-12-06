// See https://aka.ms/new-console-template for more information
string[] lines = File.ReadAllLines(args[0]);
int score = 0;
for (int i = 0; i < lines.Length; i++)
{
    string[] spl = lines[i].Split(new char[] { ' ' });
    RES result = spl[1] switch
        {
            "X" => RES.loss,
            "Y" => RES.draw,
            "Z" => RES.win,
            _ => throw new ArgumentException(),
        };
    RPS
        opps = spl[0] switch
        {
            "A" => RPS.rock,
            "B" => RPS.paper,
            "C" => RPS.scissors,
            _ => throw new ArgumentException(),
        }, 
        your = respond(opps, result);
    score += your switch
    {
        RPS.rock => 1,
        RPS.paper => 2,
        RPS.scissors => 3,
        _ => throw new InvalidOperationException(),
    };
    score += result switch
    {
        RES.win => 6,
        RES.draw => 3,
        RES.loss => 0,
        _ => throw new InvalidOperationException(),
    };
}
Console.WriteLine(score);
Console.ReadKey();

RPS respond(RPS other, RES desired)
{
    int sum = (int)other + (int)desired;
    return (RPS)(sum switch
    {
        -1 => 2,
        3 => 0,
        _ => sum,
    });
}
enum RPS
{
    rock = 0,
    paper = 1,
    scissors = 2
}
enum RES
{
    win = 1,
    draw = 0,
    loss = -1
}