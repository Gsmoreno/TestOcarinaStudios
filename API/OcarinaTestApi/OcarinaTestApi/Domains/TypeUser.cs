using System;
using System.Collections.Generic;

namespace OcarinaTestApi.Domains;

public partial class TypeUser
{
    public int IdTypeUser { get; set; }

    public string? Role { get; set; }

    //public virtual ICollection<User> Users { get; set; } = new List<User>();
}
