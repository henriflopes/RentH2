using Microsoft.AspNetCore.Mvc;

namespace RentH2.Web.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult OrderIndex()
		{
			return View();
		}
	}
}
