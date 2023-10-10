class hi
{
    public static void Main()
    {
        string[] ninput = Console.ReadLine().Split(' ');
        int n = int.Parse(ninput[0]);

        int i = 0;
        while (i < n)
        {
            string[] gebouwinput = Console.ReadLine().Split(' ');
            int l = int.Parse(gebouwinput[0]);
            int h = int.Parse(gebouwinput[1]);
            int r = int.Parse(gebouwinput[2]);
            i++;
        }

        Console.WriteLine();
    }
}