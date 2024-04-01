using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartVendas.Application.Interfaces;
using SmartVendas.Application.ViewModels;
using System.Web.Script.Serialization;
using System.Drawing.Printing;
using System.Drawing;

namespace SmartVendas.Mvc.Controllers
{
    
    [Authorize]
    public class VendaController : Controller
    {
        private readonly IVendaAppService _vendaAppService;
        private readonly IProdutoAppService _produtoAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly ITipoVendaAppService _tipoVendaAppService;
        private readonly IProdutoVendaAppService _produtoVendaAppService;
        private readonly IPedidoAppService _pedidoAppService;
        private readonly ICaixaAppService _caixaAppService;

        private Guid _vendaId;

        public VendaController(IVendaAppService vendaApp, 
            IProdutoAppService produtoAppService, 
            IClienteAppService clienteAppService, 
            ITipoVendaAppService tipoVendaAppService,
            IProdutoVendaAppService produtoVendaAppService,
            IPedidoAppService pedidoAppService,
            ICaixaAppService caixaAppService)
        {
            _vendaAppService = vendaApp;
            _produtoAppService = produtoAppService;
            _clienteAppService = clienteAppService;
            _tipoVendaAppService = tipoVendaAppService;
            _produtoVendaAppService = produtoVendaAppService;
            _pedidoAppService = pedidoAppService;
            _caixaAppService = caixaAppService;
        }

        // GET: Venda
        public ActionResult Index(string cliente)
        {
            if (string.IsNullOrEmpty(cliente))
            {
                return RedirectToAction("Index", "Cliente");
            }

            var produtos = _produtoAppService.GetAll();
            ViewBag.ProdutoJson = new JavaScriptSerializer().Serialize(produtos);
            ViewBag.Produto = new SelectList(produtos.OrderBy(e => e.Nome), "ProdutoId", "Nome");
            
            var c = _clienteAppService.GetById(Guid.Parse(cliente));
            ViewBag.NomeCliente = c.Nome;
            ViewBag.Cpf = c.Cpf;
            
            return View();
        }

        public ActionResult Create(string pedidoId)
        {
            var pedido = _pedidoAppService.GetById(Guid.Parse(pedidoId));
            ViewBag.TipoVenda = new SelectList(_tipoVendaAppService.GetAll().OrderBy(e => e.TipoVendaId), "TipoVendaId", "Nome");

            return View(pedido);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var pedidoId = collection["PedidoId"].Split(',').First();
            var tipoVenda = collection["TipoVenda"];
            
            var venda = new VendaViewModel();
            venda.PedidoId = Guid.Parse(pedidoId);
            venda.Desconto = 0;
            venda.Ativo = true;
            venda.TipoVendaId = Guid.Parse(tipoVenda);
            venda.TipoVenda = null;

            _vendaAppService.Add(venda);


            var pedido = _pedidoAppService.GetById(Guid.Parse(pedidoId));

            var caixaAberto = _caixaAppService.GetOpened();
            caixaAberto.Lancamentos = null;
            caixaAberto.Entradas += pedido.ProdutoVendaList.Sum(p => p.Quantidade * p.Valor);

            pedido.Cliente = null;
            pedido.ProdutoVendaList = null;
            pedido.Pago = true;

            _pedidoAppService.Update(pedido);
            _caixaAppService.Update(caixaAberto);

            _vendaId = venda.VendaId;
            
            ImprimirCupomFiscal();
            ImprimirCupomFiscal();

            return RedirectToAction("Index", "Pedido");
        }

        public ActionResult VendasEfetuadas()
        {
            return View(_vendaAppService.GetAll());
        }

        
        private void ImprimirCupomFiscal()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = "MP-4200 TH";
            printDoc.DocumentName = "Cupom";

            if (!printDoc.PrinterSettings.IsValid)
                throw new Exception("Não foi possível localizar a impressora");

            printDoc.PrintPage += new PrintPageEventHandler(PrintPageFicha);

           ; printDoc.Print();
        }

        private void PrintPageFicha(object sender, PrintPageEventArgs ev)
        {
            var v = _vendaAppService.GetById(_vendaId);
            var p = _pedidoAppService.GetById(v.PedidoId);
            
            System.Drawing.Font titleFont = new System.Drawing.Font("Segoe UI", 17f, FontStyle.Bold);
            System.Drawing.Font pdvFont = new System.Drawing.Font("Segoe UI", 7f, FontStyle.Regular);
            System.Drawing.Font obsFont = new System.Drawing.Font("Segoe UI", 7f, FontStyle.Regular);

            SizeF size = new SizeF();
            float currentUsedHeight = 0f;


            ev.Graphics.DrawString("Tap's Burguer", titleFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Tap's Burguer", titleFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Taps Burguer - Tapiocaria", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Taps Burguer - Tapiocaria", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Avenida Ayrton Senna, 5500 - Q29", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Avenida Ayrton Senna, 5500 - Q29", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Jacarepagua - Rio de Janeiro", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Jacarepagua - Rio de Janeiro", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Cnpj: 18.692.701/0001-02", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Cnpj: 18.692.701/0001-02", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("IE: 87.140.792", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("IE: 87.140.792", pdvFont);
            currentUsedHeight += size.Height;
            
            ev.Graphics.DrawString("   ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("   ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("ID : " + v.VendaId, pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("ID : " + v.VendaId, pdvFont);
            currentUsedHeight += size.Height;
            
            ev.Graphics.DrawString("   ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("   ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Cliente : " + p.Cliente.Nome, pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Cliente : " + p.Cliente.Nome, pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Cpf : " + p.Cliente.Cpf, pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Cpf : " + p.Cliente.Cpf, pdvFont);
            currentUsedHeight += size.Height;

            var totalFinal = 0.00m;
            
            ev.Graphics.DrawString("      ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("      ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Produto | Valor | Qtd | Total", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("      ", pdvFont);
            currentUsedHeight += size.Height;

            foreach (var pl in p.ProdutoVendaList)
            {
                ev.Graphics.DrawString(string.Format("{0} | R$ {1} | {2} | {3}", pl.Produto.Nome, pl.Produto.Valor, pl.Quantidade, (pl.Quantidade * pl.Valor)), pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(string.Format("{0} | R$ {1} | {2} | {3}", pl.Produto.Nome, pl.Produto.Valor, pl.Quantidade, (pl.Quantidade * pl.Valor)), pdvFont);
                currentUsedHeight += size.Height;
                totalFinal += (pl.Quantidade*pl.Valor);
            }
            
            ev.Graphics.DrawString("      ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("      ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString(string.Format("Total Final : {0:c}", totalFinal), pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString(string.Format("Total Final : {0:c}", totalFinal), pdvFont);
            currentUsedHeight += size.Height;
            
            ev.Graphics.DrawString("      ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("      ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Desenvolvido por T&S Soluções", obsFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Desenvolvido por T&S Soluções", obsFont);
            currentUsedHeight += size.Height;
        }
    }
}