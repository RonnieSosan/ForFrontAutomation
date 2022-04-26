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
            //code to clear the validation state
            ModelState.ClearValidationState(nameof(SpiderDeploymentModel));

            //check if the model state is valid and orompt the user if it is
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            //creat a spider instance
            Spider spiderManRodent = new Spider(model.XAxis, model.YAxis, model.MaxXAxis, model.MaxYAxis, model.CurrentDirection);

            //call the spider to pprocess a new command
            bool isAValidCoordinates = spiderManRodent.IsValidCoordinates();

            //check if thecoordinates provided is valid
            if (!isAValidCoordinates) {
                ModelState.AddModelError("XAxis", "The coordintes for the spider exceed the wall");
                ModelState.AddModelError("YAxis", "The coordintes for the spider exceed the wall");
                return View("Index", model );
            }
            else
            {
                spiderManRodent.ProcessCommand(model.Command);
            }

            //set the latest values for the current spider coordinates and direction
            model.XAxis = spiderManRodent.XAxis;
            model.YAxis = spiderManRodent.YAxis;
            model.CurrentDirection = spiderManRodent.CurrentDirection;

            return View("View", model);
        }
    }
}
