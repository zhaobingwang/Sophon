using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Infrastructure.Entities
{
    public class AssetRecord
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public decimal AggregateAmount { get; set; }
        public DateTime CreateTime { get; set; }
        public IsDeleted IsDeleted { get; set; }
    }
}
