using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using log4net;
using System.Text;

namespace PatientSevice.Filters
{
    public class PatientInfoExceptionFilter: ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext filterContext)
        {
            var controllerName = (string)filterContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName =(string)filterContext.ActionContext.ActionDescriptor.ActionName;
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            StringBuilder logError = new StringBuilder();

            logError.Append(controllerName + String.Empty + actionName);

            logger.Error(logError.Append(filterContext.Exception.Message));
        }
    }
}