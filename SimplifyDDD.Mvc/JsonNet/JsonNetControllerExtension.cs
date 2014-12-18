using System;
using System.Text;
using System.Web.Mvc;

namespace SimplifyDDD.Mvc.JsonNet
{
    public static class JsonNetControllerExtension
    {
        public static JsonResult JsonNet(this Controller controller, object data, string contentType,
                  Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            if (behavior == JsonRequestBehavior.DenyGet
                && string.Equals(controller.Request.HttpMethod, "GET",
                                 StringComparison.OrdinalIgnoreCase))
                //Call JsonResult to throw the same exception as JsonResult
                return new JsonResult();
            return new JsonNetResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding
            };
        }
    }
}
