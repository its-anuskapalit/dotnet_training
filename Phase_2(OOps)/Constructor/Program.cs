using System;

namespace ConstructorRuntime
{
    class Session
    {
        private readonly Guid id;
        private int actions;

        public Session() : this(Guid.NewGuid())
        {
        }

        public Session(Guid id)
        {
            this.id = id;
            actions = 0;
        }

        public void Record()
        {
            actions++;
        }

        public void Print()
        {
            Console.WriteLine($"Session {id} : {actions}");
        }
    }

    class Program
    {
        static void Main()
        {
            Session s1 = new Session();
            Track(s1);

            Session s2 = s1;
            s2.Record();

            s1.Print();
        }

        static void Track(Session session)
        {
            session.Record();
            session.Record();
        }
    }
}
