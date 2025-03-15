using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAspNetCore.Controllers.Home
{

	public class ProductController : Controller
	{
		public IActionResult index(int id)
		{
			return View();
		}
	}
}
