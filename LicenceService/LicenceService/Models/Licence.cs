using System.ComponentModel.DataAnnotations.Schema;

namespace LicenceService.Models
{
    public class Licence
    {
        public int LicenceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cost { get; set; }

        public ICollection<LicencePurchase> LicencePurchases { get; set; }
    }
}
