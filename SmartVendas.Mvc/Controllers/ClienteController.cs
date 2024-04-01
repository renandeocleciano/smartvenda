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
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteApp;

        public ClienteController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            return View(_clienteApp.GetAll());
        }

        public ActionResult Details(Guid id)
        {
            var clienteViewModel = _clienteApp.GetById(id);

            return View(clienteViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteApp.Add(clienteViewModel);

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var clienteViewModel = _clienteApp.GetById(id);
            
            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteApp.Update(clienteViewModel);

                return RedirectToAction("Index");
            }
            
            return View(clienteViewModel);
        }
    }
}