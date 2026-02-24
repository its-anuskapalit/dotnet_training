using DEL;
namespace ClassBL
{
    public class BlRevstring
    {
        public string Revstring()
        {
            ClassDEl ob = new ClassDEl();
            string s = ob.GetAllNames();
            s= new string(s.Reverse().ToArray());
            return s;
      
        }
    }
}
