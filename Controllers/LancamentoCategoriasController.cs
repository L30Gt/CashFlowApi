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
    public class LancamentoCategoriasController : ControllerBase
    {
        private readonly DataContext _context;
        public LancamentoCategoriasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddLancamentoCategoriaAsync(LancamentoCategoria novoLancamentoCategoria)
        {
            try
            {
                Lancamento lancamento = await _context.TB_LANCAMENTOS
                    .Include(l => l.LancamentoCategorias).ThenInclude(ls => ls.Categoria)
                    .FirstOrDefaultAsync(l => l.Id == novoLancamentoCategoria.LancamentoId);

                Categoria categoria = await _context.TB_CATEGORIAS
                    .FirstOrDefaultAsync(c => c.Id == novoLancamentoCategoria.CategoriaId);

                if (categoria == null)
                    throw new System.Exception("Categoria não encontrada.");
                
                LancamentoCategoria lc = new LancamentoCategoria();
                lc.Lancamento = lancamento;
                lc.Categoria = categoria;
                await _context.TB_LANCAMENTOCATEGORIAS.AddAsync(lc);
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