using OcarinaTestApi.Contexts;
using OcarinaTestApi.Domains;
using OcarinaTestApi.Inteface;

namespace OcarinaTestApi.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();
        /// <summary>
        /// Atualiza um tipo de exercicio existente
        /// </summary>
        /// <param name="id">ID do tipo de exercicio que será atualizado</param>
        /// <param name="exercicioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Exercise exercicioAtualizado)
        {

            Exercise exerciseBuscado = ctx.Exercises.Find(id);

            if (exercicioAtualizado != null)
            {


                if (exercicioAtualizado.Name != null)
                {
                    // Atribui o novo valor ao campo
                    exerciseBuscado.Name = exercicioAtualizado.Name;
                }


                if (exercicioAtualizado.Finished != null)
                {
                    // Atribui o novo valor ao campo
                    exerciseBuscado.Finished = exercicioAtualizado.Finished;


                    if (exercicioAtualizado.CaloriesBurned != null)
                    {
                        // Atribui o novo valor ao campo
                        exerciseBuscado.CaloriesBurned = exercicioAtualizado.CaloriesBurned;
                    }

                    if (exercicioAtualizado.IdUser != null)
                    {
                        // Atribui o novo valor ao campo
                        exerciseBuscado.IdUser = exercicioAtualizado.IdUser;
                    }

                    // Atualiza o título do tipo de usuário que foi buscado
                    ctx.Exercises.Update(exerciseBuscado);

                    // Salva as informações para serem gravadas no banco
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Busca um tipo de usuário por ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscado</returns>
        public Exercise BuscarPorId(int id)
        {
            // Busca o primeiro tipo de usuário encontrado para o ID informado e armazena no objeto tipoUsuarioBuscado
            Exercise exerciseBuscado = ctx.Exercises.FirstOrDefault(tu => tu.IdExercise == id);

            // Outra forma
            // TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            // Verifica se o tipo de usuário foi encontrado
            if (exerciseBuscado != null)
            {
                // Retorna o tipo de usuário encontrado
                return exerciseBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoExercise">Objeto com as informações de cadastro</param>
        public void Cadastrar(Exercise novoExercise)
        {
            // Adiciona um novo tipo de usuário
            ctx.Exercises.Add(novoExercise);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o tipo de usuário que foi buscado através do id informado
            ctx.Exercises.Remove(BuscarPorId(id));

            // Outra forma

            // Busca um tipo de usuário através do id
            // TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            // Remove o tipo de usuário que foi buscado
            // ctx.TipoUsuario.Remove(tipoUsuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Uma lista de tipos de usuário</returns>
        public List<Exercise> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuário
            return ctx.Exercises.ToList();
        }
    }
}
