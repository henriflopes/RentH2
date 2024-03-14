using Microsoft.AspNetCore.Mvc;

namespace RentH2.Web.Controllers
{
	public class CartController : Controller
	{
		public IActionResult CartIndex()
		{
			return View();
		}
	}
}
