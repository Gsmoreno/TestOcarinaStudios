using System;
using System.Collections.Generic;

namespace OcarinaTestApi.Domains;

public partial class Exercise
{
    public int IdExercise { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Finished { get; set; }

    public int? CaloriesBurned { get; set; }

    public int? IdUser { get; set; }

}
