using ACCollector_Server.Repositories;
using ACCollector_Server.Services;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ACCollector_Server
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		[UsedImplicitly]
		public void ConfigureServices(IServiceCollection services)
		{
			var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ACCollector;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			services.AddDbContext<GameRepository>(options => options.UseSqlServer(connection));
			services.AddMvc();
			services.AddTransient<GameService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		[UsedImplicitly]
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMvc();
		}
	}
}