// using System;
// namespace Oops{
// class Program
//     {
//         static void Main()
//         // {
//         //     Employee usEmp = new USEmployee();
//         //     Employee indEmp = new IndiaEmployee();

//         //     Console.WriteLine("US Tax: " + usEmp.TaxCalculation(100000));
//         //     Console.WriteLine("India Tax: " + indEmp.TaxCalculation(100000));
//         // }
//         // {
//         //     Payment p = new UpiPayment(499.00m, "ittechgenie@upi");
//         //     p.Pay();
//         //     p.PrintReceipt();

            
//         // }
        
//     }
// }


//=====================================================================================================================
using System;
namespace MainConstructor{
public class Program
{
    public static void Main()
    {
        Son son=new Son();

        Console.WriteLine(son.Insurance());
        Console.WriteLine(son.SavingMoney());
         Console.WriteLine(son.Savings());
    }
}
}