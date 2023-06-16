using System.Text.Json.Serialization;

namespace OcarinaTestApi.Model
{
    public partial class UserDTO
    {

        

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? TipoUsuarioId { get; set; }

        
    }
}
