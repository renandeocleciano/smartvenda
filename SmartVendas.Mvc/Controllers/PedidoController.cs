using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartVendas.Application.Interfaces;
using SmartVendas.Application.ViewModels;
using System.Web.Script.Serialization;

namespace SmartVendas.Mvc.Controllers
{
    public class ProdutoQuantidade
    {
        public string ProdutoId { get; set; }
        public string Quantidade { get; set; }
    }

    public class PedidoController : Controller
    {
        // GET: Pedido
        private readonly IProdutoAppService _produtoAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly IPedidoAppService _pedidoAppService;
        private readonly IProdutoVendaAppService _produtoVendaAppService;

        public PedidoController(IProdutoAppService produtoAppService, 
            IProdutoVendaAppService produtoVendaAppService,
            IClienteAppService clienteAppService,
            IPedidoAppService pedidoAppService)
        {
            _produtoAppService = produtoAppService;
            _clienteAppService = clienteAppService;
            _pedidoAppService  = pedidoAppService;
            _produtoVendaAppService = produtoVendaAppService;
        }


        public ActionResult Index()
        {
            return View(_pedidoAppService.GetAll());
        }

        public ActionResult PedidosDoDia()
        {
            return View("Index", _pedidoAppService.GetAll().Where(c => c.DataCadastro.Date >= DateTime.Today));
        }

        public ActionResult PedidosAguardando()
        {
            return View("Index", _pedidoAppService.GetAll().Where(c => c.Status == StatusPedidoViewModel.Aguardando));
        }

        public ActionResult PedidosEmProducao()
        {
            return View("Index", _pedidoAppService.GetAll().Where(c => c.Status == StatusPedidoViewModel.Produção));
        }

        public ActionResult PedidosFinalizados()
        {
            return View("Index", _pedidoAppService.GetAll().Where(c => c.Status == StatusPedidoViewModel.Finalizado));
        }

        public ActionResult PedidosCancelados()
        {
            return View("Index", _pedidoAppService.GetAll().Where(c => c.Status == StatusPedidoViewModel.Cancelado));
        }

        public ActionResult SetStatusEmProducao(string pedidoId)
        {
            var pedido = _pedidoAppService.GetById(Guid.Parse(pedidoId));
            
            pedido.Status = StatusPedidoViewModel.Produção;
            pedido.Cliente = null;
            pedido.ProdutoVendaList = null;
            pedido.DhProducao = DateTime.Now;

            _pedidoAppService.Update(pedido);

            return RedirectToAction("PedidosDoDia", "Pedido");
        }

        public ActionResult SetStatusFinalizado(string pedidoId)
        {
            var pedido = _pedidoAppService.GetById(Guid.Parse(pedidoId));

            pedido.Status = StatusPedidoViewModel.Finalizado;
            pedido.Cliente = null;
            pedido.ProdutoVendaList = null;
            pedido.DhFinalizado = DateTime.Now;

            _pedidoAppService.Update(pedido);

            return RedirectToAction("PedidosDoDia", "Pedido");
        }

        public ActionResult SetStatusCancelado(string pedidoId)
        {
            var pedido = _pedidoAppService.GetById(Guid.Parse(pedidoId));

            pedido.Status = StatusPedidoViewModel.Cancelado;
            pedido.Cliente = null;
            pedido.ProdutoVendaList = null;

            _pedidoAppService.Update(pedido);

            return RedirectToAction("PedidosDoDia", "Pedido");
        }

        public ActionResult Create(string cliente)
        {
            var produtos = _produtoAppService.GetAll();
            ViewBag.ProdutoJson = new JavaScriptSerializer().Serialize(produtos);
            ViewBag.Produto = new SelectList(produtos.OrderBy(e => e.Nome), "ProdutoId", "Nome");
            ViewBag.Cliente = new SelectList(_clienteAppService.GetAll().OrderBy(e => e.ClienteId), "ClienteId", "Nome", cliente);


            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            var clienteId = collection["ClienteId"].Split(',').First();
            var produtos = collection["ProdutoQuantidade"];
            var jss = new JavaScriptSerializer();
            var jsonProduto = jss.Deserialize<List<ProdutoQuantidade>>(produtos);

            var pedido = new PedidoViewModel();

            pedido.ClienteId = Guid.Parse(clienteId);
            pedido.ProdutoVendaList = null;
            pedido.Cliente = null;
            pedido.DhInicio = DateTime.Now;
            pedido.DhProducao = DateTime.Now;
            pedido.DhFinalizado = DateTime.Now;
            pedido.Pago = false;

            _pedidoAppService.Add(pedido);

            foreach (var j in jsonProduto)
            {
                var pv = new ProdutoVendaViewModel();
                var produto = _produtoAppService.GetById(Guid.Parse(j.ProdutoId));
                pv.Produto = null;
                pv.ProdutoId = Guid.Parse(j.ProdutoId);
                pv.PedidoId = pedido.PedidoId;
                pv.Quantidade = Convert.ToDecimal(j.Quantidade);
                pv.Valor = produto.Valor;

                _produtoVendaAppService.Add(pv);
            }

                return RedirectToAction("PedidosDoDia", "Pedido");
        }
        
    }
}