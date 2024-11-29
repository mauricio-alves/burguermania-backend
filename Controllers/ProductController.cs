using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL: api/produto
    [HttpGet]
    // Rota para buscar todos os produtos
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
      try
      {
        // Busca todos os produtos com a categoria
        var products = await _context.Products.Include(p => p.Category).ToListAsync(); 

        if (!products.Any())
        {
            return NotFound("Nenhum produto encontrado.");
        }

        // Retorna todos os produtos
        return Ok(new {message= "Produtos encontrados com sucesso!", products}); 

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

    // GET DETAILS BY ID: api/produto/1
    [HttpGet("{id}")]
    // Rota para buscar um produto pelo id
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        try
        {
            // Busca o produto pelo id com a categoria
          var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
            
          if (product == null)
          {
              return NotFound("Produto não encontrado.");
          }

          // Retorna o produto encontrado
          return Ok(new {message= "Produto encontrado com sucesso!", product}); 

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

    // POST: api/produto
    [HttpPost]
      // Rota para criar um produto
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
      try
      {
        if (product == null)
        {
          return BadRequest("Produto não informado.");
        }

        _context.Products.Add(product); // Adiciona o produto ao contexto
        await _context.SaveChangesAsync(); // Salva o produto no banco de dados

        // Retorna o produto criado
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id },  new {message= "Produto criado com sucesso!", product}); 

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

    // PUT: api/produto/1
    [HttpPut("{id}")]
    // Rota para atualizar um produto
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (product == null)
        {
            return BadRequest("Produto não informado.");
        }

        product.Id = id; // Atribui o id da URL ao objeto produto
        _context.Entry(product).State = EntityState.Modified; // Atualiza o produto

        try
        {
          await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
        }
        catch (DbUpdateConcurrencyException ex)
        {
          if (!ProductExists(id))
          {
            // Caso ocorra um erro de concorrência ao atualizar os dados
            return StatusCode(500, new { message = "Produto não encontrado.", error = ex.Message });
          }
          else
          {
            throw;
          }
        }

        // Retorna o produto atualizado
        return Ok(new {message= "Produto atualizado com sucesso!", product}); 
    }

    // // DELETE: api/produto/1
    [HttpDelete("{id}")]
    // Rota para remover um produto
    public async Task<IActionResult> DeleteProduct(int id) 
    {
      try
      {
        // Busca o produto pelo id
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound("Produto não encontrado.");
        }

        _context.Products.Remove(product); // Remove o produto do contexto
        await _context.SaveChangesAsync(); // Salva a remoção no banco de dados

        // Retorna o produto removido
        return Ok(new {message= "Produto removido com sucesso!", product}); 

      }
      catch (Exception ex)
      {
        // Caso ocorra um erro inesperado, retorna uma resposta 500 com a mensagem de erro
        return StatusCode(500, new { message = "Erro ao remover o produto.", error = ex.Message });
      }
    }

    // Método para verificar se o produto existe
    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
  }
}