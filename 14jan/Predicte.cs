using System;
namespace PredicateDemo
{
    class Program
    {
        // ---------------------- Greeting Methods ----------------------
        static void GoodMorning()
        {
            Console.WriteLine($" Good Morning at {DateTime.Now}");
        }

        static void GoodNight()
        {
            Console.WriteLine($" Good Night at {DateTime.Now}");
        }
        static void Main()
        {
            // ---------------------- Predicate Example : Check Even ----------------------
            Predicate<int> isEven = n => n % 2 == 0;
            int number = 24;

            if (isEven(number))
                Console.WriteLine(number + " is Even");
            else
                Console.WriteLine(number + " is Odd");
            // ---------------------- Predicate Example : Check Divisibility ----------------------
            Predicate<int> isDivisible = n => n % 3 == 0;
            int n = 30;
            if (isDivisible(n))
                Console.WriteLine(n + " is divisible by 3");
            else
                Console.WriteLine(n + " is not divisible by 3");
            
            // ---------------------- Action Delegate : Assign Method at Runtime ----------------------
            Action logger;
            if (DateTime.Now.Hour < 12)
            {
                logger = GoodMorning;
            }
            else
            {
                logger = GoodNight;
            }
            logger();

            // ---------------------- Action Delegate : Salary Calculation ----------------------

            Action<int> Salary = salary =>
            {
                salary = salary * 5;
                Console.WriteLine($"[PAYOUT]: salary of person is {salary}");
            };
            Salary(10000);

            // ---------------------- Action Delegate : Table 1 to 10 ----------------------

            Action<int> table = x =>
            {
                for (int i = 1; i < 11; i++)
                {
                    Console.WriteLine($"{x} * {i} = {x * i}");
                }
            };
            table(2);
            // ---------------------- Action Delegate : Table 10 to 19 ----------------------
            table = x =>
            {
                for (int i = 10; i < 20; i++)
                {
                    Console.WriteLine($"{x} * {i} = {x * i}");
                }
            };
            table(3);
            // ---------------------- Func Delegate : Return Multiplication Result ----------------------
            Func<int, int, string> mutipleResult = (x, y) =>
            {
                return $"{x} * {y} = {x * y}";
            };
            Console.WriteLine(mutipleResult(4, 5));

        }
    }
}
