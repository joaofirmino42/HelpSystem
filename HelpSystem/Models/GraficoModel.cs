﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace HelpSystem.Models
{
    public class GraficoModel
    {
        public string Nome { get; set; }

        public int Ranking { get; set; }

        public string Email { get; set; }
    }
}