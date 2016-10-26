using Microsoft.AspNetCore.Http;
using Swashbuckle.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swashbuckle.Swagger.Application
{
    public class SwaggerMiddlewareOptions
    {
        public Action<SwaggerDocument, HttpRequest> DocumentFilter { get; set; }

        public string RouteTemplate { get; set; }

        /// <summary>
        /// Used when {documentName} is omitted in <see cref="RouteTemplate"/>
        /// </summary>
        public string DefaultDocumentName { get; set; }
    }
}
