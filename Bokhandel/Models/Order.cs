using System;
using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public class Order
    {
        public Order()
        {
            Orderdetaljers = new HashSet<Orderdetaljer>();
        }

        public int OrderId { get; set; }
        public string KundId { get; set; }
        public DateTime Orderdatum { get; set; }
        public DateTime Leveransdatum { get; set; }

        public virtual Kunder Kund { get; set; }
        public virtual ICollection<Orderdetaljer> Orderdetaljers { get; set; }
    }
}