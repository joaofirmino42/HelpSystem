using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
namespace Data
{
    public class FuncionarioDAL
    {
        private Model Con;

        public FuncionarioDAL()
        {
            Con = new Model();
        }
        public bool Adicionar(Funcionario funcionario)
        {
            try
            {
                Con.Funcionario.Add(funcionario);
                Con.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool Excluir(Funcionario funcionario)
        {
            try
            {
                Con.Funcionario.Remove(funcionario);
                Con.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool Atualizar(Funcionario novo)
        {
            try
            {
                var antigo = RetornaPorId(novo.IdFuncionario);
                antigo.Pergunta = novo.Pergunta;
                antigo.Resposta = novo.Resposta;
                antigo.Raking = novo.Raking;
                antigo.Email = novo.Email;
                antigo.Nome = novo.Nome;
                antigo.Respondido = novo.Respondido;
                Con.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool AtualizarResposta(Funcionario novo)
        {
            try
            {
                var antigo = RetornaPorId(novo.IdFuncionario);
                antigo.Resposta = novo.Resposta;
                antigo.Raking = novo.Raking;
                antigo.Respondido = novo.Respondido;
                Con.SaveChanges();
                return true;

            }
            catch
            {

                return false;
            }
        }
        public List<Funcionario> ListarTodos()
        {
            try
            {
                return Con.Funcionario.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public Funcionario RetornaPorNome(string nome)
        {
            try
            {
                return Con.Funcionario.Where(f => f.Nome.Equals(nome)).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }
        public List<Funcionario> ListarPorNome(string nome)
        {
            try
            {
                return Con.Funcionario.Where(f => f.Nome.Equals(nome)).ToList();
            }
            catch
            {

                throw;
            }
        }
        public Funcionario RetornaPorEmail(string email)
        {
            try
            {
                return Con.Funcionario.Where(f => f.Email.Equals(email)).FirstOrDefault();

            }
            catch
            {

                throw;
            }
        }
        public List<Funcionario> ListarPorEmail(string email)
        {
            try
            {
                return Con.Funcionario.Where(f => f.Email.Equals(email)).OrderBy(f => f.Nome).ToList();

            }
            catch
            {

                throw;
            }
        }
        public Funcionario RetornaPorId(int id)
        {
            try
            {
                return Con.Funcionario.Where(f => f.IdFuncionario == id).FirstOrDefault();
            }
            catch
            {

                throw;
            }
        }
        public List<Funcionario> RetornaOrdenado(int ranking)
        {
            try
            {

                return Con.Funcionario.OrderBy(a => a.Raking).ToList();
            }
            catch
            {

                throw;
            }
        }
    }
}
