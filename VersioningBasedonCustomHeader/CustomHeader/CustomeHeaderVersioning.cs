using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace VersioningBasedonCustomHeader.CustomHeader
{
    public class CustomeHeaderVersioning : DefaultHttpControllerSelector
    {
        readonly HttpConfiguration _config;
        public CustomeHeaderVersioning(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var _controller = GetControllerMapping();
            var _routeData = request.GetRouteData();
            var _controllerName = _routeData.Values["controller"].ToString();
            var _versioNumber = "1";
            var _customeHeader = "customerHeader-version-num";
            if (request.Headers.Contains(_customeHeader))
            {
                _versioNumber = request.Headers.GetValues(_customeHeader).FirstOrDefault();
            }

            if (_versioNumber == "1")
            {
                _controllerName = _controllerName + "V1";
            }
            else
            {
                _controllerName = _controllerName + "V2";
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