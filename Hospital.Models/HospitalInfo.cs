namespace Hospital.Models
{
    public class HospitalInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}