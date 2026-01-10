using System;
namespace Q4
{
    class Black
    {
        bool isSubcriptionValid;
        int discountPercentage;
        Black(bool isSub, int dis)
        {
            try
            {
                isSubcriptionValid = isSub;
                discountPercentage = dis;
            }
            catch { 
            
            }
        }
        public int GetBroadbandPlanAmount()
        {

        }

    }
}