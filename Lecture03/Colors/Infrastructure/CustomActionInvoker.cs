using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace Colors.Infrastructure
{
    public class CustomActionInvoker : ControllerActionInvoker
    {
        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            string color = controllerContext.HttpContext.Request.QueryString["e"] ?? "";
            MethodInfo[] actions = controllerContext.Controller.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => { var p = m.GetParameters(); return p.Length == 1 && p[0].ParameterType.IsEnum; }).ToArray();
            foreach (var x in actions)
            {
                Type et = x.GetParameters()[0].ParameterType;
                if (Enum.GetNames(et).Contains(color))
                {
                    ViewResult result = (ViewResult)x.Invoke(controllerContext.Controller, new object[] { Enum.Parse(et, color) });
                    result.View = result.ViewEngineCollection.FindView(controllerContext, "Index", null).View;
                    InvokeActionResult(controllerContext, result);
                    return true;
                }
            }
            if (actions.Length > 0)
            {
                ViewResult result = (ViewResult)actions[0].Invoke(controllerContext.Controller, new object[] { Enum.Parse(actions[0].GetParameters()[0].ParameterType, "0") });
                result.View = result.ViewEngineCollection.FindView(controllerContext, "Index", null).View;
                InvokeActionResult(controllerContext, result);
                return true;
            }
            return base.InvokeAction(controllerContext, actionName);
        }
    }
}