using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace HelpSystem.Models
{
    public class FuncionarioModel
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        public string Pergunta { get; set; }

        public string Resposta { get; set; }

        public int? Ranking { get; set; }

        public bool? Respondido { get; set; }
    }
}