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

        // GET ALL: api/User
        [HttpGet]
        // Rota para buscar todos os usuários 
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users
                .ToListAsync(); // Busca todos os usuários

            if (users == null)
            {
                return NotFound("Usuários não encontrados.");
            }

            // Retorna todos os usuários            
            return Ok(new {message= "Usuários encontrados com sucesso!", users}); 
        }

        // GET DETAILS BY ID: api/User/1
        [HttpGet("{id}")]
        // Rota para buscar um usuário pelo id
        public async Task<ActionResult<User>> GetUser(int id) 
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(c => c.Id == id); // Busca o usuário pelo id        

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // Retorna o usuário encontrado
            return Ok(new {message= "Usuário encontrado com sucesso!", user}); 
        }

        // POST: api/User
        [HttpPost]
        // Rota para criar um usuário
        public async Task<ActionResult<User>> PostUser(User user) 
        {
            if (user == null)
            {
                return BadRequest("Usuário não informado.");
            }

            _context.Users.Add(user); // Adiciona o usuário
            await _context.SaveChangesAsync(); // Salva o usuário no banco de dados

            // Retorna o usuário criado
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new {message= "Usuário criado com sucesso!", user}); 
        }

        // PUT: api/User/1
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
                await _context.SaveChangesAsync(); // Salva as alterações
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound("Usuário não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            // Retorna o usuário atualizado
            return Ok(new {message= "Usuário atualizado com sucesso!", user}); 
        }

        // DELETE: api/User/1
        [HttpDelete("{id}")]
        // Rota para deletar um usuário
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id); // Busca o usuário pelo id
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            _context.Users.Remove(user); // Remove o usuário
            await _context.SaveChangesAsync(); // Salva as alterações

            // Retorna o usuário removido
            return Ok(new {message= "Usuário removido com sucesso!", user}); 
        }

        private bool UserExists(int id)
        {
            // Verifica se o usuário existe
            return _context.Users.Any(e => e.Id == id); 
        }
    }
}