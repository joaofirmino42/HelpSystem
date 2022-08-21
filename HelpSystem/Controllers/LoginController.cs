using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using Newtonsoft.Json;
using System.Web.Globalization;
using HelpSystem.Models;
using Business;
using Business.Util;
using Data.Entity;
namespace HelpSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastraUsuario()
        {
            return View();
        }
        public ActionResult Logar(Usuario usuario)
        {

            try
            {
                CriptografiaBusiness criptografia = new CriptografiaBusiness();
                UsuarioBusiness business = new UsuarioBusiness();

                if (usuario.Email == "")
                {
                    ViewBag.message = "Favor preencher o seu email.";
                }
                if (usuario.Senha == "")
                {
                    ViewBag.message = "Favor preencher sua senha.";
                }
                //Business.Helper.Encrypt encript = new Business.Helper.Encrypt();

                //usuario.Senha = encript.Criptografa(usuario.Senha);

                var user = business.LogarUsuario(usuario);
                if (user != null)
                {
                    FormsAuthenticationTicket tkt;
                    string cookiestr;
                    HttpCookie ck;
                    tkt = new FormsAuthenticationTicket(user.Email, true, 30);
                    cookiestr = FormsAuthentication.Encrypt(tkt);
                    ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                    ck.Path = FormsAuthentication.FormsCookiePath;
                    Response.Cookies.Add(ck);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = "Usuário ou senha inválido.";
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                throw;
            }
        }
        public ActionResult CadastrarUsuario(Usuario usuario)
        {

            try
            {
                UsuarioBusiness business = new UsuarioBusiness();
                CriptografiaBusiness criptografia = new CriptografiaBusiness();

                if (usuario.Email == "")
                {
                    ViewBag.ErrorMessage = "Favor preencher o seu email.";
                }
                if (usuario.Senha == "")
                {
                    ViewBag.ErrorMessage = "Favor preencher sua senha.";
                }
                if (usuario.Nome == "")
                {
                    ViewBag.ErrorMessage = "Favor preencher o seu nome";

                }
                if (usuario.Senha == null || usuario.Email == null)
                {
                    //ViewBag.message = "Favor preencher os campos";
                    return View("CadastraUsuario");
                }
                //if (usuario.Senha.Length>20)
                //{
                //    ViewBag.message = "Sua senha deve conter 20 caracteres.";
                //    return View("CadastraUsuario");
                //}
                //if (usuario.Nome == "")
                //{
                //    ViewBag.message = "Favor preencher o seu Nome";
                //}
                //if (usuario.NomeUsuario == "")
                //{
                //    ViewBag.message = "Favor preencher o seu Nome";
                //}
                if (!business.ObterEmailUsuario(usuario.Email))
                {
                    ViewBag.ErrorMessage = "Email ja está cadastrado";
                    return View("CadastraUsuario");
                    //  throw new Exception();
                }
                //Business.Helper.Encrypt encript = new Business.Helper.Encrypt();

                // usuario.Senha = encript.Criptografa(usuario.Senha);
                usuario.Ranking = 0;
                if (business.Adicionar(usuario))
                {
                    ViewBag.message = "Usuário Cadastrado com Sucesso";

                }
                ViewBag.ErrorMessage = null;
                return View("CadastraUsuario");
            }
            catch (Exception ex)
            {
                //ViewBag.message = ex.Message;
                ViewBag.ErrorMessage = ex.Message;
                return View("CadastraUsuario");
                //throw;
            }
        }
        public ActionResult Logout()
        {

            try
            {
                Session.Clear();
                Session.Abandon();
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                throw;

            }
        }
    }
}