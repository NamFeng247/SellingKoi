using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SellingKoi.Models
{
    public class Farm
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }
        [StringLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string Owner { get; set; }
        [StringLength(30)]
        [Column(TypeName = "nvarchar(10)")]
        public string Location { get; set; }
        [StringLength(50)]
        [Column(TypeName = "nvarchar(30)")]
        public string Address { get; set; }
        public bool Status { get; set; }
        public DateTime Registration_date { get; set; } = DateTime.Now;
        public List<KOI>? KoiList { get; set; }


    }
}
