namespace Project{
    public abstract class BankAccount{
        protected decimal Balance;
        public int AccountNo;
        public abstract void Deposit(decimal amt);
        public abstract void Withdraw(decimal amt);
        public virtual decimal GetBalance()
        {
            return Balance;
        }
    }
}