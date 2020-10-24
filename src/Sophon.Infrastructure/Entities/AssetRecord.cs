using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Infrastructure.Entities
{
    public class AssetRecord
    {
        public int Id { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public decimal AggregateAmount { get; set; }
        public DateTime CreateTime { get; set; }
        public IsDeleted IsDeleted { get; set; }
    }
}
