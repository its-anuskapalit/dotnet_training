namespace Project
{
    public class SavingsAccount: BankAccount
    {
        public override void Deposit(decimal amt)
        {
            Balance+=amt;
        }
        public override void Withdraw(decimal amt)
        {
            if(Balance>=amt){
            Balance-=amt;
            }
        }
    }
    public class CurrentAccount: BankAccount
    {
        public override void Deposit(decimal amt)
        {
            Balance+=amt;
        }
        public override void Withdraw(decimal amt)
        {
            if(Balance>=amt){
            Balance-=amt;
            }
        }
    }
    
}