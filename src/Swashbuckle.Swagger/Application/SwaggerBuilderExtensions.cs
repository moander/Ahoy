using System;
using Microsoft.AspNetCore.Http;
using Swashbuckle.Swagger.Application;
using Swashbuckle.Swagger.Model;

namespace Microsoft.AspNetCore.Builder
{
    public static class SwaggerBuilderExtensions
    {
        private const string DefaultRouteTemplate = "swagger/{documentName}/swagger.json";

        public static IApplicationBuilder UseSwagger(
            this IApplicationBuilder app,
            string routeTemplate = DefaultRouteTemplate,
            Action<SwaggerDocument, HttpRequest> documentFilter = null)
        {
            return app.UseSwagger(options =>
            {
                options.RouteTemplate = routeTemplate ?? DefaultRouteTemplate;
                options.DocumentFilter = documentFilter ?? PassThroughDocumentFilter;
            });
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, Action<SwaggerMiddlewareOptions> setupAction)
        {
            var options = new SwaggerMiddlewareOptions
            {
                RouteTemplate = DefaultRouteTemplate,
                DocumentFilter = PassThroughDocumentFilter,
            };

            setupAction(options);

            return app.UseMiddleware<SwaggerMiddleware>(options);
        }

        private static void PassThroughDocumentFilter(SwaggerDocument swaggerDoc, HttpRequest httpRequest)
        { }
    }
}