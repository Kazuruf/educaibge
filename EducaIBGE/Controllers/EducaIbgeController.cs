using EducaIBGE.Context;
using EducaIBGE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using EducaIBGE.Models.DTO;

namespace EducaIBGE.Controllers
{
    /// <summary>
    /// Controller IBGE
    /// </summary>
    public class EducaIbgeController : ApiController
    {
        private IbgeDbContext _context = new IbgeDbContext();
        /// <summary>
        /// Seleciona Todos os professores Com ensino superior em Porcentagem informações por estado,
        /// referente ao código SEE7 do IBGE
        /// Dados Referentes 
        /// </summary>
        /// <param name="categoria">Fundamental</param>
        /// <param name="tipoDeEnsino"></param>
        /// <param name="Ano"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        [Route("professores/superior")]
        [ResponseType(typeof(ICollection<ProfComSuperiorNoAno>))]
        public IHttpActionResult GetAll(string categoria = "todos",
                                        string tipoDeEnsino = "todos",
                                        int ano = 0,
                                        double minValue = -1,
                                        double maxValue = -1,
                                        int anoMin = -1,
                                        int anoMax = -1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<ProfComSuperiorNoAno> profs = _context.ProfessoresComSuperior.Include(p => p.Estado);
            var professores = profs.Where(p =>
                (categoria == "todos" ||
                    p.Categoria.Equals(categoria, StringComparison.CurrentCultureIgnoreCase))
                && (tipoDeEnsino == "todos" ||
                    p.TipoDeEnsino.Equals(tipoDeEnsino, StringComparison.CurrentCultureIgnoreCase))
                && (ano == 0 || p.Ano == ano)
                && (anoMax == -1 || p.Ano <= anoMax)
                && (anoMin == -1 || p.Ano >= anoMin)
                && (maxValue == -1 || p.Valor <= maxValue)
                && (minValue == -1 || p.Valor >= minValue)
                ).ToList();
            var profsDTO = new List<ProfessoresComSuperiorDTO>();
            foreach (var professor in professores)
            {
                profsDTO.Add(new ProfessoresComSuperiorDTO()
                {
                    Ano = professor.Ano,
                    Categoria = professor.Categoria,
                    TipoDeEnsino = professor.TipoDeEnsino,
                    UF = professor.Estado.UF,
                    Unidade = professor.Unidade,
                    Valor = professor.Valor
                });
            }
            return Ok(profsDTO);
        }
        /// <summary>
        /// alunosPorSala
        /// </summary>
        /// <param name="categoria"></param>
        /// <param name="tipoDeEnsino"></param>
        /// <param name="ano"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="anoMin"></param>
        /// <param name="anoMax"></param>
        /// <returns></returns>
        [Route("alunos/por-sala")]
        [ResponseType(typeof(ICollection<AlunosPorSalaDTO>))]
        public IHttpActionResult GetAllAlunos(string categoria = "todos",
                                        string tipoDeEnsino = "todos",
                                        int ano = 0,
                                        double minValue = -1,
                                        double maxValue = -1,
                                        int anoMin = -1,
                                        int anoMax = -1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<AlunosPorSala> alunos = _context.AlunosPorSala.Include(p => p.Estado);
            var alunosList = alunos.Where(p =>
                (categoria == "todos" ||
                    p.Categoria.Equals(categoria, StringComparison.CurrentCultureIgnoreCase))
                && (tipoDeEnsino == "todos" ||
                    p.TipoDeEnsino.Equals(tipoDeEnsino, StringComparison.CurrentCultureIgnoreCase))
                && (ano == 0 || p.Ano == ano)
                && (anoMax == -1 || p.Ano <= anoMax)
                && (anoMin == -1 || p.Ano >= anoMin)
                && (maxValue == -1 || p.Valor <= maxValue)
                && (minValue == -1 || p.Valor >= minValue)
                ).ToList();
            var alunosDTO = new List<AlunosPorSalaDTO>();
            foreach (var aluno in alunosList)
            {
                alunosDTO.Add(new AlunosPorSalaDTO()
                {
                    Ano = aluno.Ano,
                    Categoria = aluno.Categoria,
                    TipoDeEnsino = aluno.TipoDeEnsino,
                    UF = aluno.Estado.UF,
                    Unidade = aluno.Unidade,
                    Valor = aluno.Valor
                });
            }
            return Ok(alunosDTO);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="faixaDeIdade">
        /// 5 e 6 anos,
        /// 7 anos,
        /// 8 e 9 anos,
        /// 10 a 14 anos,
        /// 10 e 11 anos,	
        /// 12 anos,
        /// 13 e 14 anos,
        /// 15 a 19 anos,
        /// 15 a 17 anos,
        /// 18 a 19 anos,
        /// 20 a 24 anos,
        /// 25 a 29 anos,
        /// 30 a 39 anos,
        /// 40 a 49 anos,
        /// 50 a 59 anos,
        /// 60 anos ou mais,
        /// Idade ignorada</param>
        /// <param name="alfabetizado">alfabetizado,
        /// nao alfabetizado</param>
        /// <param name="ano"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="anoMin"></param>
        /// <param name="anoMax"></param>
        /// <returns></returns>
        [Route("alfabetizacao")]
        [ResponseType(typeof(ICollection<AlfabetizacaoPorIdadeDTO>))]
        public IHttpActionResult GetAllAlfabetizados(string faixaDeIdade = "todos",
                                        string alfabetizado = "todos",
                                        int ano = 0,
                                        double minValue = -1,
                                        double maxValue = -1,
                                        int anoMin = -1,
                                        int anoMax = -1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<AlfabetizacaoPorIdade> alfabetizados = _context.TaxasDeAlfabetizacaoPorIdade.Include(p => p.Estado);
            var alfabetizadosList = alfabetizados.Where(p =>
                (faixaDeIdade == "todos" ||
                    p.FaixaDeIdade.Equals(faixaDeIdade, StringComparison.CurrentCultureIgnoreCase))
                && (alfabetizado == "todos" ||
                    p.Alfabetizado.Equals(alfabetizado, StringComparison.CurrentCultureIgnoreCase))
                && (ano == 0 || p.Ano == ano)
                && (anoMax == -1 || p.Ano <= anoMax)
                && (anoMin == -1 || p.Ano >= anoMin)
                && (maxValue == -1 || p.Valor <= maxValue)
                && (minValue == -1 || p.Valor >= minValue)
                ).ToList();
            var alfabetizadosDTO = new List<AlfabetizacaoPorIdadeDTO>();
            foreach (var alfab in alfabetizadosList)
            {
                alfabetizadosDTO.Add(new AlfabetizacaoPorIdadeDTO()
                {
                    Ano = alfab.Ano,
                    FaixaDeIdade = alfab.FaixaDeIdade,
                    Alfabetizado = alfab.Alfabetizado,
                    Uf = alfab.Estado.UF,
                    Unidade = alfab.Unidade,
                    Valor = alfab.Valor
                });
            }
            return Ok(alfabetizadosDTO);
        }


        [Route("reprovacao")]
        [ResponseType(typeof(ICollection<ReprovacaoPorSerieDTO>))]
        public IHttpActionResult GetAllReprovados(string serie = "todos",
                                        string tipoDeEnsino = "todos",
                                        int ano = 0,
                                        double minValue = -1,
                                        double maxValue = -1,
                                        int anoMin = -1,
                                        int anoMax = -1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<ReprovacaoPorSerie> reprovados = _context.ReprovacoesPorSerie.Include(p => p.Estado);
            var reprovadosListFiltered = reprovados.Where(p =>
                (serie == "todos" ||
                    p.Serie.Contains(serie))
                && (tipoDeEnsino == "todos" ||
                    p.TipoDeEnsino.Equals(tipoDeEnsino, StringComparison.CurrentCultureIgnoreCase))
                && (ano == 0 || p.Ano == ano)
                && (anoMax == -1 || p.Ano <= anoMax)
                && (anoMin == -1 || p.Ano >= anoMin)
                && (maxValue == -1 || p.Valor <= maxValue)
                && (minValue == -1 || p.Valor >= minValue)
                ).ToList();
            var reprovadosDTO = new List<ReprovacaoPorSerieDTO>();
            foreach (var reprovado in reprovadosListFiltered)
            {
                reprovadosDTO.Add(new ReprovacaoPorSerieDTO()
                {
                    Ano = reprovado.Ano,
                    Serie = reprovado.Serie,
                    TipoDeEnsino = reprovado.TipoDeEnsino,
                    UF = reprovado.Estado.UF,
                    Unidade = reprovado.Unidade,
                    Valor = reprovado.Valor
                });
            }
            return Ok(reprovadosDTO);
        }

        [Route("anos-de-estudo")]
        [ResponseType(typeof(ICollection<AnosDeEstudoPorIdade>))]
        public IHttpActionResult GetAllReprovados(string faixaDeIdade = "todos",                                        
                                        int ano = 0,
                                        double minValue = -1,
                                        double maxValue = -1,
                                        int anoMin = -1,
                                        int anoMax = -1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<AnosDeEstudoPorIdade> anosDeEstudoList = _context.AnosDeEstudo.Include(p => p.Estado);
            var anosDeEstudoFiltered = anosDeEstudoList.Where(p =>
                (faixaDeIdade == "todos" ||
                    p.FaixaDeIdade.Contains(faixaDeIdade))                
                && (ano == 0 || p.Ano == ano)
                && (anoMax == -1 || p.Ano <= anoMax)
                && (anoMin == -1 || p.Ano >= anoMin)
                && (maxValue == -1 || p.Valor <= maxValue)
                && (minValue == -1 || p.Valor >= minValue)
                ).ToList();
            var reprovadosDTO = new List<AnosDeEstudoPorIdadeDTO>();
            foreach (var reprovado in anosDeEstudoFiltered)
            {
                reprovadosDTO.Add(new AnosDeEstudoPorIdadeDTO()
                {
                    Ano = reprovado.Ano,
                    FaixaDeIdade= reprovado.FaixaDeIdade,                    
                    Uf = reprovado.Estado.UF,
                    Unidade = reprovado.Unidade,
                    Valor = reprovado.Valor
                });
            }
            return Ok(reprovadosDTO);
        }

    }
}
