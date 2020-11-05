using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sophon.Infrastructure.Entities
{
    public class AssetType
    {
        public string Code { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 分类方法
        /// 0：默认
        /// 1：资产存储介质
        /// </summary>
        public short Method { get; set; }
    }
}
