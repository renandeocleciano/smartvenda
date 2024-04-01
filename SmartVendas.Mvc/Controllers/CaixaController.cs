using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SmartVendas.Application.Interfaces;
using SmartVendas.Application.ViewModels;
using System.Web.Script.Serialization;
using SmartVendas.Application.ViewModels.Enumerators;
using System.Drawing;
using System.Drawing.Printing;

namespace SmartVendas.Mvc.Controllers
{
    public class CaixaController : Controller
    {
        // GET: Pedido
        private readonly ICaixaAppService _caixaAppService;
        private readonly ILancamentoCaixaAppService _lancamentoCaixaAppService;
        private Guid _caixaId;

        public CaixaController(ICaixaAppService caixaAppService,
            ILancamentoCaixaAppService lancamentoCaixaAppService)
        {
            _caixaAppService = caixaAppService;
            _lancamentoCaixaAppService = lancamentoCaixaAppService;
        }

        public ActionResult Index()
        {
            return View(_caixaAppService.GetAll());
        }

        public ActionResult AbrirCaixa()
        {
            var caixaAberto = _caixaAppService.GetOpened();
            ViewBag.CaixaABerto = caixaAberto != null;

            var caixa = new CaixaViewModel
            {
                Abertura = DateTime.Now
            };
            return View(caixa);
        }

        [HttpPost]
        public ActionResult AbrirCaixa(CaixaViewModel caixa)
        {
            if (!ModelState.IsValid) return View(caixa);

            caixa.CaixaId = Guid.NewGuid();
            caixa.Abertura = DateTime.Now;
            _caixaAppService.Add(caixa);

            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult LancamentoManual()
        {
            var caixaAberto = _caixaAppService.GetOpened();
            if (caixaAberto == null)
            {
                return RedirectToAction("AbrirCaixa");
            }

            var lancamentoCaixa = new LancamentoCaixaViewModel()
            {
                CaixaId = caixaAberto.CaixaId,
                Caixa = caixaAberto
            };
            return View(lancamentoCaixa);
        }

        [HttpPost]
        public ActionResult LancamentoManual(LancamentoCaixaViewModel lancamentoCaixa)
        {
            var caixaAberto = _caixaAppService.GetById(lancamentoCaixa.CaixaId);
            if (lancamentoCaixa.Valor == 0)
            {
                ModelState.AddModelError("Valor", "Valor deve ser diferente de ZERO!");
            }
            if (!ModelState.IsValid)
            {
                lancamentoCaixa.Caixa = caixaAberto;

                return View(lancamentoCaixa);
            }
            lancamentoCaixa.LancamentoCaixaId = Guid.NewGuid();
            _lancamentoCaixaAppService.Add(lancamentoCaixa);

            if (lancamentoCaixa.Tipo == TipoLancamentoCaixaViewModel.Entrada)
                caixaAberto.Entradas += lancamentoCaixa.Valor;

            if (lancamentoCaixa.Tipo == TipoLancamentoCaixaViewModel.Saida)
                caixaAberto.Saidas += lancamentoCaixa.Valor;

            caixaAberto.Lancamentos = null;
            _caixaAppService.Update(caixaAberto);

            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult FechamentoCaixa()
        {
            var caixaAberto = _caixaAppService.GetOpened();
            if (caixaAberto == null)
            {
                return RedirectToAction("AbrirCaixa");
            }
            return View(caixaAberto);
        }

        [HttpPost(), ActionName("FechamentoCaixa")]
        public ActionResult FechamentoCaixaConfirmed()
        {
            var caixaAberto = _caixaAppService.GetOpened();
            caixaAberto.Fechamento = DateTime.Now;
            caixaAberto.Lancamentos = null;
            _caixaAppService.Update(caixaAberto);

            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult ImprimirRelatorioFechamento(Guid caixaId)
        {
            _caixaId = caixaId;

            ImprimirCupomFiscal();
            
            return RedirectToAction("Index");
        }

        private void ImprimirCupomFiscal()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = "MP-4200 TH";
            printDoc.DocumentName = "Fechamento de Caixa";

            if (!printDoc.PrinterSettings.IsValid)
                throw new Exception("Não foi possível localizar a impressora");

            printDoc.PrintPage += new PrintPageEventHandler(PrintPageFicha);

            ; printDoc.Print();
        }

        private void PrintPageFicha(object sender, PrintPageEventArgs ev)
        {
            var p = _caixaAppService.GetById(_caixaId);

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

            ev.Graphics.DrawString("   ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("   ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Fechamento de Caixa", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Fechamento de Caixa", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("   ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("   ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Data/Hora Abertura: " + p.Abertura, pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Data/Hora Abertura: " + p.Abertura, pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("   ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("   ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Data/Hora Fechamento: " + p.Fechamento, pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Data/Hora Fechamento : " + p.Fechamento, pdvFont);
            currentUsedHeight += size.Height;
            
            ev.Graphics.DrawString("      ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("      ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Saldo Inicial: " + p.SaldoInicial, pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Saldo Inicial: " + p.SaldoInicial, pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("      ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("      ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Entradas: R$" + p.Entradas, pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Entradas: R$" + p.Entradas, pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("      ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("      ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Saidas: R$" + p.Saidas, pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Entradas: R$" + p.Saidas, pdvFont);
            currentUsedHeight += size.Height;
            
            ev.Graphics.DrawString("      ", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("      ", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Total Final: R$" + p.Total, pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Total Final: R$" + p.Total, pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Desenvolvido por T&S Soluções", obsFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("Desenvolvido por T&S Soluções", obsFont);
            currentUsedHeight += size.Height;
        }

    }
}