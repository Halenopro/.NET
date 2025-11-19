using System;
class Program
{
    static void Main(string[] args)
    {
        int [,] a = new int[3, 4];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"{a[i, j]} ");
            }
        }

    }
}