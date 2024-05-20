namespace LabaCRUD.Pages.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string? Code {  get; set; }
        public Client? Client { get; set; }
        public Employee? Eployee { get; set; }

        public int Salary { get; set; }
        public int Amount { get; set; }
        public int mouth { get; set; }
        public int poruchitel { get; set; }
        public int creditstory { get; set; }
    }
}
