using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable

namespace Bokhandel
{
    [DebuggerDisplay("{Titel}")]
    public class Böcker
    {
        public Böcker()
        {
            FörfattareBöckerFörlags = new HashSet<FörfattareBöckerFörlag>();
            LagerSaldos = new HashSet<LagerSaldo>();
            Orderdetaljers = new HashSet<Orderdetaljer>();
        }

        public string Isbn { get; set; }
        public string Titel { get; set; }
        public string Språk { get; set; }
        public decimal Pris { get; set; }
        public DateTime Utgivningsdatum { get; set; }

        public virtual ICollection<FörfattareBöckerFörlag> FörfattareBöckerFörlags { get; set; }
        public virtual ICollection<LagerSaldo> LagerSaldos { get; set; }
        public virtual ICollection<Orderdetaljer> Orderdetaljers { get; set; }
        public object This { get { return this; } }
    }
}