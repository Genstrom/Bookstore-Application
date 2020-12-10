using System;
using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public partial class TitlarPerFörfattare
    {
        public string Namn { get; set; }
        public int? Ålder { get; set; }
        public int? Titlar { get; set; }
        public string Lagervärde { get; set; }
    }
}
