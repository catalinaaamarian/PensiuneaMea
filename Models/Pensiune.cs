using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using Humanizer;

namespace PensiuneaMea.Models
{
    public class Pensiune
    {
        public int ID { get; set; }
        [Display(Name = "Denumire Pensiune")]
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }
        public string Camera { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public ICollection<PensiuneCategory>? PensiuneCategories { get; set; }
    }

}

