using Microsoft.AspNetCore.Mvc;
using OcarinaTestApi.Domains;
using OcarinaTestApi.Inteface;
using OcarinaTestApi.Repositories;

namespace OcarinaTestApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos tipos de usuário
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class TypeUserController : Controller
    {

        /// <summary>
        /// Cria um objeto _tipoUsuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private ITypeUserRepository _typeUserRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public TypeUserController()
        {
            _typeUserRepository = new TypeUserRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Uma lista de tipos de usuário e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de tipos de usuário</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TiposUsuario
        [HttpGet("BuscaTipoUsuario")]
        public IActionResult BuscaTipoUsuario()
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_typeUserRepository.Listar());
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna o tipo de usuário buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TiposUsuario/id
        [HttpGet("BuscaPorIdTipoUsuario")]
        public IActionResult BuscaPorIdTipoUsuario(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto tipoUsuarioBuscado
                TypeUser tipoUsuarioBuscado = _typeUserRepository.BuscarPorId(id);

                // Verifica se o tipo de usuário foi encontrado
                if (tipoUsuarioBuscado != null)
                {
                    // Retora a resposta da requisição 200 - OK e o tipo de usuário que foi encontrado
                    return Ok(tipoUsuarioBuscado);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum tipo de usuário encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TiposUsuario
        [HttpPost("CadastraUsuario")]
        public IActionResult CadastraUsuario(TypeUser novoTipoUsuario)
        {
            try
            {
                // Faz a chamada para o método
                _typeUserRepository.Cadastrar(novoTipoUsuario);

                // Retora a resposta da requisição 201 - Created
                return StatusCode(201);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TiposUsuario/id
        [HttpPatch("AtualizaTipoUsuario")]
        public IActionResult AtualizaTipoUsuario(int id, TypeUser tipoUsuarioAtualizado)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto tipoUsuarioBuscado
                TypeUser tipoUsuarioBuscado = _typeUserRepository.BuscarPorId(id);

                // Verifica se o tipo de usuário foi encontrado
                if (tipoUsuarioBuscado != null)
                {
                    // Faz a chamada para o método
                    _typeUserRepository.Atualizar(id, tipoUsuarioAtualizado);

                    // Retora a resposta da requisição 204 - No Content
                    return StatusCode(204);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum tipo de usuário encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/TiposUsuario/id
        [HttpDelete("DeletaTipoUsuario")]
        public IActionResult DeletaTipoUsuario(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto tipoUsuarioBuscado
                TypeUser tipoUsuarioBuscado = _typeUserRepository.BuscarPorId(id);

                // Verifica se o tipo de usuário foi encontrado
                if (tipoUsuarioBuscado != null)
                {
                    // Faz a chamada para o método
                    _typeUserRepository.Deletar(id);

                    // Retora a resposta da requisição 202 - Accepted
                    return StatusCode(202);
                }
                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum tipo de usuário encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
        
    }
}
