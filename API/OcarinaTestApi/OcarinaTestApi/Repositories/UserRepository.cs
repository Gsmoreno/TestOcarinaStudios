using Microsoft.EntityFrameworkCore;
using OcarinaTestApi.Contexts;
using OcarinaTestApi.Domains;
using OcarinaTestApi.Inteface;

namespace OcarinaTestApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        GufiContext ctx = new GufiContext();
        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, User usuarioAtualizado)
        {
            // Busca um usuário através do id
            User usuarioBuscado = ctx.Users.Find(id);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Verifica se foi informado um nome de usuário
                if (usuarioAtualizado.Name != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.Name = usuarioAtualizado.Name;
                }

                // Verifica se foi informado um e-mail de usuário
                if (usuarioAtualizado.Email != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.Email = usuarioAtualizado.Email;
                }

                // Verifica se foi informada uma senha de usuário
                if (usuarioAtualizado.Password != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.Password = usuarioAtualizado.Password;
                }

                // Verifica se foi informada uma senha de usuário
                if (usuarioAtualizado.CaloriesDay != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.Password = usuarioAtualizado.Password;
                }


                // Verifica se foi informado o tipo do usuário
                if (usuarioAtualizado.IdTypeUser != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.IdTypeUser = usuarioAtualizado.IdTypeUser;
                }

                // Atualiza os dados do usuário que foi buscado
                ctx.Users.Update(usuarioBuscado);

                // Salva as informações para serem gravadas no banco
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um usuário por ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        public User BuscarPorId(int id)
        {
            // Busca o primeiro usuário encontrado para o ID informado e armazena no objeto usuarioBuscado
            // Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);

            // Outra forma
            // Usuario usuarioBuscado = ctx.Usuario.Find(id);

            // Outra forma, não mostrando a senha
            User usuarioBuscado = ctx.Users
               // Seleciona apenas os dados que devem ser mostrados
               .Select(u => new User()
               {
                   IdUser = u.IdUser,
                   Name = u.Name,
                   Email = u.Email,

                  
               })
               .FirstOrDefault(u => u.IdUser == id);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Retorna o usuário encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações de cadastro</param>
        public void Cadastrar(User novoUsuario)
        {
            // Adiciona um novo usuário
            ctx.Users.Add(novoUsuario);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o usuário que foi buscado através do id informado
            ctx.Users.Remove(BuscarPorId(id));

            // Outra forma

            // Busca um usuário através do id
            // Usuario usuarioBuscado = ctx.Usuario.Find(id);

            // Remove o usuário que foi buscado
            // ctx.Usuario.Remove(uUsuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<User> Listar()
        {
            // Retorna uma lista com todas as informações dos usuários
            //return ctx.Usuario.ToList();

            // Outra forma, não mostrando a senha
            return ctx.Users
               // Seleciona apenas os dados que devem ser mostrados
               .Select(u => new User()
               {
                   IdUser = u.IdUser,
                   Name = u.Name,
                   Email = u.Email,

                   
               })
               .ToList();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Um usuário autenticado</returns>
        public User Login(string email, string senha)
        {
            // Busca o primeiro usuário encontrado para o e-mail e a senha informados e armazena no objeto usuarioBuscado
            User usuarioBuscado = ctx.Users
                // Busca as informações referentes ao tipo de usuário
                .Include(u => u.IdTypeUser)
                .FirstOrDefault(u => u.Email == email && u.Password == senha);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Retorna o usuário encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }
    }
}
