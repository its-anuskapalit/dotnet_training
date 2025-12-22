using System;
// EMPLOYEE CLASS WITH PROPERTIES AND VALIDATION
namespace Oops
{
    //     public class Employee
    //     {
    //         //validation of input and then assigning 
    //         private int id;
    //        // public int Id {get=> id ; set=> id =value;}
    //        public int Id
    //         {
    //             set
    //             {
    //                 if (value > 0)
    //                 {
    //                     id=value;
    //                 }
    //                 else
    //                 {
    //                     id=0;
    //                     throw new InvalidOperationException("how id can less than zero");
    //                 }
    //             }
    //         }
    //     public string DisplayEmpDetails()
    //         {
    //             return $"Employee Id is {id}";
    //         }
    // }

    //ASSOCIATE CLASS WITH PROPERTIES AND VALIDATION
    public class Associate
    {
        //validation of input and then assigning
        private int id;
        private string? name;
        private int rank;
        public List<String> list=new List<string>();
        // public int Id {get=> id ; set=> id =value;}
        public int Id{
            set
            {
                if (value > 0)
                {
                    id=value;
                }
                else
                {
                    id=0;
                    list.Add("hhow id can less than zero");
                }
            }
        }
        // public string Name {get=> name ; set=> name =value;}
        public string? Name{
            set
            {
                if (value.Equals(""))
                {
                    
                    list.Add("how name can be null");
                }
                else
                {

                    name=value;
                }
            }
        }
        public int Rank{
            set
            {
                if (value >= 1)
                {
                    rank=value;
                }
                else
                {
                    rank=0;
                    list.Add("how rank can less than zero");
                }
            }
    }
        //method to display details
        public string DisplayEmpDetails()
        {
            return $"Associate Id is {id} name {name} and ranking is {rank}";
        }

}
}