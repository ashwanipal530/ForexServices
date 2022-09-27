using System;
using System.Collections.Generic;

#nullable disable

namespace forexapi.Context
{
    public partial class CurrencyRate
    {
        public int Id { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public decimal? Rate { get; set; }
    }
}
