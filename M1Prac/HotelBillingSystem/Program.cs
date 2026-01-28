namespace hotel {
    public interface Room
    {
        public double calculateTotalBill(int nightsStayed, int joiningYear);
        int calculateMembershipYears(int joiningYear);


    }

    public class HotelRoom {

        public string roomType{get; set;}
        public double ratePerNight{get; set;}
        public string guestName{get; set;}

        public HotelRoom(string roomtype, double rate, string guestname){
            roomType = roomtype;
            ratePerNight = rate;
            guestName = guestname;
        }

        public int calculateMembershipYears(int joiningYear){
            int currentYear = DateTime.Now.Year;
            return currentYear - joiningYear;
        }

        public double calculateTotalBill(int nightsStayed, int joiningYear){
            double total = nightsStayed*ratePerNight;
            if(calculateMembershipYears(joiningYear) > 3){
                total = (total * 90)/100;
            }

            return Math.Round(total);

        }
    }
      class Program
    {
        static void Main(string[] args)
        {
            HotelRoom room = new HotelRoom("Deluxe", 2500, "Anuska");

            Console.Write("Enter number of nights stayed: ");
            int nightsStayed = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter membership joining year: ");
            int joiningYear = Convert.ToInt32(Console.ReadLine());

            double totalBill = room.calculateTotalBill(nightsStayed, joiningYear);

            Console.WriteLine("\nGuest Name: " + room.guestName);
            Console.WriteLine("Room Type: " + room.roomType);
            Console.WriteLine("Total Bill: ₹" + totalBill);
        }
    }
}
