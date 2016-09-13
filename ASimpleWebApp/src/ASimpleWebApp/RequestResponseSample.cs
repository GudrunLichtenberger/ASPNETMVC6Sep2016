using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Newtonsoft.Json;

namespace ASimpleWebApp
{
    public class RequestResponseSample
    {
        public static string GetDiv(string key, string value) =>
            $"<div><span>{key}:</span>&nbsp;<span>{value}</span></div>";

        public static async Task Response1(HttpContext context)
        {
            HttpRequest request = context.Request;
            var sb = new StringBuilder();
            sb.Append(GetDiv("scheme", request.Scheme));
            sb.Append(GetDiv("host", request.Host.HasValue ? request.Host.Value :
              "no host"));
            sb.Append(GetDiv("path", request.Path));
            sb.Append(GetDiv("query string", request.QueryString.HasValue ?
              request.QueryString.Value : "no query string"));

            sb.Append(GetDiv("method", request.Method));
            sb.Append(GetDiv("protocol", request.Protocol));

            await context.Response.WriteAsync(sb.ToString());
        }

        public static async Task JustReturn(HttpContext context)
        {
            var request = context.Request.Query["x"];
            string encoded = HtmlEncoder.Default.Encode(request);
            await context.Response.WriteAsync(encoded);

        }

        public static string GetForm(HttpRequest request)
        {
            string result = string.Empty;
            switch (request.Method)
            {
                case "GET":
                    result = GetForm();
                    break;
                case "POST":
                    result = ShowForm(request);
                    break;
                default:
                    break;
            }
            return result;
        }

        private static string GetForm() =>
          "<form method=\"post\" action=\"one\">" +
            "<input type=\"text\" name=\"text1\" />" +
            "<input type=\"submit\" value=\"Submit\" />" +
          "</form>";


        private static string ShowForm(HttpRequest request)
        {
            var sb = new StringBuilder();
            if (request.HasFormContentType)
            {
                IFormCollection coll = request.Form;
                foreach (var key in coll.Keys)
                {
                    sb.Append(GetDiv(key, HtmlEncoder.Default.Encode(coll[key])));
                }
                return sb.ToString();
            }
            else return "no form".Div();
        }

        public static string GetJson(HttpResponse response)
        {
            var b = new
            {
                Title = "Professional C# 6",
                Publisher = "Wrox Press",
                Author = "Christian Nagel"
            };

            string json = JsonConvert.SerializeObject(b);
            response.ContentType = "application/json";
            return json;
        }
    }
}
