using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace SellingKoi.Models
{
    public enum KoiType
    {
        Kohaku, Sanke, Showa, Utsuri, Ogon, Chagoi,Butterfly
    }

    public class KOI
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public KoiType Type { get; set; }
        public double Price { get; set; }
        public double Age { get; set; }
        public string FarmID {  get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = true;
        public DateTime Registration_date { get; set; } = DateTime.Now;
        
    }
}
