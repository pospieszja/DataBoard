using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBoard.Infrastructure.Mapper;
using DataBoard.Infrastructure.Repositories;
using DataBoard.Infrastructure.Services;
using DataBoard.Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DataBoard.Infrastructure;

namespace DataBoard.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataboardContext>(options => options.UseSqlServer("Data Source=localhost;Database=Databoard;User ID=sa;Password=4BEsFpaq"));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddLogging();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DataboardContext context)
        {
            context.EnsureSeedData();
            app.UseMvc();
            loggerFactory.AddConsole(minLevel: LogLevel.Warning);

        }
    }
}