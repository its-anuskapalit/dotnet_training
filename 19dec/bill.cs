//Calculate bill: First 199 units @ 1.20; 200-400 @ 1.50; 400-600 @ 1.80; above 600 @ 2.00. Add 15% surcharge if bill > 400.
using System;
class bill
{
    public static void cal()
    {
        ///
        /// this class is to change the number of units taken and calculate the bill
        /// 
        Console.WriteLine("Enter the unit bills");
        int units=Convert.ToInt32(Console.ReadLine());
        double amt;
        if(units < 200)
        {
            amt=units*1.20;
        }
        else if(units>200 && units < 400)
        {
            amt=(199*1.20) + ((units-199)*1.50);
        }
        else if(units>400 && units < 600)
        {
            amt=(199*1.20) +(200*1.50)+ ((units-399)*1.80);
        }
        else
        {
            amt=(199*1.20) +(200*1.50)+ (200*1.80)+((units-599)*2);
        }

        // 15% surcharged to included
        if (amt > 400)
        {
            Console.WriteLine("bill amt: "+ (amt+(amt*0.15)));
        }
        else
        {
            Console.WriteLine("bill amt: "+ (amt));
        }

    } 
}