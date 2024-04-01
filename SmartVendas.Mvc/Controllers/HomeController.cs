using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SmartVendas.Application.Interfaces;
using SmartVendas.Infra.CrossCutting.Utils;

namespace SmartVendas.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioAppService _usuarioApp;

        public HomeController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var login = form["UserName"];
            var senha = form["Senha"];
            var c = new CryptUtil();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                TempData["Erro"] = "Login e/ou Senha Inválidos";
                return View();
            }
            
            var user = _usuarioApp.GetByUserAndPass(login, c.ActionEncrypt(senha));

            if (user != null && user.UsuarioId != null)
            {
                Response.Cookies.Add(new HttpCookie("IdLogin", Convert.ToString(user.UsuarioId)));
                FormsAuthentication.RedirectFromLoginPage(login, false);
            }

            TempData["Erro"] = "Login e/ou Senha Inválidos";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}