class GCDemo
{
    public void CreateGarbage()
    {
        for(int i=0;i<10000;i++)
        {
            var obj=new byte[1024*1024];
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Garbage collected");
    }
}
