using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using StudentsAndTeacherWebApp.Services;

namespace StudentsAndTeacherWebApp.Injections
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddServiceInjection(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();

            return services;
        }
    }
}