using System.ComponentModel.DataAnnotations.Schema;

namespace LoanCustomer.Model
{
    public class Loans
    {
        public int Id { get; set; }

        public int? CustId { get; set; }
        [ForeignKey("CustId")]
        public virtual Customers Customer { get; set; }

        public int? LoanTypeId { get; set; }
        [ForeignKey("LoanTypeId")]
        public virtual LoanTypes LoanType { get; set; }
    }
}
