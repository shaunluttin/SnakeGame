using System;

public class Program
{
    private const int REFRESH_RATE_MS = 1000;
    public static void Main(string[] args)
    {
        var grid = new Grid(height:30, width:100);

        while (true)
        {
            Console.WriteLine(DateTime.Now); 
            Console.WriteLine(grid.GetTheBigGridString());
            System.Threading.Thread.Sleep(REFRESH_RATE_MS);
            Console.Clear();
        }
    }
}
