using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sophon.Infrastructure.Entities
{
    public class Tmp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsLock { get; set; }
        public DateTime? RegTime { get; set; }
        public DateTime? DOB { get; set; }
        public short? Status { get; set; }
        public IsDelete? IsDelete { get; set; }
    }

    public enum IsDelete
    {
        No = 0,
        Yes = 1,
    }
}
