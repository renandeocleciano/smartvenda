using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartVendas.Application.Interfaces;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Mvc.Controllers
{
    [Authorize]
    public class NcmController : Controller
    {
        private readonly INcmAppService _app;

        public NcmController(INcmAppService app)
        {
            _app = app;
        }

        // GET: Ncm
        public ActionResult Index()
        {
            return View(_app.GetAll());
        }

        public ActionResult Details(Guid id)
        {
            var NcmViewModel = _app.GetById(id);

            return View(NcmViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NcmViewModel NcmViewModel)
        {
            if (ModelState.IsValid)
            {
                _app.Add(NcmViewModel);

                return RedirectToAction("Index");
            }

            return View(NcmViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var NcmViewModel = _app.GetById(id);

            return View(NcmViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NcmViewModel NcmViewModel)
        {
            if (ModelState.IsValid)
            {
                _app.Update(NcmViewModel);

                return RedirectToAction("Index");
            }

            return View(NcmViewModel);
        }
    }
}