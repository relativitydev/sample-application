using kCura.Relativity.Client;
using Relativity.API;
using Relativity.Services.Objects;
using System;
using System.Web.Mvc;

namespace SampleCustomPage.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			IAPILog logger = Relativity.CustomPages.ConnectionHelper.Helper().GetLoggerFactory().GetLogger();

			try
			{
				//Get the user's first and last name with Relativity API Helpers
				String firstName = Relativity.CustomPages.ConnectionHelper.Helper().GetAuthenticationManager().UserInfo.FirstName;
				String lastName = Relativity.CustomPages.ConnectionHelper.Helper().GetAuthenticationManager().UserInfo.LastName;

				//Get the current time
				String currentTime = DateTime.Now.ToLongTimeString();

				//Set the text value        
				String helloStr = String.Format("Hello {0} {1}! The current time is: {2}",
					firstName,
					lastName,
					currentTime);

				//Set message
				ViewBag.Message = helloStr;

				logger.LogVerbose("Log information throughout execution.");
			}
			catch (Exception ex)
			{
				//Your custom page caught an exception
				logger.LogError(ex, "There was an exception.");
			}

			return View();
		}
	}
}