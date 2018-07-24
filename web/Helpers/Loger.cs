using Data;
using Entities;
using Entities.Account;
using Microsoft.AspNetCore.Mvc;
using System;

namespace web.Helpers
{
    public static class Loger
    {

       

        public static void Log(ControllerContext context, User user, CatrinaContext db)
        
        {
            string actionName = context.RouteData.Values["action"].ToString();
            string controllerName = context.RouteData.Values["controller"].ToString();
            
            var date = DateTime.Now;

            var log = new Log()
            {
                User = user,
                ActionName = actionName,
                ConctrollerName = controllerName,
                Act = ActionType.justLog.ToString(),
                Date = date
            };

            db.Logs.AddAsync(log);
            db.SaveChangesAsync();
        }
    }
}
