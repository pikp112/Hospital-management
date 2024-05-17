namespace Hospital.Models
{
    public class PatientReport
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public ApplicationUser Patient { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ICollection<PrescibedMedicine> PrescibedMedicines { get; set; } = new List<PrescibedMedicine>();
    }
}