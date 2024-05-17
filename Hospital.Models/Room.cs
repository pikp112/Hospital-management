namespace Hospital.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Type { get; set; }
        public string Status { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}