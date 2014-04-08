using System.Web.Mvc;
using System.Net;

namespace BowlingScore
{
    public class ErrorResult : ContentResult
    {
        public int StatusCode;
        public ErrorResult(string body)
        {
            this.Content = body;
            StatusCode = (int)HttpStatusCode.BadRequest;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.HttpContext.Response.StatusDescription = "Bad Request";
            base.ExecuteResult(context);
        }
    }
}