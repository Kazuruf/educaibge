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
        public IHttpActionResult GetAll(string categoria="todos",
                                        string tipoDeEnsino="todos",
                                        int ano=0, 
                                        double minValue=-1, 
                                        double maxValue = -1,
                                        int anoMin =-1,
                                        int anoMax =-1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }                        
            IQueryable<ProfComSuperiorNoAno> profs = _context.ProfessoresComSuperior.Include(p=>p.Estado);
            var professores = profs.Where(p =>
                (categoria == "todos" || 
                    p.Categoria.Equals(categoria, StringComparison.CurrentCultureIgnoreCase)) 
                &&(tipoDeEnsino == "todos" || 
                    p.TipoDeEnsino.Equals(tipoDeEnsino, StringComparison.CurrentCultureIgnoreCase))
                &&(ano == 0 ||p.Ano==ano)
                && (anoMax == -1 || p.Ano <= anoMax)
                && (anoMin == -1 || p.Ano >= anoMin)
                &&(maxValue == -1 || p.Valor <= maxValue)
                && (minValue== -1 || p.Valor >= minValue)
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
        public IHttpActionResult GetAllAlunos (string categoria = "todos",
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
        

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
