using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace HelpSystem.Models
{
    public class ResultadoOperacaoAjax
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Objeto { get; set; }

        public ResultadoOperacaoAjax()
        {

        }
    }
}