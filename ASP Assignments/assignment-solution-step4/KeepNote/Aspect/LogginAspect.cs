using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace KeepNote.Aspect
{
    /*Override the methods of ActionFilterAttribute to log the information into file
     * at given file path.
    */
    public class LoggingAspect : ActionFilterAttribute
    {
        string logFilePath;

        Stopwatch stopwatch = new Stopwatch();

        public LoggingAspect(IHostingEnvironment environment)
        {
            logFilePath = environment.ContentRootPath + @"/LogFile.txt";
        }



        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            stopwatch.Stop();
            string ts = stopwatch.Elapsed.ToString();

            // Format and display the TimeSpan value.
            //string elapsedTime = String.Format("{0}:{1}:{2}.{3}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds);
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            string message =  " Controller:" + controllerName + Environment.NewLine+ " Action:" + actionName + Environment.NewLine + " Time: " + DateTime.Now.ToString() + Environment.NewLine + " Process Duration " + ts + Environment.NewLine + Environment.NewLine;
            FileStream fs = new FileStream(logFilePath, FileMode.Append, FileAccess.Write); ;
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(message);
            sw.Close();
            fs.Close();
            sw.Dispose();
            fs.Dispose();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Log("OnActionExecuting", filterContext.RouteData);
            stopwatch.Start();
        }


        private void Log(string methodName, RouteData routeData, string elapsedTime)
        {

        }
    }
}

