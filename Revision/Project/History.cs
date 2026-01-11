public class TransactionHistory
{
    string[] history=new string[10];
    int index=0;
    public string this[int i]
    {
        get{ return history[i]; }
        set{ history[index++]=value; }
    }
}
