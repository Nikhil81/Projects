using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace VersioningUsingAcceptHeader.CustomVersion
{
    public class CustomVersionHeader : DefaultHttpControllerSelector
    {
        readonly HttpConfiguration _config;
        public CustomVersionHeader(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var _controller = GetControllerMapping();
            var _routeData = request.GetRouteData();
            var _controllerName = _routeData.Values["controller"].ToString();

            var versionNumber = "1";

            var requestedVersionNumber = request.Headers.Accept.Where(x => x.Parameters.Count(p => p.Name == "version") > 0);

            if (requestedVersionNumber.Any())
            {
                versionNumber = request.Headers.Accept.First().Parameters.First(x => x.Name == "version").Value.ToString();
            }

            if (versionNumber == "1")
            {
                _controllerName += "V1";
            }
            else
            {
                _controllerName += "V2";
            }

            HttpControllerDescriptor httpControllerDescriptor;
            if (_controller.TryGetValue(_controllerName, out httpControllerDescriptor))
            {
                return httpControllerDescriptor;
            }
            return null;
        }
    }
}