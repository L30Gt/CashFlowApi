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
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Categoria c = await _context.TB_CATEGORIAS
                    .FirstOrDefaultAsync(cBusca => cBusca.Id == id);
                return Ok(c);
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
                List<Categoria> lista = await _context.TB_CATEGORIAS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Categoria novaCategoria)
        {
            try
            {
                await _context.TB_CATEGORIAS.AddAsync(novaCategoria);
                await _context.SaveChangesAsync();

                return Ok(novaCategoria.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Categoria novaCategoria)
        {
            try
            {
                _context.TB_CATEGORIAS.Update(novaCategoria);
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
                Categoria cRemover = await _context.TB_CATEGORIAS.FirstOrDefaultAsync(c => c.Id == id);

                _context.TB_CATEGORIAS.Remove(cRemover);
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