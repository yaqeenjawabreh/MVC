namespace task6.Models
{
    public class Employee
    {
        public int Id { set; get; }
        public string FullName { set; get; }
        public int Phone { get; set; }
       public string Email { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public DateTime HierDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
