using System;

namespace Mobile.Model
{
    public class BoostAccount
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Code { get; set; }
        public DateTime GeneratedDateTime { get; set; }
        public DateTime? DateOfBoost { get; set; }
        public int? CustomerId { get; set; }
    }
}