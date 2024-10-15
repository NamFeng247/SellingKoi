using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SellingKoi.Models
{
    public class Route
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Lộ trình")]
        public required string Name { get; set; }
        //public List<Farm> Farms { get; set; }
        public bool Status { get; set; } = true;
        public DateTime Registration_date { get; set; } = DateTime.Now;

        //Navigation Property
        public List<Farm> Farms { get; set; } = new List<Farm>();


    }
}
