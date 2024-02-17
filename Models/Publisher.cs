using Microsoft.EntityFrameworkCore;

namespace PensiuneaMea.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string? PublisherName { get; set; }
        public ICollection<Pensiune>? Pensiuni { get; set; }
    }

}
