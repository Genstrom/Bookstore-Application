#nullable disable

using Bokhandel.Models;

namespace Bokhandel
{
    public class Orderdetaljer
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Isbn { get; set; }
        public decimal Pris { get; set; }
        public int Antal { get; set; }

        public virtual Böcker IsbnNavigation { get; set; }
        public virtual Order Order { get; set; }
    }
}