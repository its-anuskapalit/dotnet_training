using System;
using System.Collections.Generic;
using System.Linq;
public class Chromosome
{
    public List<int> Genes { get; set; }
    public int Fitness { get; set; }
    public Chromosome(List<int> genes)
    {
        Genes = genes;
        CalculateFitness();
    }
    public void CalculateFitness()
    {
        Fitness = Genes.Sum();
    }
    public Chromosome Crossover(Chromosome other)
    {
        List<int> newGenes = new List<int>();

        for (int i = 0; i < Genes.Count; i++)
        {
            if (i % 2 == 0)
                newGenes.Add(Genes[i]);
            else
                newGenes.Add(other.Genes[i]);
        }
        return new Chromosome(newGenes);
    }
    public void Mutate()
    {
        Random rand = new Random();
        int index = rand.Next(Genes.Count);
        Genes[index] = rand.Next(10);
        CalculateFitness();
    }
}
class Program
{
    static void Main()
    {
        Chromosome c1 = new Chromosome(new List<int> { 1, 2, 3, 4 });
        Chromosome c2 = new Chromosome(new List<int> { 5, 6, 7, 8 });
        Chromosome child = c1.Crossover(c2);
        child.Mutate();
        Console.WriteLine("Child Fitness: " + child.Fitness);
    }
}
