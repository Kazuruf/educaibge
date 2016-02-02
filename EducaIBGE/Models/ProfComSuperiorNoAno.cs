using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducaIBGE.Models
{
    public class ProfComSuperiorNoAno
    {
        public int Id { get; set; }
        public int Ano{ get; set; }        
        public virtual Estado Estado{ get; set; }
        public double Valor { get; set; }
        public string Unidade { get; set; }
        public string Categoria { get; set; }
        /// <summary>
        /// Fundamental ou outro
        /// </summary>
        public string TipoDeEnsino { get; set; }

    }
}
