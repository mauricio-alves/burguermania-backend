using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
      _context = context;
    }

    // GET ALL: api/categoria
    [HttpGet]
    // Rota para buscar todos as categorias
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
      try
      {
        // Busca todos as categorias com os produtos
        var categories = await _context.Categories.Include(p => p.Products).ToListAsync(); 

        if (!categories.Any())
        {
            return NotFound("Nenhuma categoria encontrada.");
        }

        // Retorna todos as categorias
        return Ok(new {message= "Categorias encontradas com sucesso!", categories}); 

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

    // GET DETAILS BY ID: api/categoria/1
    [HttpGet("{id}")]
    // Rota para buscar uma categoria pelo id
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        try
        {
          // Busca a categoria pelo id com os produtos
          var category = await _context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id);
            
          if (category == null)
          {
              return NotFound("Categoria não encontrada.");
          }

          // Retorna a categoria encontrada
          return Ok(new {message= "Categoria encontrada com sucesso!", category}); 

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

    // POST: api/categoria
    [HttpPost]
      // Rota para criar uma categoria
    public async Task<ActionResult<Category>> PostCategory(Category category)
    {
      try
      {
        if (category == null)
        {
          return BadRequest("Categoria não informada.");
        }

        _context.Categories.Add(category); // Adiciona a categoria ao contexto
        await _context.SaveChangesAsync(); // Salva a categoria no banco de dados

        // Retorna a categoria criada
        return CreatedAtAction(nameof(GetCategory), new { id = category.Id },  new {message= "Categoria criada com sucesso!", category}); 

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

    // PUT: api/categoria/1
    [HttpPut("{id}")]
    // Rota para atualizar uma categoria
    public async Task<IActionResult> PutCategory(int id, Category category)
    {
        if (category == null)
        {
            return BadRequest("Categoria não informada.");
        }

        category.Id = id; // Atribui o id da URL ao objeto categoria
        _context.Entry(category).State = EntityState.Modified; // Atualiza a categoria

        try
        {
          await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
        }
        catch (DbUpdateConcurrencyException ex)
        {
          if (!CategoryExists(id))
          {
            // Caso ocorra um erro de concorrência ao atualizar os dados
            return StatusCode(500, new { message = "Categoria não encontrada.", error = ex.Message });
          }
          else
          {
            throw;
          }
        }

        // Retorna a categoria atualizada
        return Ok(new {message= "Categoria atualizada com sucesso!", category}); 
    }

    // // DELETE: api/categoria/1
    [HttpDelete("{id}")]
    // Rota para remover uma categoria
    public async Task<IActionResult> DeleteCategory(int id) 
    {
      try
      {
        // Busca a categoria pelo id
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            return NotFound("Categoria não encontrada.");
        }

        _context.Categories.Remove(category); // Remove a categoria do contexto
        await _context.SaveChangesAsync(); // Salva a remoção no banco de dados

        // Retorna a categoria removida
        return Ok(new {message= "Categoria removida com sucesso!", category}); 

      }
      catch (Exception ex)
      {
        // Caso ocorra um erro inesperado, retorna uma resposta 500 com a mensagem de erro
        return StatusCode(500, new { message = "Erro ao remover a categoria.", error = ex.Message });
      }
    }

    // Método para verificar se a categoria existe
    private bool CategoryExists(int id)
    {
        return _context.Categories.Any(e => e.Id == id); 
    }
  }
}