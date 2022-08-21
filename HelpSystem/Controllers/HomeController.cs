using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Globalization;
using System.Web.Security;
using Newtonsoft.Json;
using HelpSystem.Models;
using Business;
using Business.Util;
using Data.Entity;
namespace HelpSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: HelpSystem
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Grafico()
        {
            return View();
        }
        public ActionResult TabelaPergunta()
        {
            return View();
        }
        public ActionResult ListaUsuario()
        {
            try
            {
                ViewData["LstUsuario"] = new UsuarioBusiness().ListarUsuarioOrdenadoPorNome();
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                throw;
            }

        }
        public ActionResult ListaResposta()
        {
            try
            {
                HelpSystemBussines business = new HelpSystemBussines();
                ViewData["Lstresposta"] = business.ListarTodos();
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                throw;
            }
        }
        public Usuario ObterUser()
        {
            try
            {
                UsuarioBusiness business = new UsuarioBusiness();
                FormsIdentity id = (FormsIdentity)System.Web.HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = id.Ticket;
                return business.RetornaPorEmail(ticket.Name);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return null;
            }
        }
        public ActionResult Lista()
        {

            try
            {
                //ViewBag.LstHelpSystem = new HelpSystemBussines().ListarTodos();
                //  ViewData["LstHelpSystem"] = Business.HelpSystemBussines.ListarTodos();
                ViewData["LstHelpSystem"] = new HelpSystemBussines().ListarTodos();
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                throw;
            }

        }
        public ActionResult retornaLista()
        {
            try
            {
                HelpSystemBussines bussines = new HelpSystemBussines();
                ViewData["LstHelpSystem"] = bussines.ListarTodos();
                var lista = bussines.ListarTodos();
                //return PartialView("LstHelpSystem", lista);
                return View("Lista");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                throw;
            }
        }
        public JsonResult MontaGrafico()
        {
            try
            {
                GraficoModel model = new GraficoModel();
                HelpSystemBussines bussines = new HelpSystemBussines();
                ResultadoOperacaoAjax result = new ResultadoOperacaoAjax();
                var lista = bussines.ListarTodos();
                return Json(new { success = true, lista = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AbrirModal(int codigo)
        {
            try
            {
                HelpSystemBussines bussines = new HelpSystemBussines();
                var mod = bussines.returnById(codigo);
                if (mod.Raking == null)
                {
                    mod.Raking = 0;
                }
                return PartialView("modalHelpSystem", mod);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                throw;
            }
        }
        public JsonResult Atualizar(FuncionarioModel model)
        {
            UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
            HelpSystemBussines business = new HelpSystemBussines();
            ResultadoOperacaoAjax result = new ResultadoOperacaoAjax();
            try
            {
                int n = 0;
                var usuario = ObterUser();
                //for (int i = 1; i <= model.Ranking; i++)
                //{
                //    n = i;
                //}
                model.Ranking = model.Ranking + 1;
                usuario.Ranking = model.Ranking;
                Funcionario funcionario = new Funcionario()
                {
                    IdFuncionario = model.Id,
                    Email = model.Email,
                    Nome = model.Nome,
                    Pergunta = model.Pergunta,
                    Resposta = model.Resposta,
                    Raking = model.Ranking,
                    Respondido = true
                };
                if (usuarioBusiness.AtualizarResposta(usuario))
                {
                    if (business.AtualizarResposta(funcionario))
                    {
                        return Json(new { success = true, message = "Atualizado com sucesso" }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return Json(new { success = true, message = "Atualizado com sucesso" }, JsonRequestBehavior.AllowGet);
                    }


                }
                else
                {
                    return Json(new { succes = false, message = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { success = false, messsage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Cadastrar(FuncionarioModel model)
        {

            ResultadoOperacaoAjax result = new ResultadoOperacaoAjax();
            HelpSystemBussines bussines = new HelpSystemBussines();
            try
            {
                Funcionario funcionario = new Funcionario
                {
                    Email = model.Email,
                    Nome = model.Nome,
                    Pergunta = model.Pergunta,
                    Respondido = false

                };
                if (bussines.Adicionar(funcionario))
                {
                    return Json(new { success = true, message = "Cadastrado com sucesso" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, message = "Error" }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}