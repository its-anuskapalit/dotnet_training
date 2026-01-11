// using System;
// public class PaymentService{
//     public void Process(decimal amt)
//     {
//         try
//         {
//             if(amt <= 0)
//             {
//                 throw new Exception("Invalid payment amount");
//                 Console.WriteLine("Process payment: "+amt);
//             }
//         }
//         catch(Exception ex)
//         {
//             Console.WriteLine("ERROR:"+ex.Message);
//         }
//         finally
//         {
//             Console.WriteLine("Audit log saved");
//         }
//     }
// }
//========================================================

public class CustomerExceptionMsg: Exception
{
    public CustomerExceptionMsg(string msg): base(msg){}
}
class Bank
{
    public void Withdraw(decimal bal,decimal amt)
    {
        if (bal < amt)
        {
            throw new CustomerExceptionMsg("Withdrawal denied");
        }
    }
}