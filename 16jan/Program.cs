using System;
class Program{
    public static void Main()
    {
        int[] scores=[97,92,81,60];
        var scoreQ=
        from score in scores
        where score >80
        select score;

        foreach (var i in scoreQ)
        {
            Console.WriteLine(i);
        }
    }
}