using System;
namespace DeveloperMentalModel
{
    class User
    {
        public string Name {get; set;}
        public int Score {get; set;}
    }
    class Program
    {
        static void ApplyBonus(ref int score)
        {
            score+=20;
        }
        static void PromoUser(User user)
        {
            user.Score+=30;
        }
        static int? CalculateRating(int score)
        {
            if(score < 60)
            {
                return null;
            }
            return score/10;
        }
        static bool TryConvert(object input, out int score)
        {
            if(input is string s && int.TryParse(s,out score))
            {
                return true;
            }
            score=0;
            return false;
        }
        static void Main()
        {
            var baseScore = 50;
            ApplyBonus( ref baseScore);
            User user= new User{ Name ="Anuska", Score= baseScore};
            PromoUser(user);
            int? finalRating = CalculateRating(user.Score);

            if (finalRating.HasValue)
            {
                Console.WriteLine($"Final Rating: {finalRating.Value}");
            }

            object incomingData = "120";

            if (TryConvertScore(incomingData, out int parsedScore))
            {
                UpdateScore(in user, parsedScore);
            }
        }
    }
}