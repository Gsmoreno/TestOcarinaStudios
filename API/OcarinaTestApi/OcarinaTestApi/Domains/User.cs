using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OcarinaTestApi.Domains;

public partial class User
{
    public int IdUser { get; set; }
    [JsonIgnore]
    public string Name { get; set; } 

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string CaloriesDay { get; set; } = null!;

    public int? IdTypeUser { get; set; }


}
