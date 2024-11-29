using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StatusController : ControllerBase
  {
    private readonly AppDbContext _context;

    public StatusController(AppDbContext context)
    {
      _context = context;
    }

    // GET ALL: api/status
    [HttpGet]
    // Rota para buscar todos os status
    public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
    {
      try
      {
        // Busca todos os status
        var status = await _context.Status.ToListAsync();

        if (!status.Any())
        {
          return NotFound("Nenhum status encontrado.");
        }

        // Retorna todos os status
        return Ok(new {message= "Status encontrados com sucesso!", status});
      }
      catch (Exception ex)
      {
        // Retorna erro 500 com a mensagem detalhada
        return StatusCode(500, new
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });  
      }
    }

    // GET DETAILS BY ID: api/status/5
    [HttpGet("{id}")]
    // Rota para buscar um status pelo id
    public async Task<ActionResult<Status>> GetStatus(int id)
    {
      try
      {
        // Busca o status pelo id
        var status = await _context.Status.FindAsync(id);

        if (status == null)
        {
            return NotFound("Status não encontrado.");
        }

        // Retorna o status encontrado
        return Ok(new {message= "Status encontrado com sucesso!", status});

      }
      catch (Exception ex)
      {
        // Retorna erro 500 com a mensagem detalhada
        return StatusCode(500, new
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });  
      }
    }

    // POST: api/status
    [HttpPost]
    // Rota para criar um status
    public async Task<ActionResult<Status>> PostStatus(Status status)
    {
      try
      {
        if(status == null)
        {
          return BadRequest("Status não informado.");
        }

        _context.Status.Add(status); // Adiciono status ao contexto
        await _context.SaveChangesAsync(); // Salva o status no banco de dados

        // Retorna o status criado
        return CreatedAtAction(nameof(GetStatus), new { id = status.Id },  new {message= "Status criado com sucesso!", status}); 
      }
      catch (Exception ex)
      {
        // Retorna erro 500 em caso de falha no processo
        return StatusCode(500, new 
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });
      }
    }

    // PUT: api/status/5
    [HttpPut("{id}")]
    // Rota para atualizar um status
    public async Task<IActionResult> PutStatus(int id, Status status)
    {
      if (status == null)
      {
        return BadRequest("Status não informado.");
      }

      status.Id = id; // Atribui o id da URL ao objeto status
      _context.Entry(status).State = EntityState.Modified; // Atualiza o status

      try
      {
          await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
      }
      catch (DbUpdateConcurrencyException ex)
      {
        if (!StatusExists(id))
        {
          // Caso ocorra um erro de concorrência ao atualizar os dados
          return StatusCode(500, new { message = "Status não encontrado.", error = ex.Message });
        }
        else
        {
          throw;
        }              
      }

      // Retorna o status atualizado
      return Ok(new {message= "Status atualizado com sucesso!", status}); 
    }

    // DELETE: api/status/5
    [HttpDelete("{id}")]
    // Rota para remover um status
    public async Task<IActionResult> DeleteStatus(int id)
    {
      try
      {
        // Busca o status pelo id
        var status = await _context.Status.FindAsync(id);

        if (status == null)
        {
          return NotFound("Status não encontrado.");
        }

        _context.Status.Remove(status); // Remove o status do contexto
        await _context.SaveChangesAsync(); // Salva a remoção no banco de dados

        // Retorna o status removido
        return Ok(new {message= "Status removido com sucesso!", status}); 

      }
      catch (Exception ex)
      {
        // Caso ocorra um erro inesperado, retorna uma resposta 500 com a mensagem de erro
        return StatusCode(500, new { message = "Erro ao remover o status.", error = ex.Message });
      }
    }

    // Método para verificar se o status existe
    private bool StatusExists(int id)
    {
      return _context.Status.Any(e => e.Id == id);
    }
  }
}
