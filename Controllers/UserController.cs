using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models; 
using WebAPI.Context; 

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL: api/user
        [HttpGet]
        // Rota para buscar todos os usuários 
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                // Busca todos os usuários com os pedidos
                var users = await _context.Users.Include(u => u.UserOrders).ToListAsync();

                if (!users.Any())
                {
                    return NotFound("Nenhum usuário encontrado.");
                }

                // Mapeia os usuários para usar o UserDTO e não retornar a senha
                var userDTOs = users.Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                }).ToList();

                // Retorna todos os usuários            
                return Ok(new {message= "Usuários encontrados com sucesso!", users = userDTOs}); 
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

        // GET DETAILS BY ID: api/user/1
        [HttpGet("{id}")]
        // Rota para buscar um usuário pelo id
        public async Task<ActionResult<User>> GetUser(int id) 
        {
            try
            {
                // Busca o usuário específico com os pedidos
                var user = await _context.Users
                    .Include(u => u.UserOrders)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    return NotFound("Usuário não encontrado.");
                }

                // Usando o UserDTO para não retornar a senha
                var userDTO = MapToDTO(user);

                // Retorna o usuário encontrado
                return Ok(new {message= "Usuário encontrado com sucesso!", user = userDTO}); 
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

        // POST: api/user
        [HttpPost]
        // Rota para criar um usuário
        public async Task<ActionResult<User>> PostUser(User user) 
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Usuário não informado.");
                }

                _context.Users.Add(user); // Adiciona o usuário ao contexto
                await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados

                // Usando o UserDTO para não retornar a senha
                var userDTO = MapToDTO(user);

                // Retorna o usuário criado
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new {message= "Usuário criado com sucesso!", user = userDTO}); 

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

        // PUT: api/user/1
        [HttpPut("{id}")]
        // Rota para atualizar um usuário
        public async Task<IActionResult> PutUser(int id, [FromBody] User user) 
        {
            if (user == null)
            {
                return BadRequest("Usuário não informado.");
            }

            user.Id = id; // Atribui o id da URL ao objeto usuário
            _context.Entry(user).State = EntityState.Modified; // Atualiza o usuário

            try
            {
                await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UserExists(id))
                {
                    // Caso ocorra um erro de concorrência ao atualizar os dados
                    return StatusCode(500, new { message = "Usuário não encontrado.", error = ex.Message });
                }
                else
                {
                    throw;
                }
            }

            // Usando o UserDTO para não retornar a senha
            var userDTO = MapToDTO(user);

            // Retorna o usuário atualizado
            return Ok(new {message= "Usuário atualizado com sucesso!", user = userDTO}); 
        }

        // DELETE: api/user/1
        [HttpDelete("{id}")]
        // Rota para remover um usuário
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                // Busca o usuário pelo id
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    return NotFound("Usuário não encontrado.");
                }

                _context.Users.Remove(user); // Remove o usuário do contexto
                await _context.SaveChangesAsync(); // Salva a remoção no banco de dados

                // Usando o UserDTO para não retornar a senha
                var userDTO = MapToDTO(user);

                // Retorna o usuário removido
                return Ok(new {message= "Usuário removido com sucesso!", user = userDTO}); 
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro inesperado, retorna uma resposta 500 com a mensagem de erro
                return StatusCode(500, new { message = "Erro ao remover o usuário.", error = ex.Message });
            }
        }

        // Método para mapear o usuário para o UserDTO e não retornar a senha
        private UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserOrders = user.UserOrders
            };
        }

        // Método para verificar se o usuário existe
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id); 
        }
    }
}