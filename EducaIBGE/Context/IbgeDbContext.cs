using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducaIBGE.Models;

namespace EducaIBGE.Context
{
    public class IbgeDbContext:DbContext
    {
        public IbgeDbContext()
            : base()
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Teste> Testes { get; set; }
        public DbSet<ProfComSuperiorNoAno> ProfessoresComSuperior { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<AlunosPorSala> AlunosPorSala{ get; set; }
        public DbSet<AlfabetizacaoPorIdade> TaxasDeAlfabetizacaoPorIdade { get; set; }
        public DbSet<ReprovacaoPorSerie> ReprovacoesPorSerie{ get; set; }
        public DbSet<AnosDeEstudoPorIdade> AnosDeEstudo{ get; set; }
    }
}
