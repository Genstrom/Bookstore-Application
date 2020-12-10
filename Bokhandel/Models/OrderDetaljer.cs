using System;
using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public partial class OrderDetaljer
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Isbn { get; set; }
        public int Antal { get; set; }
        public DateTime Orderdatum { get; set; }
        public DateTime Leveransdatum { get; set; }

        public virtual Böcker IsbnNavigation { get; set; }
        public virtual Ordrar Order { get; set; }
    }
}
