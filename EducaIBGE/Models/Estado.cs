﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaIBGE.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string UF { get; set; }
        public string Nome{ get; set; }
        public ICollection<ProfComSuperiorNoAno> ProfessoresComSuperiorFund { get; set; }
    }
}
