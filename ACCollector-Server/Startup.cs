using ACCollector_Server.DataAccess;
using ACCollector_Server.DataAccess.Repositories;
using ACCollector_Server.Services;
using EntityFramework.DbContextScope;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

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
			services.AddMvc();
			services.AddTransient<GameService>();
			services.AddTransient<ReleaseService>();
			services.AddTransient<GameRepository>();
			services.AddTransient<ReleaseRepository>();
			services.AddTransient<BugService>();
			services.AddTransient<BugRepository>();
			services.AddTransient<IDbContextScopeFactory, DbContextScopeFactory>(BuildContextScopeFactory);
			services.AddTransient<IAmbientDbContextLocator, AmbientDbContextLocator>();
		}

		private DbContextScopeFactory BuildContextScopeFactory(IServiceProvider services)
		{
			const string CONNECTION = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ACCollector;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			var optionsBuilder = new DbContextOptionsBuilder<ACCollectorDbContext>();
			optionsBuilder.UseSqlServer(CONNECTION);

			var contextFactory = new ACCollectorDbContextFactory(optionsBuilder.Options);
			return new DbContextScopeFactory(contextFactory);
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