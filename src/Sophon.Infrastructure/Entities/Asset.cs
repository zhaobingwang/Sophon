using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sophon.Infrastructure.Entities
{
    public class Asset
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal AggregateAmount { get; set; }

        public IsDeleted IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }
    }
}