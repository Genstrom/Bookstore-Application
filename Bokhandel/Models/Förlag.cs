using System;
using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public partial class Förlag
    {
        public Förlag()
        {
            FörfattareBöckerFörlags = new HashSet<FörfattareBöckerFörlag>();
        }

        public int FörlagsId { get; set; }
        public string Namn { get; set; }
        public string Adress { get; set; }
        public string Stad { get; set; }
        public string Postnummer { get; set; }
        public string Kontaktperson { get; set; }
        public string Telefonnummer { get; set; }

        public virtual ICollection<FörfattareBöckerFörlag> FörfattareBöckerFörlags { get; set; }
    }
}
