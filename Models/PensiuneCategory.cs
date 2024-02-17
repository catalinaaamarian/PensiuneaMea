namespace PensiuneaMea.Models
{
    public class PensiuneCategory
    {
        public int ID { get; set; }
        public int PensiuneID { get; set; }
        public Pensiune Pensiune { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
