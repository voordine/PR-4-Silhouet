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
    public static List<strook> merge(List<gebouw> a, int p, int q, int r)
    {
        int nl = q - p + 1;
        int nr = r - q;
        gebouw[] L = new gebouw[nl-1];
        gebouw[] R = new gebouw[nr-1];
        int i, j, k;
        k = p;
        List<strook> merged = new List<strook>();

        for (i = 0; i < nl; ++i) { L[i] = a[p+i]; }
        for (j = 0; j < nr; ++j) { R[j] = a[p+j+1]; }

        i = 0;
        j = 0;

        while (i < nl && j < nr) 
        { 
            if (L[i].links <= R[j].links)
            {
                a[k] = L[i];
                i++;
            }
            else
            {
                a[k] = R[j];
                j++;
            }
            k++;
        }
        while (i < nl)
        {
            a[k] = L[i];
            i++;
            k++;
        }
        while (j < nr)
        {
            a[k] = R[j];
            j++;
            k++;
        }
        return merged;
    }
     
    public static List<strook> mergesort(List<gebouw> a, int p, int r) 
    {
        if (a.Count == 1)
        {
            strook strk1 = new strook(a[0].links, a[0].hoogte);
            strook strk2 = new strook(a[0].rechts, 0);
            return new List<strook> { strk1, strk2 };
        }
        int q = (p+r)/2;
        mergesort(a, p, q);
        mergesort(a, q + 1, r);
        return merge(a, p, q, r);
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
        List<strook> result = mergesort(gebouwen, 0, gebouwen.Count - 1);
        Console.WriteLine(result.Count);
        foreach (var strook in result) 
        {
            Console.WriteLine($"{strook.x} {strook.h}");
        }
    }
}