using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Team")]
public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Player>? Players { get; set; }
}
