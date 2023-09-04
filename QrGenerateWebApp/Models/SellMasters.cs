using System;
using System.Collections.Generic;

#nullable disable

namespace QrGenerateWebApp.Models
{
    public partial class SellMasters
    {
        public string InvoiceNo { get; set; }
        public string OrderNumber { get; set; }
        public string PartyAddress { get; set; }
        public string Car { get; set; }
        public decimal TotalWithVat { get; set; }
    }
}
