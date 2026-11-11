using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace task8.Models
{
    public class SupplyRequest
    {
        public int Id { set; get; }
        public DateTime RequestDate { set; get; }
        public double TotalPrice { set; get; }
        public string Status { set; get; }

        [ValidateNever]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public IdentityUser? User { get; set; }
        public ICollection<RequestItem> RequestItems { get; set; }

    }
}
