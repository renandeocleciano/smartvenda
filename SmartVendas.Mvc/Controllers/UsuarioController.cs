using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartVendas.Application.Interfaces;
using SmartVendas.Application.ViewModels;
using SmartVendas.Infra.CrossCutting.Utils;

namespace SmartVendas.Mvc.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioApp;
        private readonly ITipoUsuarioAppService _tipoUsuarioApp;

        public UsuarioController(IUsuarioAppService usuarioApp, ITipoUsuarioAppService tipoUsuarioApp)
        {
            _usuarioApp = usuarioApp;
            _tipoUsuarioApp = tipoUsuarioApp;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View(_usuarioApp.GetAll());
        }

        public ActionResult Details(Guid id)
        {
            var usuarioViewModel = _usuarioApp.GetById(id);

            return View(usuarioViewModel);
        }

        public ActionResult Create()
        {
            ViewBag.TipoUsuarioId = new SelectList(_tipoUsuarioApp.GetAll(), "TipoUsuarioId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var crypt = new CryptUtil();
                var senha = crypt.ActionEncrypt(usuarioViewModel.Senha);
                usuarioViewModel.Senha = senha;
                _usuarioApp.Add(usuarioViewModel);

                return RedirectToAction("Index");
            }

            ViewBag.TipoUsuarioId = new SelectList(_tipoUsuarioApp.GetAll(), "TipoUsuarioId", "Nome", usuarioViewModel.TipoUsuarioId);
            return View(usuarioViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var usuarioViewModel = _usuarioApp.GetById(id);

            ViewBag.TipoUsuarioId = new SelectList(_tipoUsuarioApp.GetAll(), "TipoUsuarioId", "Nome", usuarioViewModel.TipoUsuarioId);

            var crypt = new CryptUtil();
            var senha = crypt.ActionDecrypt(usuarioViewModel.Senha);
            usuarioViewModel.Senha = senha;

            return View(usuarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var crypt = new CryptUtil();
                var senha = crypt.ActionEncrypt(usuarioViewModel.Senha);
                usuarioViewModel.Senha = senha;
                _usuarioApp.Update(usuarioViewModel);

                return RedirectToAction("Index");
            }

            ViewBag.TipoUsuarioId = new SelectList(_tipoUsuarioApp.GetAll(), "TipoProdutoId", "Nome", usuarioViewModel.TipoUsuarioId);

            return View(usuarioViewModel);
        }
    }
}