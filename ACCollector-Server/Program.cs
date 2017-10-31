using JetBrains.Annotations;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ACCollector_Server
{
	[UsedImplicitly]
	public class Program
	{
		public static void Main(string[] args)
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