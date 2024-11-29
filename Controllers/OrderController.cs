using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrderController : ControllerBase
  {
    private readonly AppDbContext _context;

    public OrderController(AppDbContext context)
    {
      _context = context;
    }

    // GET ALL: api/order
    [HttpGet]
    // Rota para buscar todas as ordens
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
      try
      {
        // Busca todas as ordens com os produtos e usuários
        var orders = await _context.Orders
          .Include(o => o.Status)
          .Include(o => o.ProductOrders)
          .Include(o => o.UserOrders)
          .ToListAsync();

        if (!orders.Any())
        {
            return NotFound("Nenhuma ordem encontrada.");
        }

        // Retorna todas as ordens
        return Ok(new {message= "Ordens encontradas com sucesso!", orders});
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

    // GET DETAILS BY ID: api/order/5
    [HttpGet("{id}")]
    // Rota para buscar uma ordem pelo id
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
      try
      {
        // Busca a ordem pelo id com os produtos e usuários
        var order = await _context.Orders
          .Include(o => o.Status)
          .Include(o => o.ProductOrders)
          .Include(o => o.UserOrders)
          .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            return NotFound("Ordem não encontrada.");
        }

        // Retorna a ordem encontrada
        return Ok(new {message= "Ordem encontrada com sucesso!", order});

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

    // POST: api/order
    [HttpPost]
    // Rota para criar uma ordem
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
      try
      {
        if(order == null)
        {
          return BadRequest("Ordem não informada.");
        }

        _context.Orders.Add(order); // Adiciona a ordem ao contexto
        await _context.SaveChangesAsync(); // Salva a ordem no banco de dados

        // Retorna a ordem criada
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id },  new {message= "Ordem criada com sucesso!", order}); 
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

    // PUT: api/order/5
    [HttpPut("{id}")]
    // Rota para atualizar uma ordem
    public async Task<IActionResult> PutOrder(int id, Order order)
    {
      if (order == null)
      {
        return BadRequest("Ordem não informada.");
      }

      order.Id = id; // Atribui o id da URL ao objeto ordem
      _context.Entry(order).State = EntityState.Modified; // Atualiza a ordem

      try
      {
          await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
      }
      catch (DbUpdateConcurrencyException ex)
      {
        if (!OrderExists(id))
        {
          // Caso ocorra um erro de concorrência ao atualizar os dados
          return StatusCode(500, new { message = "Ordem não encontrada.", error = ex.Message });
        }
        else
        {
          throw;
        }              
      }

      // Retorna a ordem atualizada
      return Ok(new {message= "Ordem atualizada com sucesso!", order}); 
    }

    // DELETE: api/order/5
    [HttpDelete("{id}")]
    // Rota para remover uma ordem
    public async Task<IActionResult> DeleteOrder(int id)
    {
      try
      {
        // Busca a ordem pelo id
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
          return NotFound("Ordem não encontrada.");
        }

        _context.Orders.Remove(order); // Remove a ordem do contexto
        await _context.SaveChangesAsync(); // Salva a remoção no banco de dados

        // Retorna a ordem removida
        return Ok(new {message= "Ordem removida com sucesso!", order}); 

      }
      catch (Exception ex)
      {
        // Caso ocorra um erro inesperado, retorna uma resposta 500 com a mensagem de erro
        return StatusCode(500, new { message = "Erro ao remover a ordem.", error = ex.Message });
      }
    }

    // Método para verificar se a ordem existe
    private bool OrderExists(int id)
    {
      return _context.Orders.Any(e => e.Id == id);
    }
  }
}
