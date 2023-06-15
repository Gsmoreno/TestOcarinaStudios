using OcarinaTestApi.Domains;

namespace OcarinaTestApi.Inteface
{
    public interface IExerciseRepository
    {
        /// <summary>
        /// Lista todos os tipos de exercicios 
        /// </summary>
        /// <returns>Uma lista de tipos de usuário</returns>
        List<Exercise> Listar();

        /// <summary>
        /// Busca um tipo de exercicios por ID
        /// </summary>
        /// <param name="id">ID do tipo de exercicios que será buscado</param>
        /// <returns>Um tipo de exercicios buscado</returns>
        Exercise BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de exercicios
        /// </summary>
        /// <param name="novoExercicio">Objeto com as informações de cadastro</param>
        void Cadastrar(Exercise novoExercicio);

        /// <summary>
        /// Atualiza um tipo de exercicios existente
        /// </summary>
        /// <param name="id">ID do tipo de exercicios que será atualizado</param>
        /// <param name="exercicioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Exercise exercicioAtualizado);

        /// <summary>
        /// Deleta um tipo de exercicios
        /// </summary>
        /// <param name="id">ID do tipo de exercicios que será deletado</param>
        void Deletar(int id);
    }
}
