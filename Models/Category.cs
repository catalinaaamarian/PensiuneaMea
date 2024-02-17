namespace PensiuneaMea.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<PensiuneCategory>? PensiuneCategories { get; set; }
    }
}

