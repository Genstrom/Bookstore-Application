using System;
using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public partial class Böcker
    {
        public Böcker()
        {
            FörfattareBöckerFörlags = new HashSet<FörfattareBöckerFörlag>();
            LagerSaldos = new HashSet<LagerSaldo>();
            OrderDetaljers = new HashSet<OrderDetaljer>();
        }

        public string Isbn { get; set; }
        public string Titel { get; set; }
        public string Språk { get; set; }
        public decimal Pris { get; set; }
        public DateTime Utgivningsdatum { get; set; }

        public virtual ICollection<FörfattareBöckerFörlag> FörfattareBöckerFörlags { get; set; }
        public virtual ICollection<LagerSaldo> LagerSaldos { get; set; }
        public virtual ICollection<OrderDetaljer> OrderDetaljers { get; set; }
    }
}
