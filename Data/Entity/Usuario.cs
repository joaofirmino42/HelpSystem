using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Data.Entity
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int Usuario_id { get; set; }
        [StringLength(500)]
        public string Email { get; set; }
        [StringLength(500)]
        public string Nome { get; set; }
        [StringLength(60)]
        public string Senha { get; set; }
        //public int? IdFuncionario { get; set; }
        //public int? NumeroRespondido { get; set; }

        public int? Ranking { get; set; }

        //public bool Respondido { get; set; }
    }
}
