using System;

public class Program
{
    private const int REFRESH_RATE_MS = 1000;
    public static void Main(string[] args)
    {
        RunTests();

        var grid = new Grid(height: 10, width: 10);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(grid.GetTheBigGridString());
            System.Threading.Thread.Sleep(REFRESH_RATE_MS);
        }
    }

    public static void RunTests()
    {
        var height = 3;
        var width = 3;

        var grid = Grid.BuildTheGrid(width, height);
        Console.WriteLine(Convert.ToInt16(grid[0, 1]) == 1);
        Console.WriteLine(Convert.ToInt16(grid[0, 2]) == 2);

        Console.WriteLine(Convert.ToInt16(grid[1, 1]) == 4);
        Console.WriteLine(Convert.ToInt16(grid[1, 2]) == 5);
    }
}
