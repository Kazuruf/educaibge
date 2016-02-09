using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaIBGE.Models.DTO
{
    public class AnosDeEstudoPorIdadeDTO
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public virtual Estado Estado { get; set; }
        public double Valor { get; set; }
        public string Unidade { get; set; }
        public string Uf { get; set; }
        public string FaixaDeIdade { get; set; }
    }
}
