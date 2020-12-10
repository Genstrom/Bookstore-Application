using System;
using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public partial class Kunder
    {
        public Kunder()
        {
            Ordrars = new HashSet<Ordrar>();
        }

        public string Id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Adress { get; set; }
        public string Stad { get; set; }
        public string Postnummer { get; set; }
        public string Epostadress { get; set; }
        public string Telefonnummer { get; set; }

        public virtual ICollection<Ordrar> Ordrars { get; set; }
    }
}
