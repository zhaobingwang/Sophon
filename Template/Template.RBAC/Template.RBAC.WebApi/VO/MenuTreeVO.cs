using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.VO
{
    /// <summary>
    /// 菜单树
    /// </summary>
    public class MenuTreeVO
    {
        /// <summary>
        /// 初始化一个<see cref="MenuTreeVO"/>新实例
        /// </summary>
        public MenuTreeVO()
        {
            Children = new List<MenuTreeVO>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 是否展开子节点
        /// </summary>
        public bool Expand { get; set; }

        /// <summary>
        /// 禁用响应
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 禁用CheckBox
        /// </summary>
        public bool DisableCheckbox { get; set; }

        /// <summary>
        /// 是否选中子节点
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// 是否勾选（如果存在子节点，子节点也会勾选）
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<MenuTreeVO> Children { get; set; }
    }
}
