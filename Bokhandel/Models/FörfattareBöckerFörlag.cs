#nullable disable

namespace Bokhandel
{
    public class FörfattareBöckerFörlag
    {
        public string Isbn { get; set; }
        public int FörfattareId { get; set; }
        public int FörlagsId { get; set; }

        public virtual Författare Författare { get; set; }
        public virtual Förlag Förlags { get; set; }
        public virtual Böcker IsbnNavigation { get; set; }
    }
}