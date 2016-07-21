using System;

public class Program
{
    private const int REFRESH_RATE_MS = 1000;
    public static void Main(string[] args)
    {
        RunTests();
        Console.WriteLine("Tests complete. Press something to continue.");
        Console.ReadLine();

        var grid = new Grid(height: 10, width: 10);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now);

            // grid.MoveSnake();
            Console.WriteLine(grid.Render());

            // Console.WriteLine("Press and key to move snake.");
            // Console.ReadLine();

            System.Threading.Thread.Sleep(REFRESH_RATE_MS);
        }
    }

    public static void RunTests()
    {
        var height = 3;
        var width = 3;

        var grid = Grid.TestTheGrid(width, height);
        Console.WriteLine(Convert.ToInt16(grid[0, 1]) == 1);
        Console.WriteLine(Convert.ToInt16(grid[0, 2]) == 2);

        Console.WriteLine(Convert.ToInt16(grid[1, 1]) == 4);
        Console.WriteLine(Convert.ToInt16(grid[1, 2]) == 5);
    }
}
