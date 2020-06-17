using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TCAPP.API.Graphql.Contents;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.DataAccess.Context;
using QueryContent = TCAPP.API.Graphql.Contents.Query;
using MutationContent = TCAPP.API.Graphql.Contents.Mutation;

namespace TCAPP.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<TCAPPContext>(o => o.UseMySql(Configuration.GetConnectionString("Test")));
            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddQueryType<QueryContent>()
                    .AddMutationType<MutationContent>()
                    .Create(),
                new QueryExecutionOptions { ForceSerialExecution = true });

            services.AddScoped<ICreateContentStrategy, CreateContentStrategy>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseGraphQL();
            app.UsePlayground();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
