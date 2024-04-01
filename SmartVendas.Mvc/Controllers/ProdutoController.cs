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
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly ITipoProdutoAppService _tipoProdutoApp;
        private readonly IUnidadeMedidaAppService _unidadeMedidaApp;
        private readonly INcmAppService _ncmApp;
        
        public ProdutoController(IProdutoAppService produtoApp, ITipoProdutoAppService tipoPrdutoApp,
            IUnidadeMedidaAppService unidadeMedidaApp, INcmAppService ncmApp)
        {
            _produtoApp = produtoApp;
            _tipoProdutoApp = tipoPrdutoApp;
            _unidadeMedidaApp = unidadeMedidaApp;
            _ncmApp = ncmApp;
        }

        // GET: Produto
        public ActionResult Index()
        {
            return View(_produtoApp.GetAll());
        }

        public ActionResult Details(Guid id)
        {
            var produtoViewModel = _produtoApp.GetByIdReadOnly(id);

            return View(produtoViewModel);
        }

        public ActionResult Create()
        {
            ViewBag.TipoProdutoId = new SelectList(_tipoProdutoApp.GetAll(), "TipoProdutoId", "Nome");
            ViewBag.UnidadeMedidaId = new SelectList(_unidadeMedidaApp.GetAll(), "UnidadeMedidaId", "Descricao");
            ViewBag.NcmId = new SelectList(_ncmApp.GetAll(), "NcmId", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _produtoApp.Add(produtoViewModel);

                return RedirectToAction("Index");
            }

            ViewBag.TipoProdutoId = new SelectList(_tipoProdutoApp.GetAll(), "TipoProdutoId", "Nome", produtoViewModel.TipoProdutoId);
            ViewBag.UnidadeMedidaId = new SelectList(_unidadeMedidaApp.GetAll(), "UnidadeMedidaId", "Descricao", produtoViewModel.UnidadeMedidaId);
            ViewBag.NcmId = new SelectList(_ncmApp.GetAll(), "NcmId", "Descricao", produtoViewModel.NcmId);
            return View(produtoViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var produtoViewModel = _produtoApp.GetByIdReadOnly(id);

            ViewBag.TipoProdutoId = new SelectList(_tipoProdutoApp.GetAll(), "TipoProdutoId", "Nome", produtoViewModel.TipoProdutoId);
            ViewBag.UnidadeMedidaId = new SelectList(_unidadeMedidaApp.GetAll(), "UnidadeMedidaId", "Descricao", produtoViewModel.UnidadeMedidaId);
            ViewBag.NcmId = new SelectList(_ncmApp.GetAll(), "NcmId", "Descricao", produtoViewModel.NcmId);

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _produtoApp.Update(produtoViewModel);

                return RedirectToAction("Index");
            }

            ViewBag.TipoProdutoId = new SelectList(_tipoProdutoApp.GetAll(), "TipoProdutoId", "Nome", produtoViewModel.TipoProdutoId);
            ViewBag.UnidadeMedidaId = new SelectList(_unidadeMedidaApp.GetAll(), "UnidadeMedidaId", "Descricao", produtoViewModel.UnidadeMedidaId);
            ViewBag.NcmId = new SelectList(_ncmApp.GetAll(), "NcmId", "Descricao", produtoViewModel.NcmId);

            return View(produtoViewModel);
        }
    }
}