using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TCAPP.API.Graphql.Contents;
using TCAPP.API.Graphql.Contents.ContentBoolMetaValues;
using TCAPP.API.Graphql.Contents.ContentFloatMetaValues;
using TCAPP.API.Graphql.Contents.ContentStringMetaValues;
using TCAPP.API.Graphql.Contents.ContentTextMetaValues;
using TCAPP.Business.ConcreteData.Contents;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.ConcreteData.Contents;
using TCAPP.DTO.RelationalData.ContentBoolMetaValues;
using TCAPP.DTO.RelationalData.ContentFloatMetaValues;
using TCAPP.DTO.RelationalData.ContentStringMetaValues;
using TCAPP.DTO.RelationalData.ContentTextMetaValues;
using TCAPP.Infrastructure.Generics;
using TCAPP.Business.RelationalData.ContentTextMetaValues;
using TCAPP.Business.RelationalData.ContentStringMetaValues;
using TCAPP.Business.RelationalData.ContentFloatMetaValues;
using TCAPP.Business.RelationalData.ContentBoolMetaValues;
using TCAPP.DTO.ConcreteData.Users;
using TCAPP.Business.ConcreteData.Users;
using TCAPP.Business.RelationalData.ContentTaxonomies;
using TCAPP.DTO.RelationalData.ContentTaxonomies;
using TCAPP.DTO.RelationalData.ParentContents;
using TCAPP.Business.RelationalData.ParentContents;
using TCAPP.DTO.RelationalData.UserContents;
using TCAPP.Business.RelationalData.UserContents;
using TCAPP.Domain.TypeData;
using TCAPP.TypeData.ContentMetaValueTypes;
using TCAPP.TypeData.ContentRelationTypes;
using TCAPP.DTO.TypeData.ContentTypes;
using TCAPP.DTO.TypeData.Taxonomies;
using TCAPP.Business.TypeData.ContentMetaValueTypes;
using TCAPP.Business.TypeData.ContentRelationTypes;
using TCAPP.Business.TypeData.ContentTypes;
using TCAPP.Business.TypeData.Taxonomies;
using TCAPP.API.Graphql.ContentTypes;
using TCAPP.API.Graphql.Users;
using TCAPP.API.Graphql.ContentRelationTypes;
using TCAPP.API.Graphql.MetaValueTypes;
using TCAPP.API.Graphql.Contents.ContentTaxonomies;
using TCAPP.API.Graphql.Taxonomies;
using TCAPP.API.Graphql.Contents.ParentContents;
using TCAPP.API.Graphql.Taxonomies.ParentTaxonomies;
using TCAPP.API.Graphql.Users.UserContents;
using TCAPP.API.Graphql.ObjectTypes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using TCAPP.API.JWT;

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
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<TCAPPContext>(o => o.UseMySql(Configuration.GetConnectionString("Test")), ServiceLifetime.Scoped);
            services.AddGraphQL(sp =>
                SchemaBuilder.New()
                    .AddServices(sp)
                    .AddQueryType(d => d.Name("Query"))
                    .AddMutationType(d => d.Name("Mutation"))
                    //.AddObjectType(d => d.Name("Type"))
                    .AddType<UserQuery>()
                    .AddType<UserMutation>()
                    .AddType<UserContentQuery>()
                    .AddType<UserContentMutation>()
                    .AddType<ContentTypeQuery>()
                    .AddType<ContentTypeMutation>()
                    .AddType<ContentQuery>()
                    .AddType<ContentMutation>()
                    .AddType<CreateTextMetaValueMutation>()
                    .AddType<ContentTextMetaValueQuery>()
                    .AddType<CreateStringMetaValueMutation>()
                    .AddType<ContentStringMetaValueQuery>()
                    .AddType<CreateFloatMetaValueMutation>()
                    .AddType<ContentFloatMetaValueQuery>()
                    .AddType<CreateBoolMetaValueMutation>()
                    .AddType<ContentBoolMetaValueQuery>()
                    .AddType<ContentRelationTypeQuery>()
                    .AddType<ContentRelationTypeMutation>()
                    .AddType<MetaValueTypeQuery>()
                    .AddType<MetaValueTypeMutation>()
                    .AddType<ContentTaxonomyQuery>()
                    .AddType<ContentTaxonomyMutation>()
                    .AddType<TaxonomyQuery>()
                    .AddType<TaxonomyMutation>()
                    .AddType<ParentTaxonomyQuery>()
                    .AddType<ParentTaxonomyMutation>()
                    .AddType<ParentContentQuery>()
                    .AddType<ParentContentMutation>()
                    //.AddType<UserObjectType>()
                    .Create(),
                new QueryExecutionOptions { ForceSerialExecution = true });

            ConfigureStrategies(services);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Jwt:Issuer"],
                            ValidAudience = Configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                            ClockSkew = TimeSpan.Zero
                        };
                    });
            services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.User, Policies.UserPolicy());
            });
        }

        private static void ConfigureStrategies(IServiceCollection services)
        {
            services.AddScoped<IAsyncCreateStrategy<Content, CreateContentInput>, CreateContentStrategy>();
            services.AddScoped<IAsyncUpdateStrategy<Content, UpdateContentInput>, UpdateContentStrategy>();

            services.AddScoped<IAsyncCreateStrategy<User, CreateUserInput>, CreateUserStrategy>();
            services.AddScoped<IAsyncUpdateStrategy<User, UpdateUserInput>, UpdateUserStrategy>();

            services.AddScoped<IAsyncCreateStrategy<ContentTextMetaValue, CreateTextMetaValueInput>, CreateContentTextMetaValueStrategy>();
            services.AddScoped<IAsyncUpdateStrategy<ContentTextMetaValue, UpdateTextMetaValueInput>, UpdateContentTextMetaValueStrategy>();
            services.AddScoped<IAsyncDeleteStrategy<DeleteTextMetaValueInput>, DeleteContentTextMetaValueStrategy>();

            services.AddScoped<IAsyncCreateStrategy<ContentStringMetaValue, CreateStringMetaValueInput>, CreateContentStringMetaValueStrategy>();
            services.AddScoped<IAsyncUpdateStrategy<ContentStringMetaValue, UpdateStringMetaValueInput>, UpdateContentStringMetaValueStrategy>();
            services.AddScoped<IAsyncDeleteStrategy<DeleteStringMetaValueInput>, DeleteContentStringMetaValueStrategy>();

            services.AddScoped<IAsyncCreateStrategy<ContentFloatMetaValue, CreateFloatMetaValueInput>, CreateContentFloatMetaVaueStrategy>();
            services.AddScoped<IAsyncUpdateStrategy<ContentFloatMetaValue, UpdateFloatMetaValueInput>, UpdateContentFloatMetaValueStrategy>();
            services.AddScoped<IAsyncDeleteStrategy<DeleteFloatMetaValueInput>, DeleteContentFloatMetaValueStrategy>();

            services.AddScoped<IAsyncCreateStrategy<ContentBoolMetaValue, CreateBoolMetaValueInput>, CreateContentBoolMetaValueStrategy>();
            services.AddScoped<IAsyncUpdateStrategy<ContentBoolMetaValue, UpdateBoolMetaValueInput>, UpdateContentBoolMetaValueStrategy>();
            services.AddScoped<IAsyncDeleteStrategy<DeleteBoolMetaValueInput>, DeleteContentBoolMetaValueStrategy>();

            services.AddScoped<IAsyncCreateStrategy<ContentTaxonomy, CreateOrDeleteContentTaxonomyInput>, CreateContentTaxonomyStrategy>();
            services.AddScoped<IAsyncDeleteStrategy<CreateOrDeleteContentTaxonomyInput>, DeleteContentTaxonomyStrategy>();

            services.AddScoped<IAsyncCreateStrategy<ParentContent, CreateOrDeleteParentInput>, CreateParentContentStrategy>();
            services.AddScoped<IAsyncDeleteStrategy<CreateOrDeleteParentInput>, DeleteParentContentStrategy>();

            services.AddScoped<IAsyncCreateStrategy<UserContent, CreateOrDeleteUserContentInput>, CreateUserContentStrategy>();
            services.AddScoped<IAsyncDeleteStrategy<CreateOrDeleteUserContentInput>, DeleteUserContentStrategy>();

            services.AddScoped<IAsyncCreateStrategy<MetaValueType, CreateContentMetaValueTypeInput>, CreateContentMetaValueTypeStrategy>();
            services.AddScoped<IAsyncUpdateStrategy<MetaValueType, UpdateContentMetaValueTypeInput>, UpdateContentMetaValueTypeStrategy>();

            services.AddScoped<IAsyncCreateStrategy<ContentRelationType, CreateContentRelationTypeInput>, CreateContentRelatonTypeStrategy>();
            services.AddScoped<IAsyncUpdateStrategy<ContentRelationType, UpdateContentRelationTypeInput>, UpdateContentRelationTypeStrategy>();

            services.AddScoped<IAsyncCreateStrategy<ContentType, CreateContentTypeInput>, CreateContentTypeStreategy>();
            services.AddScoped<IAsyncUpdateStrategy<ContentType, UpdateContentTypeInput>, UpdateContentTypeStrategy>();

            services.AddScoped<IAsyncCreateStrategy<ParentTaxonomy, CreateOrDeleteParentTaxonomyInput>, CreateParentTaxonomyStrategy>();
            services.AddScoped<IAsyncCreateStrategy<Taxonomy, CreateTaxonomyInput>, CreateTaxonomyStrategy>();
            services.AddScoped<IAsyncUpdateStrategy<Taxonomy, UpdateTaxonomyInput>, UpdateTaxonomyStrategy>();
            services.AddScoped<IAsyncDeleteStrategy<CreateOrDeleteParentTaxonomyInput>, DeleteParentTaxonomyStrategy>();
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

            app.UseAuthentication();
            app.UseAuthorization();

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
