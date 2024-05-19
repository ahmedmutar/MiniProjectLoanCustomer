using System.ComponentModel.DataAnnotations.Schema;

namespace LoanCustomer.Model
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual Cities City { get; set; }
    }
}
