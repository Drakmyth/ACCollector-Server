using JetBrains.Annotations;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ACCollector_Server
{
	public static class Program
	{
		public static void Main()
		{
			IWebHost host = new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.UseSetting(WebHostDefaults.PreventHostingStartupKey, "true")
				.UseApplicationInsights()
				.Build();

			host.Run();
		}
	}
}