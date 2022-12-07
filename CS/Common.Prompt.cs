using System;
using System.Linq;

public static class prompt
{
	public static bool ask(string prompt)
	{
		//Console.Write($"\n{prompt} > ");
		return que(prompt, "y", "yes", "1", "n", "no", "0") is "y" or "yes" or "1";
	}
	public static string que(string prompt, params string[] options){
		Console.WriteLine($"{prompt}" + $"({(
			options.Length is 0 
			? string.Empty 
			: options.Aggregate((x, y) => $"{x}/{y}"))})");

		string @in = string.Empty;
		while (!options.Contains(@in = Console.ReadLine() ?? string.Empty)){
			Console.WriteLine("Invalid input!");
		};
		return @in;
	}
}
