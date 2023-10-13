using System; 

public class gebouw
{
    public int links;
    public int hoogte;
    public int rechts;

    public gebouw(int l, int h, int r)
    {
        this.links = l;
        this.hoogte = h;
        this.rechts = r;
    }
}

public class strook
{
    public int x;
    public int h;
    public strook(int x1, int h1) 
    { 
        this.x = x1;
        this.h = h1;
    }
}

public static class hi
{
    public static List<strook> merge(List<strook> a, List<strook> b)
    {
        int i = 0, j = 0;
        int h1 = 0, h2 = 0;
        int maxh = 0;
        List<strook> merged = new List<strook>();

        while (i < a.Count && j < b.Count) 
        { 
            if (a[i].x < b[j].x)
            {
                h1 = a[i].h;
                maxh = Math.Max(h1, h2);
                merged.Add(new strook(a[i].x, maxh));
                i++;
            }
            else if (a[i].x > b[j].x)
            {
                h2 = b[j].h;
                maxh = Math.Max(h1, h2);
                merged.Add(new strook(b[j].x, maxh));
                j++;
            }
            else  
            {
                maxh = Math.Max(a[i].h, b[j].h);
                i++;
                j++;
            }

            if (merged.Count == 0 || maxh != merged[merged.Count-1].h)
            {
                merged.Add(new strook(a[i].x, maxh));
            }
        }
        while (i < a.Count)
        {
            merged.Add(a[i]);
            i++;
        }
        while (j < b.Count)
        {
            merged.Add(b[j]);
            j++;
        }
        return merged;
    }
     
    public static List<strook> mergesort(List<gebouw> a, int p, int r) 
    {
        if (p == r)
        {
            strook strk1 = new strook(a[0].links, a[0].hoogte);
            strook strk2 = new strook(a[0].rechts, 0);
            return new List<strook> { strk1, strk2 };
        }
        int q = (p+r)/2;
        List<strook> left = mergesort(a, p, q);
        List<strook> right = mergesort(a, q + 1, r);
        return merge(left, right);
    }

    public static void Main()
    {
        string[] ninput = Console.ReadLine().Split(' ');
        int n = int.Parse(ninput[0]);
        List<gebouw> gebouwen = new List<gebouw>();

        int i = 0;
        while (i < n)
        {
            string[] gebouwinput = Console.ReadLine().Split(' ');
            int l = int.Parse(gebouwinput[0]);
            int h = int.Parse(gebouwinput[1]);
            int r = int.Parse(gebouwinput[2]);
            gebouwen.Add(new gebouw(l, h, r));
            i++;
        }
        List<strook> stroken = mergesort(gebouwen, 0, gebouwen.Count - 1);
        Console.WriteLine(stroken.Count);
        foreach (var strook in stroken) 
        {
            Console.WriteLine($"{strook.x} {strook.h}");
        }
    }
}