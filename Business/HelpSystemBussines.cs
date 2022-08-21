using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Entity;

namespace Business
{
    public class HelpSystemBussines
    {
        private FuncionarioDAL dal;

        public HelpSystemBussines()
        {
            dal = new FuncionarioDAL();
        }
        public bool Adicionar(Funcionario funcionario)
        {

            return dal.Adicionar(funcionario);
        }
        public bool Atualizar(Funcionario novo)
        {
            return dal.Atualizar(novo);
        }
        public bool AtualizarResposta(Funcionario novo)
        {
            return dal.AtualizarResposta(novo);
        }
        public List<Funcionario> ListarTodos()
        {

            return dal.ListarTodos();
        }
        public List<Funcionario> RetornaOrdenado(int raking)
        {
            return dal.RetornaOrdenado(raking);
        }

        public bool Excluir(Funcionario funcionario)
        {

            return dal.Excluir(funcionario);
        }

        public Funcionario returnById(int id)
        {

            return dal.RetornaPorId(id);
        }
        public Funcionario RetornaPorNome(string nome)
        {
            return dal.RetornaPorNome(nome);
        }
        public Funcionario RetornaPorEmail(string email)
        {
            return dal.RetornaPorEmail(email);
        }
        public List<Funcionario> ListarPorNome(string nome)
        {
            return dal.ListarPorNome(nome);
        }
        public List<Funcionario> ListarPorEmail(string email)
        {
            return dal.ListarPorEmail(email);
        }
        public List<Funcionario> OrdenarPorRanking(int raking)
        {
            return dal.RetornaOrdenado(raking);
        }

    }
}
