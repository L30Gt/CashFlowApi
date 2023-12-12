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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLancamentoCategoria(int id)
        {
            try
            {
                List<LancamentoCategoria> lcLista = new List<LancamentoCategoria>();
                lcLista = await _context.TB_LANCAMENTOCATEGORIAS
                .Include(l => l.Lancamento)
                .Include(l => l.Categoria)
                .Where(l => l.CategoriaId == id).ToListAsync();

                return Ok(lcLista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCategorias")]
        public async Task<IActionResult> GetCategorias()
        {
                try
            {
                List<Categoria> categorias = new List<Categoria>();
                categorias = await _context.TB_CATEGORIAS.ToListAsync();
                return Ok(categorias);
            }
            
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteLancamentoCategoria")]
        public async Task<IActionResult> DeleteLancamentoCategoria(LancamentoCategoria lc)
        {
            try
            {
                LancamentoCategoria lcRemover = await _context.TB_LANCAMENTOCATEGORIAS
                    .FirstOrDefaultAsync(lBusca => lBusca.LancamentoId == lc.LancamentoId && lBusca.CategoriaId == lc.CategoriaId);

                if (lcRemover == null)
                {
                    throw new System.Exception("Personagem ou Habilidades não encontrados");
                }

                _context.TB_LANCAMENTOCATEGORIAS.Remove(lcRemover);

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