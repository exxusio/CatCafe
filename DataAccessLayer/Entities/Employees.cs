namespace DataAccessLayer.Entities
{
    public partial class Employees
    {
        public int employeeID { get; set; }

        public string name { get; set; } = null!;

        public string surname { get; set; } = null!;

        public int positionID { get; set; }

        public string? aboutEmployee { get; set; }

        public byte[] photography { get; set; } = null!;

        public decimal salary { get; set; }

        public DateOnly hireDate { get; set; }

        public virtual Positions position { get; set; } = null!;
    }
}