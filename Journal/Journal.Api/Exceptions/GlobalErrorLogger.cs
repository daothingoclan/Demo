using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Journal.Api.Exceptions
{
    public class GlobalErrorLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var exception = context.Exception;
            ILog logger = LogManager.GetLogger(context.GetType());
            logger.Error(exception.StackTrace, exception);
        }
    }
}