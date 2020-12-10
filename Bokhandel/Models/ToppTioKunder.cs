using System;
using System.Collections.Generic;

#nullable disable

namespace Bokhandel
{
    public partial class ToppTioKunder
    {
        public string Id { get; set; }
        public string Namn { get; set; }
        public int? AntalOrdrar { get; set; }
        public decimal? TotalbeloppInklMoms { get; set; }
    }
}
