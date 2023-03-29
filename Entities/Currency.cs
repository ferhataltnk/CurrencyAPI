using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string? CurrencyCode { get; set; }
        public string? CurrencyName { get; set; }
        public string? CurrencyNameTr { get; set; }
        public decimal? ForexBuying { get; set; }
        public decimal? ForexSelling { get; set; }
        public DateTime? TcmbCurrencyDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }




        [JsonIgnore]
        public int CreatedUserId { get; set; }
        [JsonIgnore]
        public DateTime ModifiedTime { get; set; }
        [JsonIgnore]
        public int ModifiedUserId { get; set; }
        [JsonIgnore]
        public DateTime? DeletedTime { get; set; }
        [JsonIgnore]
        public int? DeletedUserId { get; set; }
    }
}
