using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Data;
using Template.RBAC.WebApi.Entities;
using Template.RBAC.WebApi.Enums;
using Template.RBAC.WebApi.VO;

namespace Template.RBAC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TemplateDbContext _dbContext;

        public AccountController(TemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 认证用户菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Menu()
        {
            var sql = "select m.* from SysRolePermissionMapping rpm " +
                "left join SysPermission p on p.Code = rpm.PermissionCode" +
                "inner join SysMenu m on m.Id = p.MenuId" +
                "where p.IsDeleted = 0 and p.Status = 1 and p.Type = 0 " +
                "and m.IsDeleted=0 and m.Status=1 " +
                "and exists(select * from SysUserRoleMapping urm where urm.UserId={0} and urm.RoleCode=rpm.RoleCode)";
            if (AuthContextServices.CurrentUser.UserType == Enums.UserType.SuperAdministrator)
            {
                sql = "select * form SysMenu where IsDeleted=0 and Status=1";
            }
            var menus = await _dbContext.SysMenu.FromSqlRaw(sql, AuthContextServices.CurrentUser.Id).ToListAsync();
            var rootMenus = await _dbContext.SysMenu.Where(x => x.IsDeleted == IsDeleted.No && x.Status == Status.Normal && x.ParentId == Guid.Empty).ToListAsync();

            foreach (var root in rootMenus)
            {
                if (menus.Exists(x => x.Id == root.Id))
                {
                    continue;
                }
                menus.Add(root);
            }

            menus = menus.OrderBy(x => x.Sort).ThenBy(x => x.CreateTime).ToList();
            var menu = MenuItemUtil.LoadMenuTree(menus, "0");
            return Ok(menu);
        }
    }

    public static class MenuItemUtil
    {
        public static List<MenuItem> LoadMenuTree(List<SysMenu> menus, string selectedId = null)
        {
            var tmp = menus.Select(x => new MenuItem
            {
                Id = x.Id.ToString(),
                ParentId = (x.ParentId != null && ((Guid)x.ParentId) == Guid.Empty) ? "0" : x.ParentId?.ToString(),
                Name = x.Alias,
                Component = x.Component,
                Meta = new MenuMeta
                {
                    BeforeCloseFun = x.BeforeCloseFun ?? "",
                    HideInMenu = x.HideInMenu == YesOrNo.Yes,
                    Icon = x.Icon,
                    NotCache = x.NotCache == YesOrNo.Yes,
                    Title = x.Name
                }
            }).ToList();
            var menuTree = tmp.BuildTree(selectedId);
            return menuTree;
        }

        public static List<MenuItem> BuildTree(this List<MenuItem> menus, string selectedId = null)
        {
            var lookup = menus.ToLookup(x => x.ParentId);
            var result = RecursiveBuild(lookup, selectedId);
            return result;
        }

        private static List<MenuItem> RecursiveBuild(ILookup<string, MenuItem> lookup, string parentId = null)
        {
            return lookup[parentId].Select(x => new MenuItem
            {
                Id = x.Id,
                ParentId = x.ParentId,
                Children = RecursiveBuild(lookup, x.Id),
                Component = x.Component ?? "Default",
                Name = x.Name,
                Path = x.Path,
                Meta = new MenuMeta
                {
                    BeforeCloseFun = x.Meta.BeforeCloseFun,
                    HideInMenu = x.Meta.HideInMenu,
                    Icon = x.Meta.Icon,
                    NotCache = x.Meta.NotCache,
                    Title = x.Meta.Title,
                    Permission = x.Meta.Permission
                }
            }).ToList();
        }
    }
}
