using DockerDemo.EntityFrameworkCore;
using DockerDemo.Helpers;
using DockerDemo.Services;
using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders.Thrift;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OpenTracing;
using OpenTracing.Contrib.NetCore.Configuration;
using Serilog.Context;

namespace DockerDemo
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DockerDemo", Version = "v1" });
            });

            services.AddOpenTracing();

            services.AddSingleton<ITracer>(sp =>
            {
                var serviceName = sp.GetRequiredService<IWebHostEnvironment>().ApplicationName;

                var loggerFactory = sp.GetRequiredService<ILoggerFactory>();

                var reporter = new RemoteReporter.Builder()
                    .WithLoggerFactory(loggerFactory)
                    .WithSender(new UdpSender(Configuration["JaegerIp"], UdpSender.DefaultAgentUdpCompactPort, 0))
                    .Build();

                var tracer = new Tracer.Builder(serviceName)
                    .WithSampler(new ConstSampler(true))
                    .WithReporter(reporter)
                    .Build();

                return tracer;
            });

            services.Configure<HttpHandlerDiagnosticOptions>(options =>
                options.OperationNameResolver =
                    request => $"{request.Method.Method}: {request?.RequestUri?.AbsoluteUri}");


            string mySqlConnectionStr = Configuration.GetConnectionString("Default");

            services.AddDbContextPool<DemoDockerDbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddScoped<ITemplateAppService, RazorViewsTemplateAppService>();
            
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddMvc();

            MongoDbConst.MongoDbConnectionString = Configuration["MongoDbConfig:MongoDb"];
            MongoDbConst.DatabaseName = Configuration["MongoDbConfig:DatabaseName"];
            MongoDbConst.CollectionName = Configuration["MongoDbConfig:CollectionName"];
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                var tracer = app.ApplicationServices.GetRequiredService<ITracer>();

                LogContext.PushProperty(TraceJaegerConst.TraceJaegerKey, $"{(tracer?.ActiveSpan != null ? $"{tracer.ActiveSpan.Context.TraceId} " : "")}");

                await next();
            });


            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DockerDemo v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            env.PreparePuppeteerAsync().GetAwaiter().GetResult();
        }
    }
}
