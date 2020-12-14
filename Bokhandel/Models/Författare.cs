using System;
using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public class Författare
    {
        public Författare()
        {
            FörfattareBöckerFörlags = new HashSet<FörfattareBöckerFörlag>();
        }

        public int FörfattareId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime Födelsedatum { get; set; }

        public virtual ICollection<FörfattareBöckerFörlag> FörfattareBöckerFörlags { get; set; }
    }
}