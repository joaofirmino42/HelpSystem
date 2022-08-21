using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
namespace Data
{
    public class UsuarioDAL
    {
        private Model Con;

        public UsuarioDAL()
        {
            Con = new Model();
        }
        public bool Adicionar(Usuario usuario)
        {
            try
            {
                Con.Usuario.Add(usuario);
                Con.SaveChanges();
                return true;

            }
            catch
            {

                return false;
            }
        }
        public bool Excluir(Usuario usuario)
        {
            try
            {
                Con.Usuario.Remove(usuario);
                Con.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool Atualizar(Usuario novo)
        {
            try
            {
                var antigo = ReturnById(novo.Usuario_id);
                antigo.Nome = novo.Nome;
                // antigo.Senha = novo.Senha;
                antigo.Email = novo.Email;
                Con.SaveChanges();
                return true;

            }
            catch
            {

                return false;

            }
        }
        public bool AtualizarResposta(Usuario novo)
        {
            try
            {
                var antigo = ReturnById(novo.Usuario_id);
                antigo.Ranking = novo.Ranking;

                Con.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public List<Usuario> ListarTodos()
        {
            try
            {
                return Con.Usuario.ToList();
            }
            catch
            {

                throw;
            }
        }
        public List<Usuario> ListarUsuarioOrdenadoPorNome()
        {
            try
            {
                return Con.Usuario.OrderBy(u => u.Nome).ToList();

            }
            catch
            {

                throw;
            }
        }
        public Usuario LogarUsuario(Usuario usuario)
        {
            try
            {

                return Con.Usuario.Where(u => u.Email.Equals(usuario.Email) && u.Senha.Equals(usuario.Senha)).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }
        public bool ObterEmailUsuario(string email)
        {
            try
            {
                if (Con.Usuario.Where(u => u.Email.Equals(email)).Count() == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                return false;
            }
        }
        public Usuario RetornaPorEmail(string email)
        {
            try
            {
                return Con.Usuario.Where(u => u.Email.Equals(email)).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }
        public List<Usuario> ListarPorEmail(string email)
        {
            try
            {
                return Con.Usuario.Where(u => u.Email.Equals(email)).ToList();
            }
            catch
            {

                throw;
            }
        }
        public Usuario RetornaPorNome(string nome)
        {
            try
            {
                return Con.Usuario.Where(u => u.Nome.Equals(nome)).FirstOrDefault();

            }
            catch
            {

                throw;
            }
        }
        public List<Usuario> RetornaOrdenado(string nome)
        {
            try
            {
                return Con.Usuario.OrderBy(u => u.Nome).ToList();

            }
            catch
            {

                throw;
            }
        }
        public List<Usuario> ListarPorNome(string nome)
        {
            try
            {
                return Con.Usuario.Where(u => u.Nome.Equals(nome)).ToList();

            }
            catch
            {

                throw;
            }
        }
        public Usuario ReturnById(int id)
        {
            try
            {
                return Con.Usuario.Where(u => u.Usuario_id == id).SingleOrDefault();

            }
            catch
            {

                throw;
            }
        }
    }
}
