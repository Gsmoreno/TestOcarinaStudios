using System;
using System.Collections.Generic;

namespace OcarinaTestApi.Domains;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string CaloriesDay { get; set; } = null!;

    public int? IdTypeUser { get; set; }


}
