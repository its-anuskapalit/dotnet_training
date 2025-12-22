using System;
// HOLIDAY BASE AND DERIVED CLASS PROGRAM
namespace Oops
{
    public class holiday
    {
        public virtual string ListHoliday()
        {
            return "Holi, Diwali, Durga Pooja";
            
        }
    }
    // Derived class for US Holidays
    public class USHoliday: holiday
    {
        public override string ListHoliday()
        {
            return "New Year, Xmas, ThanksGiving";
        }
    }
}