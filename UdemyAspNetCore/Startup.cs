using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UdemyAspNetCore.Middlewares;

namespace UdemyAspNetCore
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
			services.AddSession();
			services.AddControllersWithViews();
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


			app.UseExceptionHandler("/Home/Error");
			app.UseStatusCodePagesWithReExecute("/Home/Status", "?code={0}");

			app.UseStaticFiles();
			//satatic dosyalarý sunmamýzý saðlar
			app.UseStaticFiles(new StaticFileOptions
			{
				RequestPath = "/node_modules",
				//node_modules klasörünün bilgisayardaki tam yolunu belirler.
				FileProvider = new PhysicalFileProvider(Path.Combine
					(Directory.GetCurrentDirectory(), "node_modules"))
			});

			


			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseSession();

			app.UseEndpoints(endpoints =>
			{
				//endpoints.MapControllerRoute(
				//	name: "productRoute",
				//	pattern: "Bilal/{action}",
				//	defaults: new { Controller = "Home" }
				//	);

				endpoints.MapControllerRoute(
					name: "areas",
					pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}"
					);

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{Controller}/{Action}/{id?}",
					defaults: new { Controller = "Home", Action = "Index" }
					);
			});

			//app.UseMiddleware<ResponseEditingMiddleware>();
			//app.UseMiddleware<RequestEditingMiddleware>();




			//app.UseAuthorization();


			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapRazorPages();
			//});
		}
	}
}
