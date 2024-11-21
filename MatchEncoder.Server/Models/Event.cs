using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Event")]
public class Event
{
    public int Id { get; set; }
    public DateTime Hour { get; set; }
    public string? Type { get; set; }
    public int Points { get; set; }

    // Foreign keys
    public int MatchId { get; set; }
    public Match? Match { get; set; }

    public int PlayerId { get; set; }
    public Player? Player { get; set; }
}
