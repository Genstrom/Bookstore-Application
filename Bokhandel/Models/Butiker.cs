using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public class Butiker
    {
        public Butiker()
        {
            LagerSaldos = new HashSet<LagerSaldo>();
        }

        public int Id { get; set; }
        public string Namn { get; set; }
        public string Adress { get; set; }
        public string Stad { get; set; }
        public string Postnummer { get; set; }

        public virtual ICollection<LagerSaldo> LagerSaldos { get; set; }
    }
}