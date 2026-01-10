using System;
using System.Collections.Generic;

namespace Q1
{
    class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }

    class PersonImplementation
    {
        public void GetName(IList<Person> p)
        {
            foreach (var x in p)
                Console.Write(x.Name + " " + x.Address + " ");
            Console.WriteLine();
        }

        public void Average(IList<Person> p)
        {
            double sum = 0;
            foreach (var x in p)
                sum += x.Age;

            double avg = sum / p.Count;
            Console.WriteLine(avg);
        }

        public void Max(IList<Person> p)
        {
            int max = p[0].Age;
            foreach (var x in p)
                if (x.Age > max)
                    max = x.Age;

            Console.WriteLine(max);
        }
        public void Second(IList<Person> p){
            int max = p[0].Age;
            int second=p[0].Age;
            foreach( var x in p){
                if (x.Age>max){
                    max=x.Age;
                }else if(x.Age > second &&  x.Age <max){
                    second=x.Age;
                }
            }
            Console.WriteLine(second);

        }
    }

    class Program
    {
        static void Main()
        {
            IList<Person> p = new List<Person>();
            p.Add(new Person { Name = "Aarya", Address = "A2101", Age = 69 });
            p.Add(new Person { Name = "Daniel", Address = "D104", Age = 40 });
            p.Add(new Person { Name = "Ira", Address = "H801", Age = 25 });
            p.Add(new Person { Name = "Jennifer", Address = "I1704", Age = 33 });
            PersonImplementation obj = new PersonImplementation();
            obj.GetName(p);
            obj.Average(p);
            obj.Max(p);
            obj.second(p);
            Console.ReadLine();
        }
    }
}
