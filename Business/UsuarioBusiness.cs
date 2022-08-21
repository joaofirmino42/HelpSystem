using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Entity;
namespace Business
{
    public class UsuarioBusiness
    {
        private UsuarioDAL dal;

        public UsuarioBusiness()
        {
            dal = new UsuarioDAL();
        }
        public bool Adicionar(Usuario usuario)
        {

            return dal.Adicionar(usuario);
        }
        public bool Excluir(Usuario usuario)
        {
            return dal.Excluir(usuario);

        }
        public bool Atualizar(Usuario novo)
        {
            return dal.Atualizar(novo);
        }
        public bool AtualizarResposta(Usuario novo)
        {
            return dal.AtualizarResposta(novo);
        }
        public List<Usuario> ListarTodos()
        {
            return dal.ListarTodos();
        }
        public List<Usuario> ListarUsuarioOrdenadoPorNome()
        {
            return dal.ListarUsuarioOrdenadoPorNome();
        }
        public bool ObterEmailUsuario(string email)
        {
            return dal.ObterEmailUsuario(email);
        }
        public Usuario RetornaPorEmail(string email)
        {
            return dal.RetornaPorEmail(email);
        }
        public Usuario RetornaPorNome(string nome)
        {
            return dal.RetornaPorNome(nome);
        }
        public List<Usuario> ListarPorNome(string nome)
        {
            return dal.ListarPorNome(nome);
        }
        public List<Usuario> RetornaOrdenado(string nome)
        {
            return dal.RetornaOrdenado(nome);
        }
        public List<Usuario> ListarPorEmail(string email)
        {
            return dal.ListarPorEmail(email);
        }
        public Usuario LogarUsuario(Usuario usuario)
        {
            return dal.LogarUsuario(usuario);
        }
        public Usuario ReturnById(int id)
        {
            return dal.ReturnById(id);

        }

    }
}
