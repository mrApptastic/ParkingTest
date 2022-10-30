namespace ParkingService.Models
{
    public class Parking
    {
        public string? LicensePlate { get; set; }
        public string? LotNumber { get; set; }
        public string? Email { get; set; }
        public string? MobilePhone { get; set; }
        public DateTime ParkingStarted { get; } = DateTime.Now;
        public DateTime? ParkingEnded { get; set; }
    }

    public class ParkingTempData {
        public static List<Parking> TempStoredParkings = new List<Parking>();
    }
}
