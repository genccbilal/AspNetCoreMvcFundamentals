using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UdemyAspNetCore.Models;

namespace UdemyAspNetCore.Controllers.Home
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			var customers = CustomerContext.Customers;
			return View(customers);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Customer customer)
		{
			ModelState.Remove("Id");

			//Bu şekilde Özel Validation kuralları koya biliriz
			if (customer.FirstName == "Ali")
			{
				ModelState.AddModelError("", "Fristname Ali Olamaz");
			}

			if (ModelState.IsValid)
			{
				Customer lastCustomer = null;
				if (CustomerContext.Customers.Count > 0)
				{
					//Customers listesinin son öğesini alır.
					lastCustomer = CustomerContext.Customers.Last();
				}
				customer.Id = 1;

				if (lastCustomer != null)
				{
					customer.Id = lastCustomer.Id + 1;
				}

				CustomerContext.Customers.Add(customer);

				return RedirectToAction("Index");
			}
			return View();


		}

		[HttpGet]
		public IActionResult Remove(int id)
		{
			//var id =int.Parse (RouteData.Values["id"].ToString());

			var removedCustomer = CustomerContext.Customers.Find(I => I.Id == id);
			CustomerContext.Customers.Remove(removedCustomer);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Update(int id)
		{
			//var id = int.Parse(RouteData.Values["id"].ToString());
			var updateCustomer = CustomerContext.Customers.FirstOrDefault(a => a.Id == id);
			return View(updateCustomer);
		}

		[HttpPost]
		public IActionResult Update(Customer customer)
		{
			//var id = int.Parse(HttpContext.Request.Form["id"].ToString());
			var updateCustomer = CustomerContext.Customers.FirstOrDefault(I => I.Id == customer.Id);

			//updateCustomer.FirstName = HttpContext.Request.Form["firstName"].ToString();
			//updateCustomer.LastName = HttpContext.Request.Form["lastName"].ToString();
			//updateCustomer.Age = int.Parse(HttpContext.Request.Form["age"].ToString());

			updateCustomer.FirstName = customer.FirstName;
			updateCustomer.LastName = customer.LastName;
			updateCustomer.Age = customer.Age;


			return RedirectToAction("Index");
		}

		public IActionResult Status(int? code)
		{
			return View();
		}

		public IActionResult Error()
		{
			var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

			var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");

			//15/03/2025 15:30:12
			var logFileName = DateTime.Now.ToString();

			logFileName = logFileName.Replace(" ", "_");
			logFileName = logFileName.Replace(":", "-");
			logFileName = logFileName.Replace("/", "-");
			//15-03-2025_15:30:12

			logFileName += ".txt";
			var logFilePath = Path.Combine(logFolderPath, logFileName);

			

			DirectoryInfo directoryInfo = new DirectoryInfo(logFolderPath);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}

			FileInfo fileInfo = new FileInfo(logFilePath);
			var write = fileInfo.CreateText();
			write.WriteLine("Hatanın gerçekleştiği yer: " + exceptionHandlerPathFeature.Path);
			write.WriteLine("Hata mesajı: " + exceptionHandlerPathFeature.Error.Message);
			write.Close();

			return View();
		}

		public IActionResult Hata()
		{
			throw new System.Exception("Sistemsel Bir Hata Oluştu");
		}

	}
}
