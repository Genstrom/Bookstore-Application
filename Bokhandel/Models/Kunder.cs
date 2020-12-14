using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public class Kunder
    {
        public Kunder()
        {
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Adress { get; set; }
        public string Stad { get; set; }
        public string Postnummer { get; set; }
        public string Epostadress { get; set; }
        public string Telefonnummer { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}