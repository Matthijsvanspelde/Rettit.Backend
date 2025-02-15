using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Reddit.Logic;
using Reddit.Logic.ILogic;
using Reddit.Logic.Logic;
using Rettit.DAL;

namespace Rettit.API
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
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("_myAllowSpecificOrigins", policy =>
                {
                    policy.WithOrigins("https://rettit.azurewebsites.net", "https://localhost:44339")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            });
            });

            services.AddMvc();
                     
            using (var dbContext = new Context())
            {               
                dbContext.Database.EnsureCreated();
            }

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSession();
            services.AddControllers();
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<ISubForumLogic, SubForumLogic>();
            services.AddScoped<IPostLogic, PostLogic>();
            services.AddScoped<ICommentLogic, CommentLogic>();
            services.AddScoped<IFollowLogic, FollowLogic>();
            services.AddScoped<Context>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                IdentityModelEventSource.ShowPII = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("A-VERY-STRONG-KEY-HERE"))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();           
            app.UseRouting();
            app.UseCors("_myAllowSpecificOrigins");
            app.UseAuthentication(); //This one first
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
