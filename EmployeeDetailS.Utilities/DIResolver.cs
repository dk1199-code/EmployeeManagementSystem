using EmployeeDetailS.Core.IEmployeeReposicery;
using EmployeeDetailS.Core.IEmployeeService;
using EmployeeDetailS.Resources.Repositery;
using EmployeeDetailS.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailS.Utilities
{
    public static class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Context accesor
            // this is for accessing the http context by interface in view level
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services

            services.AddScoped<IEmployeeDetailsService, EmployeeService>();

            #endregion

            #region Repository

            services.AddScoped<IEmployeeDetailsRepositery, EmployeeRepositery>();

            #endregion

        }
    }
}
