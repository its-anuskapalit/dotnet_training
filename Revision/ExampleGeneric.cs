using System;
namespace Generic2
{
    class Repository<T>
    {
        private List<T> data=new List<T>();
        public void Add(T item)
        {
            data.Add(item);
        }
        public List<T> Getall()
        {
            return data;
        }
    }
    class Student
    {
        public int Id;
        public string Name;
    }
    class Program
    {
        static void Main()
        {
            Repository<Student> repo=new Repository<Student>();
            repo.Add(new Student {Id=1, Name= "Anuska"}) ;
            repo.Add(new Student {Id=2, Name= "Polly"}) ;
            foreach(Student s in repo.Getall())
            {
                Console.WriteLine(s.Id + s.Name);
            }
        }
    }
}