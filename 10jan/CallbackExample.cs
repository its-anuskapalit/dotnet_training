using System;
namespace Delegate2
{
    public delegate void UploadStatus(string msg);
    //service
    class FilerUpload
    {
        public void Upload(string fileName, UploadStatus callback)
        {
            Console.WriteLine("Uploading file: " + fileName);
            callback("Upload completed: " + fileName);
        }
    }
    class AudiService
    {
        public void log(string msg)
        {
            Console.WriteLine("AUDIT: " + msg);
        }
    }
    class Program
    {
        static void Main()
        {
            FilerUpload a=new FilerUpload();
            AudiService b=new AudiService();
            UploadStatus ob=b.log;
            a.Upload("The Life of PI", ob);
        }
    }
}