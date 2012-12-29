using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4TestBed.Models;

namespace MVC4TestBed.Controllers
{   
    public class TemplateTestsController : Controller
    {
		private readonly ITemplateTestRepository templatetestRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public TemplateTestsController() : this(new TemplateTestRepository())
        {
        }

        public TemplateTestsController(ITemplateTestRepository templatetestRepository)
        {
			this.templatetestRepository = templatetestRepository;
        }

        //
        // GET: /TemplateTests/

        public ViewResult Index()
        {
            return View(templatetestRepository.All);
        }

        //
        // GET: /TemplateTests/Details/5

        public ViewResult Details(int id)
        {
            return View(templatetestRepository.Find(id));
        }

        //
        // GET: /TemplateTests/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TemplateTests/Create

        [HttpPost]
        public ActionResult Create(TemplateTest templatetest)
        {
            if (ModelState.IsValid) {
                templatetestRepository.InsertOrUpdate(templatetest);
                templatetestRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /TemplateTests/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(templatetestRepository.Find(id));
        }

        //
        // POST: /TemplateTests/Edit/5

        [HttpPost]
        public ActionResult Edit(TemplateTest templatetest)
        {
            if (ModelState.IsValid) {
                templatetestRepository.InsertOrUpdate(templatetest);
                templatetestRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /TemplateTests/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(templatetestRepository.Find(id));
        }

        //
        // POST: /TemplateTests/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            templatetestRepository.Delete(id);
            templatetestRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                templatetestRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

