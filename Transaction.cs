using System;
using System.Collections.Generic;

#nullable disable

namespace forexapi.Context
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public string SenderAccNo { get; set; }
        public string SenderBankName { get; set; }
        public string ReciverAccNo { get; set; }
        public string ReciverBankName { get; set; }
        public string UserName { get; set; }
        public decimal? SenderAmount { get; set; }
        public decimal? ReciverAmount { get; set; }
        public decimal? Rate { get; set; }
        public int? Fee { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public DateTime? TrasactionDate { get; set; }
        public string Status { get; set; }
    }
}
