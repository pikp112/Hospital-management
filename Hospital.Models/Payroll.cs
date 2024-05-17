namespace Hospital.Models
{
    public class Payroll
    {
        public int Id { get; set; }
        public ApplicationUser Employee { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Compensation { get; set; }
        public string AccountNumber { get; set; }
    }
}