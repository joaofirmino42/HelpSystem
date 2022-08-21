using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entity
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Conexao")
        {
        }

        public virtual DbSet<Funcionario> Funcionario { get; set; }

        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
