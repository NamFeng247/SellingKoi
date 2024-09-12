using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellingKoi.Models.Entities
{
    public class Customer
    {
        public Guid Id { get; set; } 

        [StringLength(30)] 
        [Column(TypeName = "nvarchar(30)")]
        public string? Name { get; set; }
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? Email { get; set; }
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public required string Phone { get; set; }
        [StringLength(100)] 
        [Column(TypeName = "nvarchar(100)")]
        public string? Address { get; set; } 
        public bool Status { get; set; } = true;
        public DateTime Registration_date { get; set; } = DateTime.Now;

    }
}
