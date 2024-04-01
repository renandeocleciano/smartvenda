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
    public class UnidadeMedidaController : Controller
    {
        private readonly IUnidadeMedidaAppService _app;

        public UnidadeMedidaController(IUnidadeMedidaAppService app)
        {
            _app = app;
        }

        // GET: UnidadeMedida
        public ActionResult Index()
        {
            return View(_app.GetAll());
        }

        public ActionResult Details(Guid id)
        {
            var unidadeMedidaViewModel = _app.GetById(id);

            return View(unidadeMedidaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UnidadeMedidaViewModel unidadeMedidaViewModel)
        {
            if (ModelState.IsValid)
            {
                _app.Add(unidadeMedidaViewModel);

                return RedirectToAction("Index");
            }

            return View(unidadeMedidaViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var unidadeMedidaViewModel = _app.GetById(id);

            return View(unidadeMedidaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UnidadeMedidaViewModel unidadeMedidaViewModel)
        {
            if (ModelState.IsValid)
            {
                _app.Update(unidadeMedidaViewModel);

                return RedirectToAction("Index");
            }

            return View(unidadeMedidaViewModel);
        }
    }
}