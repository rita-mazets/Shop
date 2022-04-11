using igi.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace igi.Extention
{
    public static class AppExtentions
    {
        public static IApplicationBuilder UseFileLogging(this
        IApplicationBuilder app)
        {
            return app.UseMiddleware<LogMiddleware>();
        }
    }
}
