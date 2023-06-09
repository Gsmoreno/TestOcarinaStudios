﻿using Microsoft.AspNetCore.Mvc;
using OcarinaTestApi.Domains;
using OcarinaTestApi.Inteface;
using OcarinaTestApi.Repositories;

namespace OcarinaTestApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : Controller
    {

        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IExerciseRepository _exerciseRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public ExerciseController()
        {
            _exerciseRepository = new ExerciseRepository();
        }
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de usuários</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Usuarios
        [HttpGet("ListaExercise")]
        public IActionResult ListaExercise()
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_exerciseRepository.Listar());
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna o usuário buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Usuarios/id
        [HttpGet("BuscaPorId")]
        public IActionResult BuscaPorId(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto usuarioBuscado
                Exercise exerciseBuscado = _exerciseRepository.BuscarPorId(id);

                // Verifica se o usuário foi encontrado
                if (exerciseBuscado != null)
                {
                    // Retora a resposta da requisição 200 - OK e o usuário que foi encontrado
                    return Ok(exerciseBuscado);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum usuário encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Usuarios
        [HttpPost("CadastraExercise")]
        public IActionResult CadastraExercise(Exercise exerciseUsuario)
        {
            try
            {
                // Faz a chamada para o método
                _exerciseRepository.Cadastrar(exerciseUsuario);

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
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Usuarios/id
        [HttpPatch("AtualizaExercise")]
        public IActionResult AtualizaUsuario(int id, Exercise exerciseAtualizado)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto usuarioBuscado
                Exercise exerciseBuscado = _exerciseRepository.BuscarPorId(id);

                // Verifica se o usuário foi encontrado
                if (exerciseBuscado != null)
                {
                    // Faz a chamada para o método
                    _exerciseRepository.Atualizar(id, exerciseAtualizado);

                    // Retora a resposta da requisição 204 - No Content
                    return StatusCode(204);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum usuário encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Usuarios/id
        [HttpDelete("DeletaExercise")]
        public IActionResult DeletaExercise(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto usuarioBuscado
                Exercise exerciseBuscado = _exerciseRepository.BuscarPorId(id);

                // Verifica se o usuário foi encontrado
                if (exerciseBuscado != null)
                {
                    // Faz a chamada para o método
                    _exerciseRepository.Deletar(id);

                    // Retora a resposta da requisição 202 - Accepted
                    return StatusCode(202);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum usuário encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}
