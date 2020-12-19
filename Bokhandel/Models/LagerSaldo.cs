﻿#nullable disable

using System.Diagnostics;

namespace Bokhandel
{
    [DebuggerDisplay("{ButiksId} x {IsbnNavigation}")]
    public class LagerSaldo
    {
        public int ButiksId { get; set; }
        public string Isbn { get; set; }
        public int Antal { get; set; }

        public virtual Butiker Butiks { get; set; }
        public virtual Böcker IsbnNavigation { get; set; }
    }
}