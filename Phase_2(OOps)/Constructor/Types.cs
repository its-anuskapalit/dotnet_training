//default
// class User
// {
//     int age;
//     public User()
//     {
//         this.age=age;
//     }
// }

//Parameterised
class User
{
    public int Age;
    public User(): this(0)
    {
        
    }
    public User(int age)
    {
        if (age <= 0)
        {
            throw new ArgumentException();
        }
        this.Age=age;
    }
}