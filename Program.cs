using System;

public class Program
{
    private const int REFRESH_RATE_MS = 100;
    public static void Main(string[] args)
    {
        var grid = new Grid(height: 20, width: 20);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now);

            grid.MoveSnake();
            Console.WriteLine(grid.Render());

            System.Threading.Thread.Sleep(REFRESH_RATE_MS);
        }
    }
}
