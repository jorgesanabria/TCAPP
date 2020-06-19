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
using MutationText = TCAPP.API.Graphql.Contents.ContentTextMetaValues.Mutation;
using MutationString = TCAPP.API.Graphql.Contents.ContentStringMetaValues.Mutation;
using MutationFloat = TCAPP.API.Graphql.Contents.ContentFloatMetaValues.Mutation;
using MutationBool = TCAPP.API.Graphql.Contents.ContentBoolMetaValues.Mutation;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.RelationalData;
using TCAPP.API.Graphql.Contents.MetaValues;

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
            services.AddDbContext<TCAPPContext>(o => o.UseMySql(Configuration.GetConnectionString("Test")), ServiceLifetime.Scoped);
            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddQueryType<QueryContent>()
                    .AddMutationType<MutationContent>()
                    .AddMutationType<MutationText>()
                    .AddMutationType<MutationString>()
                    .AddMutationType<MutationFloat>()
                    .AddMutationType<MutationBool>()
                    .Create(),
                new QueryExecutionOptions { ForceSerialExecution = true });

            services.AddScoped<IAsyncCreateStrategy<Content, CreateContentInput>, CreateContentStrategy>();
            services.AddScoped<IAsyncCreateStrategy<ContentTextMetaValue, CreateTextMetaValueInput>, CreateTextMetaValueStrategy>();
            services.AddScoped<IAsyncCreateStrategy<ContentStringMetaValue, CreateStringMetaValueInput>, CreateStringMetaValueStrategy>();
            services.AddScoped<IAsyncCreateStrategy<ContentFloatMetaValue, CreateFloatMetaValueInput>, CreateFloatMetaVaueStrategy>();
            services.AddScoped<IAsyncCreateStrategy<ContentBoolMetaValue, CreateBoolMetaValueInput>, CreateBoolMetaValueStrategy>();
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
