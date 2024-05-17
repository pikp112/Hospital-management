namespace Hospital.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public ICollection<MedicineReport> MedicineReports { get; set; } = new List<MedicineReport>();
        public ICollection<PrescibedMedicine> PrescibedMedicines { get; set; } = new List<PrescibedMedicine>();
    }
}