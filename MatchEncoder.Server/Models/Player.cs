using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Player")]
public class Player
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Number { get; set; }
    public bool IsCaptain { get; set; }
    public int TeamId { get; set; }
    public Team? Team { get; set; }
    public ICollection<MatchPlayer>? MatchPlayers { get; set; }
    public ICollection<Event>? Events { get; set; } // Navigation property for events
}
