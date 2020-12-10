using System;
using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public partial class Ordrar
    {
        public Ordrar()
        {
            OrderDetaljers = new HashSet<OrderDetaljer>();
        }

        public int OrderId { get; set; }
        public string KundId { get; set; }
        public int ButiksId { get; set; }
        public string Betalningssätt { get; set; }
        public decimal Totalbelopp { get; set; }
        public decimal Moms { get; set; }

        public virtual Butiker Butiks { get; set; }
        public virtual Kunder Kund { get; set; }
        public virtual ICollection<OrderDetaljer> OrderDetaljers { get; set; }
    }
}
