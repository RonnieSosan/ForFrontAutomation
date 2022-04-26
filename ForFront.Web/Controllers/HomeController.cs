using ForFront.Web.Models;
using ForFrontAutomation.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ForFront.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult IndexRedirect(SpiderDeploymentModel model)
        {
            return View("Index");
        }

        public IActionResult DeploySpider(SpiderDeploymentModel model)
        {
            ModelState.ClearValidationState(nameof(SpiderDeploymentModel));

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            //creat a spider instance
            Spider spiderManRodent = new Spider(model.XAxis, model.YAxis, model.MaxXAxis, model.MaxYAxis, model.CurrentDirection);

            //call the spider to pprocess a new command
            bool isAValidCommand = spiderManRodent.IsValidStartingPosition();

            if (!isAValidCommand) {
                ModelState.AddModelError("XAxis", "The coordintes for the spider exceed the wall");
                ModelState.AddModelError("YAxis", "The coordintes for the spider exceed the wall");
                return View("Index", model );
            }
            else
            {
                spiderManRodent.ProcessCommand(model.Command);
            }

            model.XAxis = spiderManRodent.XAxis;
            model.YAxis = spiderManRodent.YAxis;
            model.CurrentDirection = spiderManRodent.CurrentDirection;
            return View("View", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
