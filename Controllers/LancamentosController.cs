using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashFlowApi.Data;
using CashFlowApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CashFlowApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class LancamentosController : ControllerBase
    {
        private readonly DataContext _context;

        public LancamentosController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Lancamento l = await _context.TB_LANCAMENTOS
                    .Include(lc => lc.LancamentoCategorias)
                        .ThenInclude(c => c.Categoria)
                    .FirstOrDefaultAsync(lBusca => lBusca.Id == id);
                return Ok(l);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Lancamento> lista = await _context.TB_LANCAMENTOS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Lancamento novoLancamento)
        {
            try
            {
                await _context.TB_LANCAMENTOS.AddAsync(novoLancamento);
                await _context.SaveChangesAsync();

                return Ok(novoLancamento.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Lancamento novoLancamento)
        {
            try
            {
                _context.TB_LANCAMENTOS.Update(novoLancamento);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Lancamento lRemover = await _context.TB_LANCAMENTOS.FirstOrDefaultAsync(l => l.Id == id);

                _context.TB_LANCAMENTOS.Remove(lRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
