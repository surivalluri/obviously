using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Obviously.SemanticTypes.Generator.Templates.AspNetCore.ModelBinding;

namespace Obviously.SemanticTypes.Generator.Templates.AspNetCore
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
            services
                .AddControllers(options =>
                {
                    options.ModelBinderProviders.Insert(0, new AwesomeInt32SemanticType.AwesomeInt32SemanticTypeModelBinderProvider());
                    options.ModelBinderProviders.Insert(1, new AwesomeStringSemanticType.AwesomeStringSemanticTypeModelBinderProvider());
                    options.ModelBinderProviders.Insert(2, new ManualGuidSemanticTypeModelBinderProvider());
                    options.ModelBinderProviders.Insert(3, new AwesomeGuidSemanticType.AwesomeGuidSemanticTypeModelBinderProvider());
                });
            services.AddMvcCore(options =>
                {
                    options.EnableEndpointRouting = false;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
            });

            app.UseMvc();
        }
    }
}