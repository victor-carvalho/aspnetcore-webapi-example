using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.ContactService.Data;
using WebApi.ContactService.Models;

namespace WebApi.ContactService.Controllers
{
    [Route("api/[controller]")]
    public class PessoasController : Controller
    {
        private readonly ApplicationContext _context;

        public PessoasController(ApplicationContext context)
        {
            this._context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pessoas = await _context.Pessoas.Include(p => p.Enderecos).ToListAsync();
            return Ok(pessoas);
        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetPessoa")]
        public async Task<IActionResult> Get(Guid id)
        {
            var pessoa = await _context.Pessoas.Include(p => p.Enderecos).FirstOrDefaultAsync(p => p.ID == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pessoa value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            value.ID = Guid.NewGuid();
            await _context.Pessoas.AddAsync(value);
            await _context.SaveChangesAsync();
            
            value.Enderecos = new Endereco[] {};
            return CreatedAtRoute("GetPessoa", new { id = value.ID }, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Pessoa value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.ID == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            pessoa.Name = value.Name;
            pessoa.Age = value.Age;
            
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.ID == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{pessoaId:Guid}/enderecos")]
        public async Task<IActionResult> GetEnderecos(Guid pessoaId)
        {
            var pessoa = await _context.Pessoas
                .Include(p => p.Enderecos)
                .FirstOrDefaultAsync(p => p.ID == pessoaId);

            if (pessoa == null)
            {
                return NotFound();
            }
            
            return Ok(pessoa.Enderecos);
        }

        [HttpGet("{pessoaId:Guid}/enderecos/{enderecoId}", Name="GetEndereco")]
        public async Task<IActionResult> GetEndereco(Guid pessoaId, Guid enderecoId)
        {
            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(e => e.ID == enderecoId && e.PessoaID == pessoaId);

            if (endereco == null)
            {
                return NotFound();
            }
            
            return Ok(endereco);
        }

        [HttpPost("{pessoaId:Guid}/enderecos")]
        public async Task<IActionResult> CreateEndereco(Guid pessoaId, [FromBody] Endereco value)
        {
            var pessoa = await _context.Pessoas
                .Include(p => p.Enderecos)
                .FirstOrDefaultAsync(p => p.ID == pessoaId);

            if (pessoa == null)
            {
                return NotFound();
            }
            
            value.ID = Guid.NewGuid();
            pessoa.Enderecos.Add(value);
            await _context.SaveChangesAsync();
            
            return CreatedAtRoute("GetEndereco", new { pessoaId, enderecoId = value.ID }, value);
        }

        [HttpDelete("{pessoaId:Guid}/enderecos/{enderecoId}")]
        public async Task<IActionResult> DeleteEndereco(Guid pessoaId, Guid enderecoId)
        {
            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(e => e.ID == enderecoId && e.PessoaID == pessoaId);

            if (endereco == null)
            {
                return NotFound();
            }
            
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
