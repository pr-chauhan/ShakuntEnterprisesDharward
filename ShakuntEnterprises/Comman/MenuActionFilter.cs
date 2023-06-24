using Microsoft.AspNetCore.Mvc.Filters;
using ShakuntEnterprises.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ShakuntEnterprises.Comman;
namespace ShakuntEnterprises.Comman
{
    public class MenuActionFilter : ActionFilterAttribute
    {
        private readonly ShakuntEnterprisesContext _context;

        public MenuActionFilter(ShakuntEnterprisesContext dBContext)
        {
            _context = dBContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //UserID = HttpContext.Session.GetString("lid");
            var ModuleList = _context.MainNavigationBars.ToList();
            var MenuList = _context.MainNavigationBars.ToList();
            base.OnActionExecuting(context);
            context.RouteData.Values.Add("ModuleList", ModuleList);
            context.RouteData.Values.Add("MenuList", MenuList);

        }
    }
}
