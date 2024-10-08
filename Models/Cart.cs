using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SellingKoi.Models
{
    public class Cart
    {
        
        [Key]
        public Guid Id { get; set; } // Khóa chính

        [ForeignKey("Account")]
        public Guid CustomerId { get; set; } // Khóa ngoại đến Account

        [ForeignKey("Route")]
        public Guid RouteId { get; set; } // Khóa ngoại đến Route

        public virtual Account Account { get; set; } // Mối quan hệ với Account
        public virtual Route Route { get; set; } // Mối quan hệ với Route

        public virtual ICollection<KOI> KoiList { get; set; } = new List<KOI>(); // Danh sách Koi trong Cart
    }

}
