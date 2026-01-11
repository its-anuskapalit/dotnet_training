public class Marks
{
    int[] data=new int[5];
    public int this[int index]
    {
        get { return data[index];}
        set{ data[index]=value; }
    }
}