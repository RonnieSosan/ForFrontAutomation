using ForFrontAutomation.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForFront.Web.Controllers
{
    public class SpiderController : Controller
    {
        
        // POST: SpiderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection collection)
        {
            return View("DeploySpider");
        }

        // GET: SpiderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpiderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SpiderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpiderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
